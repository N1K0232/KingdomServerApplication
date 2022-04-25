CREATE TABLE [dbo].[ServerLogs] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [IdUser]           UNIQUEIDENTIFIER NOT NULL,
    [Title]            NVARCHAR (100)   NOT NULL,
    [Description]      NVARCHAR (512)   NOT NULL,
    [LogDate]          DATETIME         NOT NULL,
    [LogType]          NVARCHAR (25)    NOT NULL,
    [CreatedDate]      DATETIME         NOT NULL,
    [LastModifiedDate] DATETIME         NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([IdUser]) REFERENCES [dbo].[Users] ([Id])
);

