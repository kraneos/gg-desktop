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
