CREATE OR ALTER PROCEDURE [dbo].[usp_RegisterUser]
@FirstName varchar(50),
@LastName	varchar(50),
@EmailId	varchar(100),
@MobileNo	varchar(15),
@Password	varchar(100),
@Role		int
AS
BEGIN
	INSERT INTO [dbo].[Users](FirstName,LastName,EmailId,MobileNo,Password,Role) VALUES(@FirstName,@LastName,@EmailId,@MobileNo,@Password,@Role)
END