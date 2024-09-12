CREATE OR ALTER PROCEDURE [dbo].[usp_DeleteUser]
@Id int
AS
BEGIN
	DELETE FROM [dbo].[Users] WHERE Id = @Id
END