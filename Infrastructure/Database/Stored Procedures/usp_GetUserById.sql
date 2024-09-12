CREATE OR ALTER PROCEDURE [dbo].[usp_GetUserById]
@Id int
AS
BEGIN
	SELECT * FROM [dbo].[Users] WHERE Id = @Id
END