CREATE OR ALTER PROCEDURE [dbo].[usp_GetMaincategoryById]
@Id int
AS
BEGIN 
	SELECT * FROM [dbo].[Maincategory] WHERE Id = @Id
END