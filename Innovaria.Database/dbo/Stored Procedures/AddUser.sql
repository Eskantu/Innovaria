CREATE PROCEDURE AddUser 
	@userName varchar(50),
	@password varchar(50),
	@name varchar(50),
	@lastName varchar(50)
AS
BEGIN
	SET NOCOUNT ON;

    insert into Users(UserName,Password,Name,LastName) values(@userName,@password,@name,@lastName)
END
