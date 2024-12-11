-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
CREATE PROCEDURE GetAllSensores
AS
BEGIN
	
	SET NOCOUNT ON;

    select [name] from sensores
END
