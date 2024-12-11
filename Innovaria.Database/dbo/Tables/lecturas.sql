CREATE TABLE [dbo].[lecturas] (
    [PkLectura] INT             IDENTITY (1, 1) NOT NULL,
    [FkSensor]  INT             NOT NULL,
    [Value]     DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_lecturas] PRIMARY KEY CLUSTERED ([PkLectura] ASC),
    CONSTRAINT [FK_lecturas_lecturas] FOREIGN KEY ([PkLectura]) REFERENCES [dbo].[lecturas] ([PkLectura])
);

