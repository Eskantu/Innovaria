CREATE PROCEDURE GetAllUser 
AS
BEGIN

	SET NOCOUNT ON;

	select U.PkUser, U.UserName, U.Password, U.Name, U.LastName from Users U
END
