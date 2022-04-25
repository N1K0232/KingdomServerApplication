CREATE TABLE [dbo].[Users] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [IdRole]           UNIQUEIDENTIFIER NOT NULL,
    [UserName]         NVARCHAR (100)   NOT NULL,
    [ServerUserName]   NVARCHAR (100)   NOT NULL,
    [CreatedDate]      DATETIME         NOT NULL,
    [LastModifiedDate] DATETIME         NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([IdRole]) REFERENCES [dbo].[Roles] ([Id])
);

