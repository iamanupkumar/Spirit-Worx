CREATE OR ALTER PROCEDURE [dbo].[usp_UpdateMaincategory]
@Id int,
@Name varchar(100),
@IsActive bit 
AS
BEGIN 
	UPDATE 
	[dbo].[Maincategory]
	SET [Name] = @Name,
	IsActive = @IsActive
	WHERE Id = @Id
END


