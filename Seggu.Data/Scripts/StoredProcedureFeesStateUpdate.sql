CREATE PROCEDURE UpdateFeeStates
AS
BEGIN
BEGIN TRY

	PRINT('BEGIN TRAN')
	BEGIN TRAN UPDATE_STATES

	PRINT('VARIABLES')
	DECLARE @TODAY DATETIME = GETDATE()
	DECLARE @LAST_MONTH DATETIME = DATEADD(m, -1, @TODAY)
	PRINT('INSERT INTO #FechasCompany')
	SELECT
		c.Id Id,
		DATEFROMPARTS(DATEPART(year, @TODAY), DATEPART(month, @TODAY), c.PaymentDay1) PaymentDay1,
		DATEFROMPARTS(DATEPART(year, @TODAY), DATEPART(month, @TODAY), c.PaymentDay2) PaymentDay2,
		DATEFROMPARTS(DATEPART(year, @LAST_MONTH), DATEPART(month, @LAST_MONTH), c.PaymentDay1) PrevPaymentDay1
	INTO #FechasCompany
	FROM Companies c

	PRINT('INSERT INTO #FechasConvenioCompany')
	SELECT
		c.Id,
		CASE
			WHEN @TODAY < c.PaymentDay2 THEN c.PrevPaymentDay1
			WHEN @TODAY > c.PaymentDay1 THEN c.PaymentDay1
			ELSE c.PaymentDay2
		END PaymentDay
	INTO #FechasConvenioCompany
	FROM #FechasCompany c

	PRINT('BEGIN TRAN')
	DECLARE @SIN_COBERTURA INT = 7
	DECLARE @MOROSO INT = 6
	DECLARE @DEBE INT = 0

	PRINT('BEGIN TRAN')
	UPDATE f
	SET f.State = CASE
		WHEN c.PaymentDay < f.ExpirationDate THEN @SIN_COBERTURA
		ELSE @MOROSO
	END
	FROM Fees f
	INNER JOIN Policies p ON p.Id = f.PolicyId
	INNER JOIN Coverages cv ON cv.Id = p.CoverageId
	INNER JOIN Risks r ON r.Id = cv.RiskId
	INNER JOIN #FechasConvenioCompany c ON c.Id = r.CompanyId
	WHERE 
	f.ExpirationDate < @TODAY AND
	f.State = @DEBE AND
	f.Annulated = 0

	PRINT('BEGIN TRAN')
	UPDATE f
	SET f.State = CASE
		WHEN c.PaymentDay < f.ExpirationDate THEN @SIN_COBERTURA
		ELSE @MOROSO
	END
	FROM Fees f
	INNER JOIN Endorses e ON e.Id = f.PolicyId
	INNER JOIN Coverages cv ON cv.Id = e.CoverageId
	INNER JOIN Risks r ON r.Id = cv.RiskId
	INNER JOIN #FechasConvenioCompany c ON c.Id = r.CompanyId
	WHERE 
	f.ExpirationDate < @TODAY AND
	f.State = @DEBE AND
	f.Annulated = 0

	COMMIT TRAN UPDATE_STATES

END TRY
BEGIN CATCH

	IF @@TRANCOUNT > 0 ROLLBACK TRAN

	PRINT 'ERROR: LINE(' + CAST(ERROR_LINE() AS NVARCHAR(100)) + '), MESSAGE("' + ERROR_MESSAGE() + '")'

END CATCH
END