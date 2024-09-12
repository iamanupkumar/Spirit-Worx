IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[Id]		[bigint] IDENTITY NOT NULL,

    [FirstName] [varchar](50)	NOT NULL,
    [LastName]	[varchar](50)	NOT NULL,
    [EmailId]	[varchar](100)	NOT NULL,
    [MobileNo]	[varchar](15)	NOT NULL,
    [Password]	[varchar](100)	NOT NULL,
    [Role]		[int]			NOT NULL,        

	[IsActive]	[bit] NOT NULL	DEFAULT 1,
	[IsDeleted] [bit] NOT NULL	DEFAULT 0,

	[CreatedBy] [bigint]	NOT NULL	DEFAULT -1,
	[CreatedOn] [datetime2] NOT NULL	DEFAULT GETUTCDATE(),
	[UpdatedBy] [bigint]	NOT NULL	DEFAULT -1,
	[UpdatedOn] [datetime2] NOT NULL	DEFAULT GETUTCDATE(),
	
    CONSTRAINT PK_Users PRIMARY KEY CLUSTERED ([Id] ASC) ON [PRIMARY],
    CONSTRAINT CK_Users_FirstName CHECK (LEN([FirstName]) >= 1 AND LEN([FirstName]) <= 50),
    CONSTRAINT CK_Users_LastName CHECK (LEN([LastName]) >= 1 AND LEN([LastName]) <= 50),
    CONSTRAINT CK_Users_EmailId CHECK (LEN([EmailId]) >= 5 AND LEN([EmailId]) <= 100),
    CONSTRAINT UQ_Users_EmailId UNIQUE ([EmailId]),
    CONSTRAINT CK_Users_MobileNo CHECK (LEN([MobileNo]) >= 10 AND LEN([MobileNo]) <= 15),
    CONSTRAINT CK_Users_Password CHECK (LEN([Password]) >= 6 AND LEN([Password]) <= 100),
    CONSTRAINT CK_Users_Role CHECK ([Role] IN (1, 2)),   
) 
END
GO
