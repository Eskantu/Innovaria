
CREATE PROCEDURE GetPropertyByPropertyName
	@Propertyname varchar(50)
AS
BEGIN
	SET NOCOUNT ON;

    select  top 1 [Name],[Value] from Properties where [Name] = @Propertyname 
END
