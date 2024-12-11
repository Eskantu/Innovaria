CREATE PROCEDURE DeleteUser 
	@PkUser int
AS
BEGIN

	SET NOCOUNT ON;

	delete from Users where PkUser = @PkUser
END
