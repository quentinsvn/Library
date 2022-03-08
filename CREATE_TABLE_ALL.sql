CREATE TABLE [dbo].[Genre] 
(
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Genre] PRIMARY KEY ([Id])
)
GO

CREATE TABLE [dbo].[Movie]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [Title] NVARCHAR(MAX) NOT NULL, 
    [Date] DATETIME2 NULL,
    [ImageUrl] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_Movie] PRIMARY KEY ([Id])
)
GO

CREATE TABLE [dbo].[Link_MovieGenre] 
(
    [MovieId] INT NOT NULL,
    [GenreId] INT NOT NULL,
    CONSTRAINT [PK_Link_MovieGenre] PRIMARY KEY CLUSTERED ([MovieId] ASC, [GenreId] ASC),
    CONSTRAINT [FK_Link_MovieGenre_ToMovie] FOREIGN KEY ([MovieId]) 
		REFERENCES [dbo].[Movie] ([Id])
		ON DELETE CASCADE
		ON UPDATE CASCADE,
    CONSTRAINT [FK_Link_MovieGenre_ToGenre] FOREIGN KEY ([GenreId]) 
		REFERENCES [dbo].[Genre] ([Id])
		ON DELETE CASCADE
		ON UPDATE CASCADE
)
GO