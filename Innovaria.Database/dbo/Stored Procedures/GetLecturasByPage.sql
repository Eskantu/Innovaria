CREATE PROCEDURE [dbo].[GetLecturasByPage]
@skip int
AS
BEGIN
	
	SET NOCOUNT ON;
	declare @take int;
	select @take = CAST([value] as int) from properties where [Name] = 'ItemsByPage'
    
	select L.FkSensor, [name], L.PkLectura, L.[Value] from Lecturas L 
	INNER JOIN Sensores S ON S.PkSensor = L.FkSensor
	order by [name] 
	offset @skip ROWS
	FETCH NEXT @take ROWS ONLY
END
