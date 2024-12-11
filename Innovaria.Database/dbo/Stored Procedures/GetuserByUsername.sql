CREATE PROCEDURE GetuserByUsername 
	@UserName varchar(50)
AS
BEGIN

	SET NOCOUNT ON;

	select top 1  * from Users
END
