-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
CREATE PROCEDURE AddLectura
	@PkSensor varchar(50),
	@Value decimal(18,2)
AS
BEGIN
	
	SET NOCOUNT ON;

    insert into lecturas(FkSensor,[value]) values(@PkSensor,@Value)
END
