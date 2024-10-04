IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Maincategory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Maincategory](
	[Id]		[bigint] IDENTITY NOT NULL,

    [Name] [varchar](100)	NOT NULL,        

	[IsActive]	[bit] NOT NULL	DEFAULT 1,
	[IsDeleted] [bit] NOT NULL	DEFAULT 0,

	[CreatedBy] [bigint]	NOT NULL	DEFAULT -1,
	[CreatedOn] [datetime2] NOT NULL	DEFAULT GETUTCDATE(),
	[UpdatedBy] [bigint]	NOT NULL	DEFAULT -1,
	[UpdatedOn] [datetime2] NOT NULL	DEFAULT GETUTCDATE(),
	
    CONSTRAINT PK_Maincategory PRIMARY KEY CLUSTERED ([Id] ASC) ON [PRIMARY],
    CONSTRAINT CK_Maincategory_Name CHECK (LEN([Name]) >= 1 AND LEN([Name]) <= 100)     
) 
END
GO

SELECT * FROM [dbo].[Maincategory]