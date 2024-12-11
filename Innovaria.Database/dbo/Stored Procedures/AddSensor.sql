-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
CREATE PROCEDURE AddSensor 
	@name varchar(50)
AS
BEGIN
	
	SET NOCOUNT ON;

    insert into Sensores([Name]) values(@name)
END
