CREATE TABLE [dbo].[Users] (
    [PkUser]   INT          IDENTITY (1, 1) NOT NULL,
    [UserName] VARCHAR (50) NOT NULL,
    [Password] VARCHAR (50) NOT NULL,
    [Name]     VARCHAR (50) NOT NULL,
    [LastName] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([PkUser] ASC)
);

