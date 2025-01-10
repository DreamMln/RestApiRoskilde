CREATE TABLE [dbo].[Opgaver] (
    [BorgerOpgID]       INT           IDENTITY (1, 1) NOT NULL,
    [BorgerNavn]     VARCHAR (100) NULL,
    [ArbejdsOpgave]     VARCHAR (255) NULL,
    [OpgaveBeskrivelse] VARCHAR (255) NULL,
    [OpgStart]          DATE          NULL,
    [OpgSlut]           DATE          NULL,
    [ID]                INT           NULL,
    FOREIGN KEY ([ID]) REFERENCES [dbo].[Borgere] ([ID])
);