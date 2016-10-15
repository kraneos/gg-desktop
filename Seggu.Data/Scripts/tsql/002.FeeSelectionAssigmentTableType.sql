USE Seggu
GO
CREATE TYPE FeeSelectionAssigmentTable AS TABLE (
	Id UNIQUEIDENTIFIER NOT NULL,
	FeeSelectionId UNIQUEIDENTIFIER NULL,
	Status INT NOT NULL
)
GO

CREATE PROCEDURE FeeSelectionAssignment
	@FeesToUpdate FeeSelectionAssigmentTable READONLY
AS
BEGIN
	UPDATE f
	SET 
		f.FeeSelectionId = ftu.FeeSelectionId,
		f.State = ftu.Status
	FROM Fees f
	INNER JOIN @FeesToUpdate ftu ON ftu.Id = f.Id
END
GO

INSERT INTO [dbo].[Users]
           ([Id]
           ,[Username]
           ,[Password]
           ,[Role])
     VALUES
           (NEWID()
           ,'admin'
           ,'admin'
           ,0)
GO
