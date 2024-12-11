CREATE TABLE [dbo].[Sensores] (
    [PkSensor] INT          IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Sensores] PRIMARY KEY CLUSTERED ([PkSensor] ASC)
);

