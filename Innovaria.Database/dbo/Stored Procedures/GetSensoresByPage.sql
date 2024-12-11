-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
CREATE PROCEDURE [dbo].[GetSensoresByPage]
@skip int
AS
BEGIN
	
	SET NOCOUNT ON;
	declare @take int;
	select @take = CAST([value] as int) from properties where [Name] = 'ItemsByPage'
    
	select PkSensor, [name] from sensores order by [name] 
	offset @skip ROWS
	FETCH NEXT @take ROWS ONLY
END
