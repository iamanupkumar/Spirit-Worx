CREATE OR ALTER Procedure [dbo].[usp_UserLogin]
	@Email			Varchar(100),
	@Password		Varchar(100)
AS
BEGIN
	SELECT Id, FirstName, LastName, EmailId
		FROM Users
		WHERE IsDeleted=0 and IsActive=1 and EmailId=@Email AND [Password]=@Password
END


