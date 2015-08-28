BEGIN TRY

	/*
*************************DROP FROM ALL SEGGU TABLES ********************************

	USE Seggu
	EXEC sp_MSforeachtable @command1 = 'DROP TABLE ?'

**************************************************************************************
	*/
	 
	BEGIN TRAN INSERT_DATA

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
		FROM prov.dbo.Provincia P
		
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

	BEGIN --RISKS
		BEGIN TRAN INSERT_RISKS
	
		SELECT r.COD_CIA, r.COD_RIES, NEWID() Id
		INTO #Risks
		FROM CiberSeguros.dbo.CIA_RIESGO r

		INSERT INTO Seggu.dbo.Risks (Id, Name, RiskType, CompanyId)
		SELECT r.Id, ri.DESCRIP, ri.cod_tiporiesgo, c.Id
		FROM #Risks r
		INNER JOIN CiberSeguros.dbo.RIESGO ri ON ri.codigo = r.COD_RIES
		INNER JOIN #Companies c ON c.CODIGO = r.COD_CIA

		COMMIT TRAN INSERT_RISKS
		PRINT 'RIESGOS IMPORTADOS'
	END

	--BEGIN --COVERAGE
	--	BEGIN TRAN INSERT_COVERAGES
	
	--	SELECT c.CODIGO COD_CUBRE, c.COD_RIESGO, cr.COD_CIA, NEWID() Id
	--	INTO #Coverages
	--	FROM CiberSeguros.dbo.Cubre c
	--	INNER JOIN #Risks cr ON c.COD_RIESGO = cr.COD_RIES
	
	--	INSERT INTO Seggu.dbo.Coverages (Id, Name, Description,	CoveragesPackId)
	--	SELECT co.Id, '', c.NOMBRE, r.Id
	--	FROM #Coverages co
	--	INNER JOIN CiberSeguros.dbo.Cubre c ON c.CODIGO = co.COD_CUBRE
	--	INNER JOIN #Risks r ON r.COD_CIA = co.COD_CIA AND r.COD_RIES = co.COD_RIESGO
	
	--	COMMIT TRAN INSERT_COVERAGES
	--	PRINT 'COBERTURAS IMPORTADAS'
	--END

	--BEGIN --COBERT AUTOS PASARLO A COVERAGE
	--	BEGIN TRAN INSERT_COBERAUTO
	
	--	SELECT ca.CODIGO, NEWID() Id, r.Id riskId, r.CompanyId CompanyId
	--	INTO #Covercars 
	--	FROM CiberSeguros.dbo.COBERT_AUTOS ca
	--	CROSS JOIN Seggu.dbo.Risks r WHERE r.Name LIKE 'AUTOMOTORES'

	--	--DECLARE @RISKID UNIQUEIDENTIFIER = (SELECT TOP 1 r.Id FROM Seggu.dbo.Risks r WHERE r.Description LIKE 'AUTOMOTORES')
	
	--	INSERT INTO Seggu.dbo.Coverages (Id, Name, Description, RiskId)
	--	SELECT cc.Id,ca.Nombre, ca.DESCRIP, cc.riskId
	--	FROM #Covercars cc
	--	INNER JOIN CiberSeguros.dbo.COBERT_AUTOS ca ON ca.CODIGO = cc.CODIGO

	--	COMMIT TRAN INSERT_COBERAUTO
	--	PRINT 'COBERT AUTO IMPORTADOS A COVERAGE'
	--END
		
	--BEGIN --COBERT OTROS PASARLO A COVERAGE
	--	BEGIN TRAN INSERT_COBEROTROS
	
	--	SELECT co.CODIGO COD_CUBRE, r.COD_CIA, co.COD_RIESGO, NEWID() Id
	--	INTO #CoverOthers
	--	FROM CiberSeguros.dbo.COBERT_OTROS co
	--	INNER JOIN #Risks r ON r.COD_RIES = co.COD_RIESGO
	
	--	INSERT INTO Seggu.dbo.Coverages (Id, Name, Description, RiskId)
	--	SELECT c.Id, ' ', ISNULL(co.DESCRIP,' '), R.Id
	--	FROM #CoverOthers c
	--	INNER JOIN CiberSeguros.dbo.COBERT_OTROS co ON co.CODIGO = c.COD_CUBRE
	--	INNER JOIN #Risks r ON r.COD_RIES = c.COD_RIESGO AND r.COD_CIA = c.COD_CIA

	--	COMMIT TRAN INSERT_COBEROTROS
	--	PRINT 'COBERT OTROS IMPORTADOS A COVERAGE'
	--END

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
