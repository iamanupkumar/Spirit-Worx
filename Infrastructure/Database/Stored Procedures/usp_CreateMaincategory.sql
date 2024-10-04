CREATE OR ALTER PROCEDURE [dbo].[usp_CreateMaincategory]
@Name varchar(100),
@IsActive bit 
AS
BEGIN 
	INSERT INTO [dbo].[Maincategory] (Name,IsActive) VALUES(@Name,@IsActive)
END
