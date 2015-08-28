BEGIN TRY

	/*
*************************DROP FROM ALL SEGGU TABLES ********************************

	USE Seggu
	EXEC sp_MSforeachtable @command1 = 'DROP TABLE ?'

**************************************************************************************
	*/

	BEGIN TRAN INSERT_DATA

	BEGIN -- REVIZADOS OK

		BEGIN --CONTACTOS
		BEGIN TRAN INSERT_CONTACTS
	 
		SELECT a.idpersona, NEWID()Id
		INTO #contacts
		FROM CiberSeguros.dbo.agenda a
	
		INSERT INTO Seggu.dbo.Contacts (Id, FirstName, LastName, Phone, Mail, Notes)
		SELECT C.Id, A.nombre, A.apellido, A.telefono, A.mail, A.otros
		FROM CiberSeguros.dbo.AGENDA A
		INNER JOIN #contacts C ON C.idpersona = A.idpersona
	
		COMMIT TRAN INSERT_CONTACTS
		PRINT 'CONTACTOS IMPORTADOS'
		END	
	 
		BEGIN --BANKS
		BEGIN TRAN INSERT_BANKS

		SELECT b.CODIGO, NEWID() Id
		INTO #Banks
		FROM CiberSeguros.dbo.BANCOS b
		WHERE b.NOMBRE IS NOT NULL

		INSERT INTO Seggu.dbo.Banks (Id, Name, Number)
		SELECT b.Id, ba.NOMBRE Name, ba.NUMERO Number
		FROM #Banks b
		INNER JOIN CiberSeguros.dbo.BANCOS ba
			ON b.CODIGO = ba.CODIGO

		COMMIT TRAN INSERT_BANKS
		PRINT 'BANCOS IMPORTADOS'
		END
	
	BEGIN --PROVINCIAS - DISTRICTS - LOCALITIES
		BEGIN TRAN INSERT_PROVINCES

		INSERT INTO Seggu.dbo.Provinces (Id, Name)
		SELECT P.GUID, P.nombre
		FROM prov.dbo.provincia P
		
		INSERT INTO Seggu.dbo.Provinces (id, Name)
		VALUES( NEWID(), '- Seleccione -')

		INSERT INTO Seggu.dbo.Districts (Id, Name, ProvinceId)
		SELECT d.GUID, d.Nombre, p.GUID
		FROM prov.dbo.Departamento d
		INNER JOIN prov.dbo.Provincia p ON p.id = d.idProvincia

		INSERT INTO Seggu.dbo.Localities (Id, DistrictId, Name)
		SELECT loc.GUID, d.GUID, loc.Nombre
		FROM prov.dbo.Localidades loc
		INNER JOIN prov.dbo.Departamento d ON d.Id = loc.idDepartamento

		COMMIT TRAN INSERT_PROVINCES
		PRINT 'PROVINCIAS, LOCALIDADES IMPORTADOS'
		END

		BEGIN --CHEQUES
		BEGIN TRAN INSERT_CHEQUES

		SELECT c.CODIGO, NEWID() Id
		INTO #Cheques
		FROM CiberSeguros.dbo.CHEQUES c

		INSERT INTO Seggu.dbo.Cheques (Id, Number, Date, BankId, Value)
		SELECT c.Id, ch.NRO, ch.A_FECHA, b.Id, ch.IMPORTE
		FROM #Cheques c
		INNER JOIN CiberSeguros.dbo.CHEQUES ch ON c.CODIGO = ch.CODIGO
		INNER JOIN #Banks b ON b.CODIGO = ch.COD_BANCO

		COMMIT TRAN INSERT_CHEQUES
		PRINT'CHEQUES IMPORTADOS'
		END

		BEGIN --PRODUCERS
		BEGIN TRAN INSERT_PRODUCTOR
	
		SELECT PC.CODIGO, NEWID() Id
		INTO #Productores
		FROM CiberSeguros.dbo.PRODCOBR PC
	
		INSERT INTO Seggu.dbo.Producers (Id, Name, RegistrationNumber, IsCollector)
		SELECT P.Id, ISNULL(PC.NOMBRE, 'Sin Productor'), ISNULL(PC.NRO_MATR, ''), ISNULL(PC.COBRANZA, 1)
		FROM CiberSeguros.dbo.PRODCOBR PC
		RIGHT JOIN #Productores P
			ON ISNULL(p.CODIGO, -1) = ISNULL(PC.CODIGO, -1)
		
		COMMIT TRAN INSERT_PRODUCTOR
		PRINT 'PRODUCTORES IMPORTADOS'
		END

		BEGIN --COMPANIAS
		BEGIN TRAN INSERT_COMPANIAS

		SELECT C.CODIGO, NEWID() Id
		INTO #Companies
		FROM CiberSeguros.dbo.COMPAÑIAS C
		WHERE C.NOMBRE IS NOT NULL

		INSERT INTO Seggu.dbo.Companies (Id, Name, Notes, Phone, Active, EMail, Cuit, PaymentDay1, PaymentDay2)
		SELECT CO.Id, C.NOMBRE, '', C.TELEFONO1, C.ACTIVA, C.MAILEJ, ISNULL(C.CUIT, ''), '25', '5' 
		FROM CiberSeguros.dbo.COMPAÑIAS C
		INNER JOIN #Companies CO ON CO.CODIGO = C.CODIGO

		COMMIT TRAN INSERT_COMPANIAS	
		PRINT 'COMPANIAS IMPORTADAS'
		END
		
		BEGIN --PRODUCERCODES
		BEGIN TRAN INSERT_PRODUCERCODES

		INSERT INTO Seggu.dbo.ProducerCodes (ProducerId, CompanyId, Code)
		SELECT P.Id, C.Id, 'sin código'
		FROM CiberSeguros.dbo.CIA_PRODUCTOR CP
		INNER JOIN #Productores P
			ON P.CODIGO = CP.COD_PROD
		INNER JOIN #Companies C
			ON C.CODIGO = CP.COD_CIA

		COMMIT TRAN INSERT_PRODUCERCODES
		PRINT'CODIGOS DE PRODUCTORES IMPORTADOS'
		END

		BEGIN --RISKS
		BEGIN TRAN INSERT_RISKS
	
		SELECT r.COD_CIA, r.COD_RIES, NEWID() Id
		INTO #Risks
		FROM CiberSeguros.dbo.CIA_RIESGO r
		
		SELECT P.COD_CIA, P.COD_RIESGO
		INTO #COMP_RISK_FROM_POL
		FROM CiberSeguros.dbo.POLIZAS p
		GROUP BY P.COD_CIA, P.COD_RIESGO

		INSERT INTO #Risks (COD_CIA, COD_RIES, Id)
		SELECT T.COD_CIA, T.COD_RIESGO, NEWID() Id
		FROM (
			SELECT CRFP.COD_CIA, CRFP.COD_RIESGO
			FROM #COMP_RISK_FROM_POL CRFP
			EXCEPT
			SELECT r.COD_CIA, r.COD_RIES
			FROM #Risks r
		) T		
		
		SELECT c.codigo COD_CIA, r.codigo COD_RIES
		INTO #RisksWithoutCompany
		FROM CiberSeguros.dbo.RIESGO r
		CROSS JOIN CiberSeguros.dbo.COMPAÑIAS c
		WHERE (r.COD_CIA = 0 OR r.COD_CIA is null)

		INSERT INTO #Risks (COD_CIA, COD_RIES, Id)
		SELECT T.COD_CIA, T.COD_RIES, NEWID() Id
		FROM (
			SELECT CRFP.COD_CIA, CRFP.COD_RIES
			FROM #RisksWithoutCompany CRFP
			EXCEPT
			SELECT r.COD_CIA, r.COD_RIES
			FROM #Risks r
		) T		

		INSERT INTO Seggu.dbo.Risks (Id, Name, RiskType, CompanyId)
		SELECT r.Id, ri.DESCRIP, ri.cod_tiporiesgo, c.Id
		FROM #Risks r
		INNER JOIN CiberSeguros.dbo.RIESGO ri ON ri.codigo = r.COD_RIES
		INNER JOIN #Companies c ON c.CODIGO = r.COD_CIA

		COMMIT TRAN INSERT_RISKS
		PRINT 'RIESGOS IMPORTADOS'
		END
				
		BEGIN --COVERAGE
		BEGIN TRAN INSERT_COVERAGES
	
		SELECT c.CODIGO COD_CUBRE, c.COD_RIESGO, cr.COD_CIA-- , NEWID() Id, 'OTROS' CoverageType
		INTO #CoveragesFirstGroup
		FROM CiberSeguros.dbo.COBERT_OTROS c
		INNER JOIN #Risks cr ON c.COD_RIESGO = cr.COD_RIES
	
		SELECT 261 COD_CUBRE, p.COD_RIESGO, p.COD_CIA-- , NEWID() Id, 'OTROS' CoverageType
		INTO #CoveragesSecondGroup
		FROM CiberSeguros.dbo.POL_LISTPERSONAL plp
		INNER JOIN CiberSeguros.dbo.POLIZAS p ON p.CODIGO = plp.COD_POLIZA
		GROUP BY p.COD_RIESGO, p.COD_CIA

		SELECT t.COD_CUBRE COD_CUBRE, t.COD_RIESGO, t.COD_CIA, NEWID() Id, 'OTROS' CoverageType
		INTO #Coverages
		FROM (
			SELECT COD_CUBRE, COD_RIESGO, COD_CIA
			FROM #CoveragesFirstGroup
			UNION
			SELECT COD_CUBRE, COD_RIESGO, COD_CIA
			FROM #CoveragesSecondGroup
		) t
		GROUP BY t.COD_CUBRE, t.COD_RIESGO, t.COD_CIA
		--SELECT (SELECT COUNT(*) FROM #Coverages), (SELECT COUNT(*) FROM #Coverages GROUP BY Id)

		INSERT INTO Seggu.dbo.Coverages (Id, Name, Description,	RiskId)
		SELECT co.Id, ISNULL(c.DESCRIP, ri.Name), ISNULL(c.DESCRIP, ri.Name), r.Id
		FROM #Coverages co
		INNER JOIN CiberSeguros.dbo.COBERT_OTROS c ON c.CODIGO = co.COD_CUBRE
		INNER JOIN #Risks r ON r.COD_CIA = co.COD_CIA AND r.COD_RIES = co.COD_RIESGO
		INNER JOIN Seggu.dbo.Risks ri ON r.Id = ri.Id
	
		COMMIT TRAN INSERT_COVERAGES
		PRINT 'COBERTURAS IMPORTADAS'
		END

		BEGIN --COBERT AUTOS PASARLO A COVERAGE
		BEGIN TRAN INSERT_COBERAUTO
	
		SELECT ca.CODIGO, NEWID() Id, r.Id riskId, r.CompanyId CompanyId
		INTO #Covercars 
		FROM CiberSeguros.dbo.COBERT_AUTOS ca
		CROSS JOIN Seggu.dbo.Risks r WHERE r.Name LIKE 'AUTOMOTORES'

		--DECLARE @RISKID UNIQUEIDENTIFIER = (SELECT TOP 1 r.Id FROM Seggu.dbo.Risks r WHERE r.Description LIKE 'AUTOMOTORES')
	
		INSERT INTO Seggu.dbo.Coverages (Id, Name, Description, RiskId)
		SELECT cc.Id,ca.Nombre, ca.DESCRIP, cc.riskId
		FROM #Covercars cc
		INNER JOIN CiberSeguros.dbo.COBERT_AUTOS ca ON ca.CODIGO = cc.CODIGO

		INSERT INTO Seggu.dbo.CoveragesPacks (Id, Name, RiskId)
		SELECT cc.Id, ca.Nombre, cc.riskId
		FROM #Covercars cc
		INNER JOIN CiberSeguros.dbo.COBERT_AUTOS ca ON ca.CODIGO = cc.CODIGO

		INSERT INTO Seggu.dbo.CoveragesPackCoverage(Coverages_Id, CoveragesPacks_Id)
		SELECT cc.Id, cc.Id
		FROM #Covercars cc

		COMMIT TRAN INSERT_COBERAUTO
		PRINT 'COBERT AUTO IMPORTADOS A COVERAGE'
		END
		
		BEGIN --COBERT OTROS PASARLO A COVERAGE
		BEGIN TRAN INSERT_COVERAGEPACK

		SELECT cu.CODIGO, NEWID() Id, cu.COD_RIESGO, cr.COD_CIA
		INTO #CoveragePacks
		FROM CiberSeguros.dbo.CUBRE cu
		INNER JOIN CiberSeguros.dbo.CIA_RIESGO cr ON cu.COD_RIESGO = cr.COD_RIES
			
		--SELECT co.CODIGO COD_CUBRE, r.COD_CIA, co.COD_RIESGO, NEWID() Id
		--INTO #CoverOthers
		--FROM CiberSeguros.dbo.COBERT_OTROS co
		--INNER JOIN #Risks r ON r.COD_RIES = co.COD_RIESGO
	
		INSERT INTO Seggu.dbo.Coverages (Id, Name, Description, RiskId)
		SELECT c.Id, co.NOMBRE, ISNULL(co.NOMBRE,' '), R.Id
		FROM #CoveragePacks c
		INNER JOIN CiberSeguros.dbo.CUBRE co ON co.CODIGO = c.CODIGO
		INNER JOIN #Risks r ON r.COD_RIES = c.COD_RIESGO AND r.COD_CIA = c.COD_CIA

		SELECT pol_ub.cod_cubre, pol_int.cod_cobertotros, p.COD_RIESGO, cr.COD_CIA
		INTO #OtherCoveragesAssocPacks
		FROM CiberSeguros.dbo.POL_UBICACION pol_ub
		INNER JOIN CiberSeguros.dbo.POLIZAS p ON pol_ub.Cod_Poliza = p.CODIGO
		INNER JOIN CiberSeguros.dbo.CUBRE cu ON cu.CODIGO = pol_ub.cod_cubre
		INNER JOIN CiberSeguros.dbo.POL_INTEGRALES pol_int ON pol_int.cod_ubicacion = pol_ub.Codigo
		INNER JOIN CiberSeguros.dbo.CIA_RIESGO cr ON cr.COD_RIES = p.COD_RIESGO
		GROUP BY pol_ub.cod_cubre, pol_int.cod_cobertotros, p.COD_RIESGO, cr.COD_CIA

		INSERT INTO Seggu.dbo.CoveragesPacks(Id, Name, RiskId)
		SELECT cp.Id, cu.NOMBRE, r.Id
		FROM #CoveragePacks cp
		INNER JOIN CiberSeguros.dbo.CUBRE cu ON cp.CODIGO = cu.CODIGO
		INNER JOIN #Risks r ON cp.COD_RIESGO = r.COD_RIES AND cp.COD_CIA = r.COD_CIA

		INSERT INTO Seggu.dbo.CoveragesPackCoverage (Coverages_Id, CoveragesPacks_Id)
		SELECT DISTINCT c.Id, cp.Id
		FROM #OtherCoveragesAssocPacks ocap
		INNER JOIN #CoveragePacks cp ON ocap.COD_CIA = cp.COD_CIA AND ocap.cod_cubre = cp.CODIGO AND ocap.COD_RIESGO = cp.COD_RIESGO
		INNER JOIN #Coverages c ON c.COD_CIA = ocap.COD_CIA AND c.COD_CUBRE = ocap.cod_cubre AND c.COD_RIESGO = ocap.COD_RIESGO

		--select * from CiberSeguros.dbo.POL_INTEGRALES    
		
		COMMIT TRAN INSERT_COVERAGEPACK
		PRINT 'COBERT OTROS IMPORTADOS A COVERAGE'
		END

		BEGIN --CLIENTS
		BEGIN TRAN INSERT_ASEGURADOS

		SELECT A.CODIGO, NEWID() Id
		INTO #Clients
		FROM CiberSeguros.dbo.ASEGURADOS A

		INSERT INTO Seggu.dbo.Clients (
			BankingCode, 
			BirthDate,
			CellPhone, 
			CollectionTimeRange, 
			Cuit, 
			Document, 
			DocumentType, 
			FirstName,
			Id,
			IngresosBrutos,
			IsSmoker,
			IVA,
			LastName,
			Mail,
			MaritalStatus,
			Notes,
			Sex,
			Occupation
		)
		SELECT
			A.CBU,
			A.FECHA_NAC,
			A.CELULAR,
			A.HORA_COBR,
			A.NRO_CUIT,
			isnull( A.DOCUMENTO,'sin'),
			'1',
			A.NOM,
			C.Id,
			A.INGR_BRUT,
			A.FUMADOR,
			'1',
			A.APELLIDO,
			A.EMAIL,
			'1',
			A.NOTAS,
			A.SEXO,
			A.ACTIVIDAD
		FROM CiberSeguros.dbo.ASEGURADOS A
		INNER JOIN #Clients C
			ON C.CODIGO = A.CODIGO

		COMMIT TRAN INSERT_ASEGURADOS
		PRINT 'ASEGURADOS IMPORTADOS'	
		END
		
		BEGIN --ADDRESSES
		BEGIN TRAN INSERT_DIRECCIONES

		INSERT INTO Seggu.dbo.Addresses (Appartment, ClientId, Floor, Id,
		 LocalityId, Number, Phone, PostalCode, Street, AddressType)
		SELECT 
		T.Appartment, T.ClientId, T.Floor, T.Id, T.LocalityId, T.Number, T.Phone, T.PostalCode, T.Street, T.AddressType
		FROM (
			SELECT A.DEPTO Appartment, C.Id ClientId, A.PISO Floor, NEWID() Id,
			 L.Id LocalityId, A.NUMERO Number, A.TELEFONO1 Phone, A.COD_POST PostalCode, A.CALLE Street, 0 AddressType
			FROM CiberSeguros.dbo.ASEGURADOS A
			INNER JOIN #Clients C ON C.CODIGO = A.CODIGO
			INNER JOIN Seggu.dbo.Localities L ON L.Name LIKE '%'+ A.LOCALIDAD + '%'
			UNION ALL
			SELECT '' Appartment, C.Id ClientId, '' Floor, NEWID() Id,
			 L.Id LocalityId, '' Number, '' Phone, '' PostalCode, DIR_COBR Street, 1 AddressType
			FROM CiberSeguros.dbo.ASEGURADOS A
			INNER JOIN #Clients C ON C.CODIGO = A.CODIGO
			INNER JOIN Seggu.dbo.Localities L ON L.Name LIKE '%'+  A.LOC_COBR + '%'
		) T

		COMMIT TRAN INSERT_DIRECCIONES
		PRINT 'DIRECCIONES IMPORTADAS'
		END	

	BEGIN --update locality in Client notes
		BEGIN TRAN INSERT_locality

		--UPDATE C
		--SET C.Notes 
		--from Seggu.dbo.

		COMMIT TRAN INSERT_ASEGURADOS
		PRINT 'Localidades en Client.Notes ok'	
		END

		BEGIN --LEDGERACCOUNT
		BEGIN TRAN INSERT_LedgerAccount
	
		SELECT cco.idcuenta, NEWID() Id
		INTO #LedgerAccounts
		FROM CiberSeguros.dbo.cuentascontables cco
	
		INSERT INTO Seggu.dbo.LedgerAccounts (Id, Name)
		SELECT la.Id, cco.cuenta
		FROM CiberSeguros.dbo.cuentascontables cco
		INNER JOIN #LedgerAccounts la ON la.idcuenta = cco.idcuenta	 
	
		INSERT INTO Seggu.dbo.LedgerAccounts (Id, Name)
		VALUES( NEWID(), 'AJUSTE')

		COMMIT TRAN INSERT_LedgerAccount
		PRINT 'CUENTAS CONTABLES IMPORTADAS'
		END
			
		BEGIN --ASSETS (Activos {dónde está el $$$})
		BEGIN TRAN INSERT_Assets
	
		INSERT INTO Seggu.dbo.Assets (id, Name, Amount)
		VALUES( NEWID(), 'Efectivo', 6000)
	
		COMMIT TRAN INSERT_Assets
		PRINT 'BIENES, ACTIVOS IMPORTADAS'
		END
		
		BEGIN --CASH ACCOUNTS
		BEGIN TRAN INSERT_CASHACCOUNTS

		SELECT coca.idcontrolcaja, NEWID() Id
		INTO #CashAccounts
		FROM CiberSeguros.dbo.controlcaja coca

		DECLARE @ASSETID UNIQUEIDENTIFIER = 
			(SELECT TOP 1 A.Id FROM Seggu.dbo.assets a WHERE a.name LIKE 'Efectivo')
		INSERT INTO Seggu.dbo.CashAccounts 
		(Id, LedgerAccountId, Description, Amount, Balance, Date, ProducerId, FeeId, AssetId, ReceiptNumber)
		SELECT 
		 ca.Id, la.Id, coca.descripcion, coca.debe, coca.haber, coca.fecha, p.Id, null, @ASSETID, null
		FROM #CashAccounts ca
		INNER JOIN CiberSeguros.dbo.controlcaja coca ON coca.idcontrolcaja = ca.idcontrolcaja
		LEFT JOIN Seggu.dbo.Producers p ON p.Name LIKE 'OF%'
		LEFT JOIN #LedgerAccounts la ON la.idcuenta = '1'
	
		COMMIT TRAN INSERT_CASHACCOUNTS
		PRINT 'CONTROL CAJA IMPORTADAS'
		END

		BEGIN --CREDITCARDS
		BEGIN TRAN INSERT_CreditCards

		SELECT tc.CODIGO, NEWID() Id
		INTO #CreditCards
		FROM CiberSeguros.dbo.TARJETAS tc

		INSERT INTO Seggu.dbo.CreditCards (Id, Name)
		SELECT cc.Id, t.NOMBRE
		FROM #CreditCards cc
		INNER JOIN CiberSeguros.dbo.TARJETAS t ON t.CODIGO = cc.CODIGO

		COMMIT TRAN INSERT_CreditCards
		PRINT 'TARJETAS IMPORTADAS'
		END
	
		BEGIN --COMPANYCREDITCARD
		BEGIN TRAN INSERT_COMPANYCREDITCARD

		INSERT INTO Seggu.dbo.CreditCardCompany (Companies_Id, CreditCards_Id)
		SELECT c.Id, cc.Id
		FROM CiberSeguros.dbo.CIA_TARJCRED ctc
		INNER JOIN #Companies c ON c.CODIGO = ctc.COD_CIA
		INNER JOIN #CreditCards cc ON cc.codigo = ctc.COD_TARJ

		COMMIT TRAN INSERT_COMPANYCREDITCARD
		PRINT 'TARJETAS POR COMPAÑIAS'
		END
	
		BEGIN --CLIENTCREDITCARDS
		BEGIN TRAN INSERT_ClientCreditCards
	
		SELECT tc.CODIGO, NEWID() Id
		INTO #ClientCreditCards
		FROM CiberSeguros.dbo.TARJ_CRE tc

		INSERT INTO Seggu.dbo.ClientCreditCards (Id, BankId, ClientId, CreditCardId, ExpirationDate, Number)
		SELECT ccc.Id, b.Id, c.Id, cc.Id, tc.VENCIM, tc.NUMERO
		FROM CiberSeguros.dbo.TARJ_CRE tc
		INNER JOIN #ClientCreditCards ccc ON ccc.CODIGO = tc.CODIGO
		INNER JOIN #Banks b ON b.CODIGO = tc.COD_BANCO
		INNER JOIN #Clients c ON c.CODIGO = tc.COD_ASEG
		INNER JOIN #CreditCards cc ON cc.codigo = tc.COD_TARJ

		COMMIT TRAN INSERT_ClientCreditCards
		PRINT 'TARJETAS POR CLIENTES'
		END	
	
		BEGIN --BRANDS
		BEGIN TRAN INSERT_BRANDS

		SELECT M.CODIGO, NEWID() Id
		INTO #Brands
		FROM CiberSeguros.dbo.MARCAS M
		WHERE M.NOMBRE IS NOT NULL

		INSERT INTO Seggu.dbo.Brands (Id, Name)
		SELECT B.Id, M.NOMBRE 
		FROM CiberSeguros.dbo.MARCAS M
		INNER JOIN #Brands B ON B.CODIGO = M.CODIGO

		COMMIT TRAN INSERT_BRANDS
		PRINT 'MARCAS IMPORTADAS'
		END
	
		BEGIN --USE
		BEGIN TRAN INSERT_USES

		SELECT u.CODIGO, NEWID() Id
		INTO #Uses
		FROM CiberSeguros.dbo.USO u

		INSERT INTO Seggu.dbo.Uses (Id, Name)
		SELECT u.Id, uso.DESCRIPCION
		FROM  CiberSeguros.dbo.USO uso
		INNER JOIN #Uses u ON u.CODIGO = uso.CODIGO

		COMMIT TRAN INSERT_USES
		PRINT 'USOS IMPORTADOS'
		END
			
		BEGIN --VEHICLETYPES
		BEGIN TRAN INSERT_VEHICLETYPES
	
		SELECT ta.codigo, NEWID() Id
		INTO #tiposvehiculo
		FROM CiberSeguros.dbo.TIPO_AUT ta

		INSERT INTO #tiposvehiculo (codigo, Id)
		VALUES(0,NEWID())
	
		INSERT INTO Seggu.dbo.VehicleTypes (Id, Name)
		SELECT tv.Id, ISNULL(ta.Descripcion, 'Sin Nombre')
		FROM #tiposvehiculo tv
		LEFT JOIN CiberSeguros.DBO.TIPO_AUT ta ON tv.codigo = ta.codigo
	
		COMMIT TRAN INSERT_VEHICLETYPES
		PRINT 'TIPOS VEHICULOS IMPORTADOS'
		END
		
		BEGIN --USO X Tipo vehiculo
		BEGIN TRAN
	
		INSERT INTO Seggu.dbo.VehicleTypeUse (Uses_Id, VehicleType_Id)
		SELECT U.Id, TV.Id
		FROM CiberSeguros.dbo.USO_TIPO UT 
		INNER JOIN #tiposvehiculo TV ON TV.codigo = UT.COD_TIPO
		INNER JOIN #Uses U ON U.CODIGO = UT.COD_USO
	
		COMMIT TRAN
		PRINT 'UsoX TIPOvehiculo importado'
		END	

		BEGIN --CARROCERÍAS	
		BEGIN TRAN INSERT_bodyworks
	
		SELECT C.CODIGO, NEWID() Id
		INTO #Bodyworks
		FROM CiberSeguros.dbo.CARROCER C
		WHERE C.DESCRIPCION IS NOT NULL

		INSERT INTO Seggu.dbo.Bodyworks (Id, Name)
		SELECT B.Id, C.DESCRIPCION 
		FROM CiberSeguros.dbo.CARROCER C
		INNER JOIN #Bodyworks B ON B.CODIGO = C.CODIGO
	
		COMMIT TRAN INSERT_bodyworks
		PRINT 'CARROCERÍAS IMPORTADAS'
		END	
	
		BEGIN --TIPO_AUTO x CARROCER
		BEGIN TRAN INSERT_TIPOAUTOxCARROCERIA
	
		INSERT INTO Seggu.dbo.BodyworkVehicleType (Bodyworks_Id, VehicleTypes_Id)
		SELECT B.Id, TV.Id
		FROM CiberSeguros.dbo.CARROCER_TIPO CT
		INNER JOIN #Bodyworks B ON B.CODIGO = CT.CODIGO_CARROCER
		INNER JOIN #tiposvehiculo tv ON tv.codigo = CT.CODIGO_TIPO_AUT
	
		COMMIT TRAN INSERT_TIPOAUTOxCARROCERIA
		PRINT 'TIPO_AUTO X CARROCERIA IMPORTADOS'
		END
		
		BEGIN --CARMODELS
		BEGIN TRAN INSERT_MODELOS

		SELECT M.CODIGO, NEWID() Id
		INTO #CarModels
		FROM CiberSeguros.dbo.MODELOS M

		INSERT INTO Seggu.dbo.VehicleModels (Id, Name, BrandId, Origin, VehicleTypeId)
		SELECT CM.Id, ISNULL (M.NOMBRE, 'SIN NOMBRE'), B.Id, M.COD_ORIGEN, TV.Id
		FROM #CarModels CM
		INNER JOIN CiberSeguros.dbo.MODELOS M ON CM.CODIGO = M.CODIGO
		INNER JOIN #Brands B ON B.CODIGO = M.COD_MARCA
		INNER JOIN #tiposvehiculo TV ON TV.codigo = M.COD_TIPO
	
		COMMIT TRAN INSERT_MODELOS
		PRINT 'MODELOS IMPORTADOS'
		END
		
	BEGIN -- POLICIES
	BEGIN TRAN INSERT_Policies
	
	SELECT pol.CODIGO, NEWID() Id
	INTO #Policies
	FROM CiberSeguros.dbo.POLIZAS pol

	DECLARE @COVERAGEID UNIQUEIDENTIFIER = (
		SELECT TOP 1 C.Id 
		FROM Seggu.dbo.Coverages C 
		--WHERE C.Description LIKE '%GOLF%'
	)

	INSERT INTO Seggu.dbo.Policies (
		Id, PreviousNumber, Number, ClientId, IsAnnulled, IsRemoved, IsRenovated, Period, 
		RequestDate, StartDate, EndDate, EmissionDate, ReceptionDate, AnnulationDate,
		Prima, Premium, Surcharge, Value, Bonus, Notes, RiskId, ProducerId
	)
	SELECT 
		p.Id,
		pol.NRO_ANT, pol.NRO_POLIZa, c.Id, pol.ANULADA, pol.ELIMINADA, pol.RENOVADA, pol.COD_PERIODO,
		pol.FECH_SOLIC, pol.FECH_INIC, pol.FECH_FIN, pol.FECH_EMIS, pol.FECH_RECEP, pol.FECHANULPO,
		pol.PRIMA, pol.PREMIO, pol.ASEG_RECARGO , pol.SUMA_ASEG, pol.ASEG_BPROPIA,
		notas.nota, r.Id --lleno con basura y luego update este campo, 
		, pro.Id
	FROM CiberSeguros.dbo.POLIZAS pol
	INNER JOIN #Policies p ON pol.CODIGO = p.CODIGO
	INNER JOIN #Clients c ON c.CODIGO = pol.COD_ASEG
	INNER JOIN #Productores pro ON pro.CODIGO = pol.COD_PROD
	INNER JOIN #Risks r ON r.COD_RIES = pol.COD_RIESGO AND r.COD_CIA = pol.COD_CIA
	LEFT JOIN (
		SELECT DISTINCT
			pold.cod_poliza, 
			STUFF(
				(
					SELECT pd.[linea] + '\n'
					FROM CiberSeguros.dbo.POL_DETALLE pd
					WHERE (pd.cod_poliza = pold.cod_poliza) 
					FOR XML PATH(''),TYPE
				).value('(./text())[1]','VARCHAR(MAX)'),
				1,
				0,
				''
			) AS nota
		FROM CiberSeguros.dbo.POL_DETALLE pold
		WHERE pold.cod_poliza <> 0
	) notas ON p.CODIGO = notas.cod_poliza

	COMMIT TRAN INSERT_Policies
	PRINT 
		' POLIZAS IMPORTADAS '
	END
		
	BEGIN -- ENDOSOS
	BEGIN TRAN INSERT_ENDOSOS
	
	SELECT e.CODIGO, NEWID() Id
	INTO #Endorses
	FROM CiberSeguros.dbo.ENDOSOS e

	INSERT INTO Seggu.dbo.Endorses (Id, EndorseType, Number, Cause, PolicyId, ClientId, StartDate, EndDate
		, RequestDate, ReceptionDate , EmissionDate, AnnulationDate, Prima, Premium, Surcharge, Value
		, Notes, IsAnnulled, IsRemoved)
	SELECT 
		e.Id Id,
		en.COD_TIPO_END EndorseType,
		en.NRO_ENDOSO Number, 
		en.MOTIV_END Cause,
		p.Id PolicyId,
		c.Id ClientId,
		en.FECH_INIC StartDate, 
		ISNULL (en.FECH_FIN, '01-01-1900' ) EndDate, 
		en.FECH_SOLIC RequestDate, 
		en.FECH_RECEP ReceptionDate, 
		en.FECH_EMIS EmissionDate, 
		en.FECHANULEN AnnulationDate,
		en.PRIMA Prima, 
		en.PREMIO Premium, 
		en.RECARGO Surcharge, 
		en.SUMA_ASEG Value,
		notas.nota Notes, 
		en.Anulado IsAnnulled, 
		CASE WHEN en.Activo = '1' THEN '0' ELSE '1' END IsRemoved--,
		--pol.CoverageId CoverageId
	FROM #Endorses e
	INNER JOIN CiberSeguros.dbo.ENDOSOS en ON e.CODIGO = en.CODIGO
	INNER JOIN #Policies p ON p.CODIGO = en.COD_POLIZA 
	INNER JOIN Seggu.dbo.Policies pol ON pol.Id = p.Id 
	INNER JOIN #Clients c ON c.CODIGO = en.COD_ASEG
	LEFT JOIN #Companies com ON com.CODIGO = en.COD_CIA
	LEFT JOIN (
		SELECT DISTINCT
			pold.cod_endoso, 
			STUFF(
				(
					SELECT pd.[linea] + '\n'
					FROM CiberSeguros.dbo.POL_DETALLE pd
					WHERE (pd.cod_endoso = pold.cod_endoso) 
					FOR XML PATH(''),TYPE
				).value('(./text())[1]','VARCHAR(MAX)'),
				1,
				2,
				''
			) AS nota
		FROM CiberSeguros.dbo.POL_DETALLE pold
		WHERE pold.cod_endoso <> 0
	) notas ON en.CODIGO = notas.cod_endoso -- se come 2 caracteres y hay que concatenar el motiv_endoso al comienzo

	COMMIT TRAN INSERT_ENDOSOS
	PRINT 
		' ENDOSOS IMPORTADOS ' 

	END
		
	BEGIN -- VEHICLES
	BEGIN TRAN INSERT_VEHICLES

	SELECT pa.CODIGO CodigoPolAuto, comp.CODIGO codigoCompañia
	INTO #companyByPolAutos
	FROM CiberSeguros.dbo.POLIZAS p
	INNER JOIN CiberSeguros.dbo.POL_AUTOS pa on pa.COD_POLIZA = p.CODIGO
	INNER JOIN CiberSeguros.dbo.COMPAÑIAS comp on p.COD_CIA = comp.CODIGO
	GROUP BY pa.CODIGO, comp.CODIGO

	SELECT PA.CODIGO, NEWID() Id, CC.Id CoverageId, P.Id PolicyId, E.Id EndorseId
	INTO #Vehicles
	FROM CiberSeguros.dbo.POL_AUTOS PA 
	LEFT JOIN #companyByPolAutos CompPolAut On pa.codigo = CompPolAut.CodigoPolAuto
	LEFT JOIN #Companies C on CompPolAut.codigoCompañia = C.CODIGO
	LEFT JOIN Seggu.DBO.Risks r ON r.CompanyId = C.Id
	AND r.Name like 'Automotores'
	LEFT JOIN #Covercars CC ON 	cc.CompanyId = c.Id AND pa.cod_cobertura = cc.CODIGO
	INNER JOIN #Policies P ON P.CODIGO = PA.COD_POLIZA
	LEFT JOIN #Endorses E ON E.CODIGO = PA.COD_ENDOSO

	DECLARE @CARCOVERAGENULL UNIQUEIDENTIFIER = (
	SELECT TOP 1 Id
	FROM #Covercars CC
	WHERE CC.CODIGO = '29'
	)
	DECLARE @CARMODELNULL UNIQUEIDENTIFIER = (
		SELECT TOP 1 Id
		FROM Seggu.dbo.VehicleModels
		WHERE Name = 'SIN NOMBRE'
	)
	DECLARE @USONULL UNIQUEIDENTIFIER = (
		SELECT TOP 1 Id
		FROM #Uses u
		WHERE u.CODIGO = '1'
	)
	DECLARE @CARROCERIANULL UNIQUEIDENTIFIER = (
		SELECT TOP 1 Id
		FROM #Bodyworks B
		WHERE B.CODIGO = '99'
	)
		
	 --INSERTAR LOS VEHICULOS CON POLIZAS            
	INSERT INTO Seggu.dbo.Vehicles (Id, VehicleModelId, Chassis,
		Engine, Plate, Year, UseId, BodyworkId, PolicyId, EndorseId, IsRemoved)
	SELECT 
		V.Id, ISNULL(CM.Id, @CARMODELNULL), ISNULL(p.CHASIS, 'SIN NUM'),
		ISNULL(p.MOTOR, 'SIN NUM'), ISNULL(p.PATENTE,'SIN PAT'),
		ISNULL (p.ANIO,'1900'), ISNULL(U.Id, @USONULL), ISNULL(B.Id, @CARROCERIANULL),
		pol.Id, en.Id, p.BAJA
	FROM CiberSeguros.dbo.POL_AUTOS p
	LEFT JOIN #Vehicles V ON V.CODIGO = P.CODIGO
	LEFT JOIN #CarModels CM ON CM.CODIGO = P.COD_MODELO	
	LEFT JOIN #Bodyworks B ON B.CODIGO = p.COD_CARROCERIA
	LEFT JOIN #Uses U ON U.CODIGO = P.COD_USO
	INNER JOIN #Policies pol ON pol.CODIGO = p.COD_POLIZA
	LEFT JOIN #Endorses e ON e.CODIGO = p.COD_ENDOSO
	LEFT JOIN Seggu.dbo.Endorses en ON en.Id = E.Id
	
	INSERT INTO Seggu.dbo.VehicleCoverage(Coverages_Id, Vehicles_Id)
	SELECT cc.Id, v.Id
	FROM #Vehicles v
	INNER JOIN CiberSeguros.dbo.POL_AUTOS pa ON pa.CODIGO = v.CODIGO
	INNER JOIN CiberSeguros.dbo.POLIZAS p ON p.CODIGO = pa.COD_POLIZA
	INNER JOIN CiberSeguros.dbo.COBERT_AUTOS ca ON ca.CODIGO = pa.cod_cobertura AND p.COD_CIA = ca.COD_CIA
	INNER JOIN #Companies c ON c.CODIGO = ca.COD_CIA
	INNER JOIN #Covercars cc ON cc.CODIGO = ca.CODIGO AND cc.CompanyId = c.Id

	COMMIT TRAN INSERT_VEHICLES
	PRINT 'AUTOS MIGRADOS'
	END

	END

	BEGIN -- POL LISTADO DE PERSONAL
	BEGIN TRAN INSERT_LISTPERSONAL
	
	SELECT LP.CODIGO, NEWID()ID, P.Id PolicyId--, CO.Id CoverageId
	INTO #Employee
	FROM CiberSeguros.dbo.POL_LISTPERSONAL LP
	--INNER JOIN CiberSeguros.DBO.POLIZAS PO ON PO.CODIGO = LP.COD_POLIZA
	INNER JOIN #Policies P ON P.CODIGO = LP.COD_POLIZA
	INNER JOIN CiberSeguros.dbo.POLIZAS POL ON POL.CODIGO = P.CODIGO
	--INNER JOIN #Coverages CO ON CO.COD_CUBRE = 261 AND POL.COD_CIA = CO.COD_CIA
	
	INSERT INTO Seggu.dbo.Employees ( Id, PolicyId, FirstName, LastName, Dni, CUIT, BirthDate, IsRemoved, InsuranceAmount)
	SELECT E.Id, E.PolicyId, LP.APEYNOM, LP.APEYNOM, 'dni',
		ISNULL(Str(LP.CUIL, 25, 5), 'Sin CUIT'), ISNULL( LP.FECHA_NAC, CURRENT_TIMESTAMP), lp.BAJA, ISNULL(lp.SUMA, 0)
	FROM CiberSeguros.dbo.POL_LISTPERSONAL LP
	INNER JOIN #Employee E ON E.CODIGO = LP.CODIGO

	SELECT c.COD_CUBRE, c.Id, c.COD_CIA, c.COD_RIESGO
	INTO #EmployeeCoverage
	FROM #Coverages c
	WHERE c.COD_CUBRE = 261

	INSERT INTO Seggu.dbo.EmployeeCoverage(Coverages_Id, Employees_Id)
	SELECT ec.Id, e.ID
	FROM #EmployeeCoverage ec
	INNER JOIN CiberSeguros.dbo.POLIZAS p ON ec.COD_CIA = p.COD_CIA AND ec.COD_RIESGO = p.COD_RIESGO 
	INNER JOIN #Policies tp ON p.CODIGO = tp.CODIGO
	INNER JOIN #Employee e ON tp.Id = e.PolicyId
	
	-- HAY QUE METER EN POLICIES EL COVERAGEID 
	--UPDATE P
	--SET P.CoverageId =E.CoverageId
	--FROM #Employee E
	--INNER JOIN Seggu.dbo.Policies P ON P.Id = E.PolicyId

	--UPDATE EN
	--SET EN.CoverageId = E.CoverageId
	--FROM #Employee E
	--INNER JOIN Seggu.dbo.Endorses EN ON EN.PolicyId = E.PolicyId		 

	COMMIT TRAN INSERT_LISTPERSONAL
	PRINT 'LISTADO DE PERSONAL IMPORTADO'
	END
		
	BEGIN -- POL_UBICACIÓN
	BEGIN TRAN INSERT_UBIC
	
	SELECT PU.Codigo, NEWID()Id
	INTO #polubic
	FROM CiberSeguros.dbo.POL_UBICACION PU

	COMMIT TRAN INSERT_UBIC
	PRINT'POL_UBICACIÓN temporal IMPORTADAS'
	END
	
	BEGIN -- POLIZAS INTEGRALES
	BEGIN TRAN INSERT_POLINT
	
	SELECT PIN.codigo, NEWID() Id, P.Id PolicyId
	INTO #integrals
	FROM CiberSeguros.dbo.POL_INTEGRALES PIN
	INNER JOIN CiberSeguros.dbo.POL_UBICACION PU ON PU.Codigo = PIN.cod_ubicacion
	INNER JOIN #Policies P ON P.CODIGO = PU.Cod_Poliza
	INNER JOIN Ciberseguros.dbo.POLIZAS POL ON POL.CODIGO = P.CODIGO
	--INNER JOIN #Coverages C ON C.COD_CUBRE = PIN.cod_cobertotros AND C.COD_CIA = POL.COD_CIA
	
	DECLARE @LocalityId UNIQUEIDENTIFIER = (SELECT TOP 1 L.Id FROM Seggu.dbo.Localities L WHERE Name LIKE '%TALAR%') 

	INSERT INTO Seggu.dbo.Integrals(Id, PolicyId, EndorseId) -- mas el coverageId en policies
	SELECT I.Id, POL.Id, e.Id
	FROM CiberSeguros.dbo.POL_INTEGRALES PIN
	INNER JOIN #integrals I ON I.codigo = PIN.codigo
	LEFT JOIN CiberSeguros.dbo.POL_UBICACION PU ON PU.Codigo = PIN.cod_ubicacion
	LEFT JOIN #Policies POL ON POL.CODIGO = PU.Cod_Poliza
	LEFT JOIN #Endorses E ON e.CODIGO = pin.cod_endoso
	
	INSERT INTO Seggu.dbo.IntegralCoverage(Coverages_Id, Integrals_Id)
	SELECT c.Id, i.Id
	FROM CiberSeguros.dbo.POL_INTEGRALES PIN
	INNER JOIN #integrals I ON I.codigo = PIN.codigo
	LEFT JOIN CiberSeguros.dbo.POL_UBICACION PU ON PU.Codigo = PIN.cod_ubicacion
	LEFT JOIN #Policies POL ON POL.CODIGO = PU.Cod_Poliza
	INNER JOIN CiberSeguros.dbo.POLIZAS p ON p.CODIGO = pol.CODIGO
	INNER JOIN #Coverages c ON p.COD_CIA = c.COD_CIA AND p.COD_RIESGO = c.COD_RIESGO AND PU.cod_cubre = c.COD_CUBRE

	--UPDATE P
	--SET P.CoverageId =I.CoverageId
	--FROM #integrals I
	--INNER JOIN Seggu.dbo.Policies P ON P.Id = I.PolicyId

	--UPDATE EN
	--SET EN.CoverageId = E.CoverageId
	--FROM #Employee E
	--INNER JOIN Seggu.dbo.Endorses EN ON EN.PolicyId = E.PolicyId	
		
	COMMIT TRAN INSERT_POLINT
	PRINT 'POL INTEGRALES IMPORTADAS'
	END
	
	BEGIN -- LIQUIDACIONES
		
		BEGIN --LIQUIDACIONES
		BEGIN TRAN INSERT_LIQ
	
		SELECT LR.CODIGO, NEWID() Id, LR.FECHA_LIQ
		INTO #liq 
		FROM CiberSeguros.dbo.LIQ_REGISTRADAS LR
	
		INSERT INTO Seggu.dbo.Liquidations (Id, Date, ReceptionDate, Registered, Total, CompanyId)
		SELECT l.Id, LR.FECHA_LIQ, lr.FECHA_REC, 1, LR.IMPORTE, C.Id
		FROM #liq l
		INNER JOIN CiberSeguros.dbo.LIQ_REGISTRADAS LR ON LR.CODIGO = l.CODIGO
		INNER JOIN #Companies C ON LR.COD_CIA = C.CODIGO
	
		COMMIT TRAN INSERT_LIQ
		PRINT 'lIQUIDACIONES IMPORTADAS'
		END
	
		BEGIN --FEESELECTIONS (grupos de cuotas guardadas)
		BEGIN TRAN INSERT_GRUPOS
	
		SELECT l.Id LiqId, NEWID() Id
		INTO #FeeSelections
		FROM Seggu.dbo.Liquidations l

		INSERT INTO Seggu.dbo.FeeSelections (Id, Name, Total, LiquidationId)
		SELECT NEWID() Id, 'Liquidacion - ' + CONVERT(NVARCHAR(100), l.Date, 103), l.Total, l.Id
		FROM #liq liq 
		INNER JOIN Seggu.dbo.Liquidations l on l.Id = liq.Id
	
		COMMIT TRAN INSERT_GRUPOS
		PRINT 'GRUPO PRUEBA INSERTADO'
		END
	
		BEGIN --FEES con ENDOSOS
		BEGIN TRAN INSERT_cuotasCobrar

		SELECT cp.codigo, NEWID() Id
		INTO #Fees
		FROM CiberSeguros.dbo.POL_CUOTASPAGAR cp	

		SELECT F.Id FeeId 
			, p.Id PolicyId
			, CC.NRO_CUOTA
			, ISNULL(cc.VENCIMIENTO, '1/1/1990') VENCIMIENTO
			, CC.IMPORTE Valor
			, cc.SALDO
			, cp.IMPORTE ALiquidar 
			--, liq.FECHA_LIQ
			,(CASE 
				WHEN CC.IMPORTE > (SUM(AC.IMPORTE)) THEN '2' --observado
				WHEN CC.IMPORTE = cc.SALDO THEN '0' --debe
				WHEN CC.SALDO = 0 THEN '1' --pagado
				ELSE '3' --preliq
				END
			) ESTADO
			,(CASE
				WHEN CC.SALDO = 0 THEN max(fse.Id)
				END
				) FeeSelecId
			, E.Id EndoId

		INTO #CuotasAInsertar
		FROM CiberSeguros.DBO.POL_CUOTASCOBRAR CC
		INNER JOIN CiberSeguros.dbo.POL_CUOTASPAGAR cp ON cp.COD_POLIZA = cc.COD_POLIZA 
		AND cp.NRO_CUOTA = cc.NRO_CUOTA
		AND cp.COD_ENDOSO = cc.COD_ENDOSO
		AND cp.IMPORTE <> 0
		INNER JOIN #Fees f ON F.codigo = cp.codigo
		LEFT JOIN #Endorses E ON E.CODIGO = CC.COD_ENDOSO
		LEFT JOIN #Policies P ON P.CODIGO = cc.COD_POLIZA
		LEFT JOIN CiberSeguros.dbo.APLIC_COBR AC ON AC.COD_POLCUOCOBR = CC.codigo

		LEFT JOIN CiberSeguros.dbo.CUO_LIQREGCIA clrc ON clrc.COD_POLCUOPAGAR = cp.CODIGO
		LEFT JOIN CiberSeguros.dbo.DET_LIQREG dlr ON dlr.CODIGO = clrc.COD_DETLIQREG
		LEFT JOIN #liq liq ON liq.CODIGO = dlr.COD_LIQREG
		LEFT JOIN #FeeSelections FS ON FS.LiqId = liq.id
		LEFT JOIN Seggu.dbo.FeeSelections fse ON fse.LiquidationId = Liq.Id

		GROUP BY 
		F.Id, P.Id, CC.NRO_CUOTA, CC.VENCIMIENTO, cc.IMPORTE, cc.SALDO, cp.IMPORTE, e.Id--, liq.FECHA_LIQ

	
		--SELECT cai.FeeId, COUNT(*) TotalCount
		--FROM #CuotasAInsertar cai
		--	GROUP BY cai.FeeId
		--HAVING COUNT(*) > 1
		--ORDER BY COUNT(*) DESC

		INSERT INTO Seggu.dbo.Fees(Id, PolicyId, Number, ExpirationDate, Value--, RegisteredLiqDate
		, Balance, CompanyPayment, Annulated, FeeSelectionId, State, EndorseId)

		SELECT 
		CAI.FeeId, CAI.PolicyId, CAI.NRO_CUOTA, CAI.VENCIMIENTO, CAI.Valor--, CAI.Fecha_liq
		, CAI.SALDO, CAI.ALiquidar, 0, CAI.FeeSelecId, CAI.Estado, CAI.EndoId
		FROM #CuotasAInsertar CAI
	
		COMMIT TRAN INSERT_cuotasCobrar
		PRINT 'Cuotas con ENDOSOS importadas'
		END	
	
	END
	
	BEGIN -- FINALIZAR

		BEGIN -- CASUALTYTYPES
		BEGIN TRAN INSERT_CasualtyTypes

		SELECT ts.CODIGO, NEWID() Id
		INTO #CasualtyTypes
		FROM CiberSeguros.dbo.TIPO_SINIESTRO ts
		WHERE ts.NOMBRE IS NOT NULL AND ts.NOMBRE <> ''

		INSERT INTO Seggu.dbo.CasualtyTypes (Id, Name)
		SELECT ct.Id, ts.NOMBRE
		FROM #CasualtyTypes ct
		INNER JOIN CiberSeguros.dbo.TIPO_SINIESTRO ts ON ts.CODIGO = ct.CODIGO

		COMMIT TRAN INSERT_CasualtyTypes
		PRINT 'TIPOS siniestros importados'
		END
	
		BEGIN -- CASUALTIES
		BEGIN TRAN INSERT_Casualties
	
		SELECT S.CODIGO, NEWID()Id
		INTO #Siniestros
		FROM CiberSeguros.dbo.SINIESTROS S
	
		INSERT INTO Seggu.dbo.Casualties ( 
		Id, PolicyId, Number, CasualtyTypeId, OurCharge, 
		OccurredDate, ReceiveDate, PoliceReportDate, EstimatedCompensation, DefinedCompensation, Notes)
		SELECT SI.Id, P.Id, S.NRO, CT.Id, S.NUESTRO_CARGO,
		S.FECHA_OCURRIDO, S.FECHA_RECIBIDO, S.FECHA_DENUNPOL, S.INDEMN_ESTIMADA, S.INDEMN_DEF, ' ' 
		FROM CiberSeguros.dbo.SINIESTROS S
		INNER JOIN #Siniestros SI ON SI.CODIGO = S.CODIGO
		INNER JOIN #Policies P ON P.CODIGO = S.COD_POLIZA
		INNER JOIN #CasualtyTypes CT ON CT.CODIGO = S.COD_TIPOSIN
	
		COMMIT TRAN INSERT_Casualties
		PRINT 'SINIESTROS Importados'
		END
	
		BEGIN -- ACCESORYTYPES
		BEGIN TRAN INSERT_ACCESSORYTYPES

		SELECT ta.CODIGO, NEWID() Id
		INTO #AccessoryTypes
		FROM CiberSeguros.dbo.TIPO_ACCESORIO ta

		INSERT INTO Seggu.dbo.AccessoryTypes(Id, Name)
		SELECT at.Id, ta.NOMBRE Name
		FROM #AccessoryTypes at
		INNER JOIN CiberSeguros.dbo.TIPO_ACCESORIO ta
			ON at.CODIGO = ta.CODIGO

		COMMIT TRAN INSERT_ACCESSORYTYPES
		PRINT 'TIPOS ACCESORIOS IMPORTADOS'
		END
	
		BEGIN -- ACCESSORIES
		BEGIN TRAN INSERT_ACCESSORIES_WITH_POLICIES
	
		SELECT a.CODIGO, NEWID() Id
		INTO #Accesories
		FROM CiberSeguros.dbo.ACCESORI a
		WHERE a.Cod_endoso = 0 OR a.Cod_endoso IS NULL
		
		INSERT INTO Seggu.DBO.Accessories (Id, Name, Stamp, ExpirationDate, AccessoryTypeId, Value, VehicleId)
			SELECT ac.Id, ISNULL(A.NOMBRE, ''), ISNULL(A.OBLEA, ''), ISNULL(A.VENCIMIENTO, GETDATE()), at.Id, ISNULL(A.VALOR, 0), v.Id
			FROM #Accesories ac
			INNER JOIN CiberSeguros.dbo.ACCESORI A ON ac.CODIGO = A.CODIGO
			INNER JOIN #AccessoryTypes at ON at.CODIGO = A.COD_TIPOACCESORIO
			INNER JOIN #Vehicles v ON v.CODIGO = A.Cod_auto
	
		COMMIT TRAN INSERT_ACCESSORIES_WITH_POLICIES

		BEGIN TRAN INSERT_ACCESSORIES_WITH_ENDORSES
		
		-- COLLECT ACCESSORIES WITH ENDORSES
		SELECT a.CODIGO, NEWID() Id
		INTO #AccesoriesWithEndorses
		FROM CiberSeguros.dbo.ACCESORI a
		WHERE a.Cod_endoso <> 0 AND a.Cod_endoso IS NOT NULL
		
		/*
		ACCESSORIES WITH ENDORSES DO NOT REFERENCE ENDORSE VEHICLES
		IN ORDER TO REFERENCE ENDORSE VEHICLES WE NEED TO CREATE ENDORSE VEHICLES
		FROM REFERENCED POL_AUTOS
		*/
		DECLARE @CARCOVERAGENULL2 UNIQUEIDENTIFIER = (
		SELECT TOP 1 Id
		FROM #Covercars CC
		WHERE CC.CODIGO = '29'
		)
		DECLARE @CARMODELNULL2 UNIQUEIDENTIFIER = (
			SELECT TOP 1 Id
			FROM Seggu.dbo.VehicleModels
			WHERE Name = 'SIN NOMBRE'
		)
		DECLARE @USONULL2 UNIQUEIDENTIFIER = (
			SELECT TOP 1 Id
			FROM #Uses u
			WHERE u.CODIGO = '1'
		)
		DECLARE @CARROCERIANULL2 UNIQUEIDENTIFIER = (
			SELECT TOP 1 Id
			FROM #Bodyworks B
			WHERE B.CODIGO = '99'
		)

		SELECT e.CODIGO COD_ENDOSO, e.Id, pa.CODIGO COD_POL_AUTO
		INTO #EndorsesByAccesories
		FROM #AccesoriesWithEndorses awe
		INNER JOIN CiberSeguros.dbo.ACCESORI a ON a.CODIGO = awe.CODIGO
		INNER JOIN #Endorses e ON e.CODIGO = a.Cod_endoso
		INNER JOIN CiberSeguros.dbo.POL_AUTOS pa ON pa.CODIGO = a.Cod_auto
		GROUP BY e.CODIGO, e.Id, pa.CODIGO

		SELECT PA.CODIGO, NEWID() Id, CC.Id CoverageId, P.Id PolicyId, eba.Id EndorseId
		INTO #VehiclesFromAccesoriesWithEndorses
		FROM CiberSeguros.dbo.POL_AUTOS PA 
		LEFT JOIN #companyByPolAutos CompPolAut On pa.codigo = CompPolAut.CodigoPolAuto
		LEFT JOIN #Companies C on CompPolAut.codigoCompañia = C.CODIGO
		LEFT JOIN Seggu.DBO.Risks r ON r.CompanyId = C.Id
		AND r.Name like 'Automotores'
		LEFT JOIN #Covercars CC ON 	cc.CompanyId = c.Id AND pa.cod_cobertura = cc.CODIGO
		INNER JOIN #Policies P ON P.CODIGO = PA.COD_POLIZA
		INNER JOIN #EndorsesByAccesories eba ON eba.COD_POL_AUTO = PA.CODIGO

		INSERT INTO Seggu.dbo.Vehicles (Id, VehicleModelId, Chassis,
		 Engine, Plate, Year, UseId, BodyworkId, PolicyId, EndorseId)
		SELECT 
			V.Id, ISNULL(CM.Id, @CARMODELNULL2), ISNULL(p.CHASIS, 'SIN NUM'),
			ISNULL(p.MOTOR, 'SIN NUM'), ISNULL(p.PATENTE,'SIN PAT'),
			ISNULL (p.ANIO,'1900'), ISNULL(U.Id, @USONULL2), ISNULL(B.Id, @CARROCERIANULL2),
			pol.Id, en.Id
		FROM CiberSeguros.dbo.POL_AUTOS p
		INNER JOIN #VehiclesFromAccesoriesWithEndorses V ON V.CODIGO = P.CODIGO
		LEFT JOIN #CarModels CM ON CM.CODIGO = P.COD_MODELO	
		LEFT JOIN #Bodyworks B ON B.CODIGO = p.COD_CARROCERIA
		LEFT JOIN #Uses U ON U.CODIGO = P.COD_USO
		LEFT JOIN #Policies pol ON pol.CODIGO = p.COD_POLIZA
		LEFT JOIN #Endorses e ON e.CODIGO = p.COD_ENDOSO
		LEFT JOIN Seggu.dbo.Endorses en ON en.Id = E.Id

		DECLARE @DEFAULT_ACCESSORY_TYPE UNIQUEIDENTIFIER = (
			SELECT TOP 1 Id FROM Seggu.dbo.AccessoryTypes ORDER BY Name
		)

		INSERT INTO Seggu.DBO.Accessories (Id, Name, Stamp, ExpirationDate, AccessoryTypeId, Value, VehicleId)
		SELECT ac.Id, ISNULL(A.NOMBRE, ''), ISNULL(A.OBLEA, ''), ISNULL(A.VENCIMIENTO, GETDATE()), ISNULL(at.Id, @DEFAULT_ACCESSORY_TYPE), ISNULL(A.VALOR, 0), v.Id
		FROM #AccesoriesWithEndorses ac
		INNER JOIN CiberSeguros.dbo.ACCESORI A ON ac.CODIGO = A.CODIGO
		LEFT JOIN #AccessoryTypes at ON at.CODIGO = A.COD_TIPOACCESORIO
		INNER JOIN #Endorses e ON A.Cod_endoso = e.CODIGO
		INNER JOIN #VehiclesFromAccesoriesWithEndorses v ON v.CODIGO = A.Cod_auto AND e.Id = v.EndorseId
		
		COMMIT TRAN INSERT_ACCESSORIES_WITH_ENDORSES

		PRINT 'ACCESORIOS IMPORTADOS'	
		
		END

		BEGIN -- FINAL TOUCH
		BEGIN TRAN UPDATE_FEES

		UPDATE Seggu.dbo.Fees
		SET State = '4' --liquidado
		WHERE FeeSelectionId IS NOT NULL

		UPDATE seggu.dbo.Fees 
		SET State = CASE 
		 WHEN State ='0' and ExpirationDate <= '9/15/2015' THEN '7' 
		 WHEN State ='0' and ExpirationDate < CURRENT_TIMESTAMP and ExpirationDate > '10/7/2015' THEN '6' 
		 ELSE State
		 END

		COMMIT TRAN UPDATE_FEES
		PRINT 'TOQUE FINAL'
		END

		BEGIN TRAN CREATE_USERS
		INSERT INTO Seggu.dbo.Users (Id, Username, Password, Role)
		SELECT NEWID(), 'franco.botiuk', 'Seggu01', 0 UNION ALL
		SELECT NEWID(), 'agustin.polo', 'Seggu01', 1 UNION ALL
		SELECT NEWID(), 'lucas.vargas', 'Seggu01', 2
		COMMIT TRAN CREATE_USERS
	END
	
	COMMIT TRAN INSERT_DATA

	PRINT 'FINISHED'

END TRY

BEGIN CATCH

	IF @@TRANCOUNT > 0 ROLLBACK TRAN

	BEGIN
	declare @sql nvarchar(max)
	select @sql = isnull(@sql+';', '') + 'drop table ' + quotename(name)
	from tempdb..sysobjects
	where name like '#%'
	exec (@sql)
	END	
	USE Seggu
	EXEC sp_MSforeachtable 'DELETE FROM ?'

	PRINT 'ERROR: LINE(' + CAST(ERROR_LINE() AS NVARCHAR(100)) + '), MESSAGE("' + ERROR_MESSAGE() + '")'

END CATCH
