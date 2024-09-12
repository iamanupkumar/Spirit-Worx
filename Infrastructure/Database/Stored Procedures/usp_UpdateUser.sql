CREATE OR ALTER PROCEDURE [dbo].[usp_UpdateUser]
@Id int,
@FirstName varchar(50),
@LastName	varchar(50),
@EmailId	varchar(100),
@MobileNo	varchar(15),
@Password	varchar(100),
@Role		int
AS
BEGIN
	UPDATE [dbo].[Users] SET 
	FirstName = @FirstName,
	LastName = @LastName,
	EmailId = @EmailId,
	MobileNo = @MobileNo,
	Password = @Password,
	Role = @Role
	WHERE Id = @Id
END