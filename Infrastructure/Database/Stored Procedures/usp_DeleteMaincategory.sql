CREATE OR ALTER PROCEDURE [dbo].[usp_DeleteMaincategory]
@Id int
AS
BEGIN 
	DELETE FROM [dbo].[Maincategory] WHERE Id = @Id
END