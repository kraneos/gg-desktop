USE [msdb]
GO

/****** Object:  Job [UpdateFeeStates]    Script Date: 5/11/2014 7:55:27 PM ******/
BEGIN TRANSACTION
DECLARE @ReturnCode INT
SELECT @ReturnCode = 0
/****** Object:  JobCategory [Database Maintenance]    Script Date: 5/11/2014 7:55:27 PM ******/
IF NOT EXISTS (SELECT name FROM msdb.dbo.syscategories WHERE name=N'Database Maintenance' AND category_class=1)
BEGIN
EXEC @ReturnCode = msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'Database Maintenance'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

END

DECLARE @jobId BINARY(16)
EXEC @ReturnCode =  msdb.dbo.sp_add_job @job_name=N'UpdateFeeStates', 
		@enabled=1, 
		@notify_level_eventlog=0, 
		@notify_level_email=0, 
		@notify_level_netsend=0, 
		@notify_level_page=0, 
		@delete_level=0, 
		@description=N'No description available.', 
		@category_name=N'Database Maintenance', 
		@owner_login_name=N'POLOAGUSTINASUS\poloagustin', @job_id = @jobId OUTPUT
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [Execute]    Script Date: 5/11/2014 7:55:28 PM ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'Execute', 
		@step_id=1, 
		@cmdexec_success_code=0, 
		@on_success_action=1, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'BEGIN TRY

	PRINT(''BEGIN TRAN'')
	BEGIN TRAN UPDATE_STATES

	PRINT(''VARIABLES'')
	DECLARE @TODAY DATETIME = GETDATE()
	DECLARE @LAST_MONTH DATETIME = DATEADD(m, -1, @TODAY)
	PRINT(''INSERT INTO #FechasCompany'')
	SELECT
		c.Id Id,
		DATEFROMPARTS(DATEPART(year, @TODAY), DATEPART(month, @TODAY), c.PaymentDay1) PaymentDay1,
		DATEFROMPARTS(DATEPART(year, @TODAY), DATEPART(month, @TODAY), c.PaymentDay2) PaymentDay2,
		DATEFROMPARTS(DATEPART(year, @LAST_MONTH), DATEPART(month, @LAST_MONTH), c.PaymentDay1) PrevPaymentDay1
	INTO #FechasCompany
	FROM Companies c

	PRINT(''INSERT INTO #FechasConvenioCompany'')
	SELECT
		c.Id,
		CASE
			WHEN @TODAY < c.PaymentDay2 THEN c.PrevPaymentDay1
			WHEN @TODAY > c.PaymentDay1 THEN c.PaymentDay1
			ELSE c.PaymentDay2
		END PaymentDay
	INTO #FechasConvenioCompany
	FROM #FechasCompany c

	PRINT(''BEGIN TRAN'')
	DECLARE @SIN_COBERTURA INT = 7
	DECLARE @MOROSO INT = 6
	DECLARE @DEBE INT = 0

	PRINT(''BEGIN TRAN'')
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

	PRINT(''BEGIN TRAN'')
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

	PRINT ''ERROR: LINE('' + CAST(ERROR_LINE() AS NVARCHAR(100)) + ''), MESSAGE("'' + ERROR_MESSAGE() + ''")''

END CATCH
', 
		@database_name=N'Seggu', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_update_job @job_id = @jobId, @start_step_id = 1
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobschedule @job_id=@jobId, @name=N'MidNight', 
		@enabled=1, 
		@freq_type=64, 
		@freq_interval=0, 
		@freq_subday_type=0, 
		@freq_subday_interval=0, 
		@freq_relative_interval=0, 
		@freq_recurrence_factor=0, 
		@active_start_date=20140511, 
		@active_end_date=99991231, 
		@active_start_time=0, 
		@active_end_time=235959, 
		@schedule_uid=N'd8aea480-e97d-48f8-bcbd-f3f9cdbeff37'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @jobId, @server_name = N'(local)'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
COMMIT TRANSACTION
GOTO EndSave
QuitWithRollback:
    IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION
EndSave:

GO


