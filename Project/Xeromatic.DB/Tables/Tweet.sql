CREATE TABLE [dbo].[Tweet]
(
    [Id]    INT             IDENTITY (1, 1) NOT NULL,
    [Text]  NVARCHAR(140)   NOT NULL

    CONSTRAINT [PK_Subscription] PRIMARY KEY CLUSTERED ([Id] ASC)
)
