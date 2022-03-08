CREATE PROCEDURE [dbo].[Set_Movie]
	@Id int,
	@Title nvarchar(MAX),
	@Date datetime2,
	@ImageUrl nvarchar(MAX),
	@OutputId int OUTPUT
AS
BEGIN
    SET @OutputId = -1
    
	IF (@Id > -1)
	BEGIN
		UPDATE Movie
		SET Title = @Title,
		[Date] = @Date,
		ImageUrl = @ImageUrl
		WHERE Id = @Id

        IF @@ROWCOUNT > 0
        BEGIN
		    SET @OutputId = @Id
		END
	END
	ELSE
	BEGIN
		INSERT Movie (Title, [Date], ImageUrl)
		VALUES (@Title, @Date, @ImageUrl)

		SET @OutputId = @@IDENTITY
	END
END
GO


CREATE PROCEDURE [dbo].[Set_Genre]
	@Id int,
	@Name nvarchar(MAX),
	@OutputId int OUTPUT
AS
BEGIN
    SET @OutputId = -1
    
	IF (@id > -1)
	BEGIN
		UPDATE Genre
		SET Name = @Name
		WHERE Id = @Id

        IF @@ROWCOUNT > 0
        BEGIN
		    SET @OutputId = @Id
		END
	END
	ELSE
	BEGIN
		INSERT Genre (Name)
		VALUES (@Name)

		SET @OutputId = @@IDENTITY
	END
END
GO


CREATE PROCEDURE [dbo].[Set_Link_MovieGenre]
	@MovieId int,
	@GenreId int
AS
BEGIN
	INSERT Link_MovieGenre
	VALUES (@MovieId, @GenreId)
END
GO


CREATE PROCEDURE [dbo].[Delete_Movie_ById]
	@Id int
AS
BEGIN
	DELETE Movie
	WHERE Id = @Id
END
GO


CREATE PROCEDURE [dbo].[Delete_Genre_ById]
	@Id int
AS
BEGIN
	DELETE Genre
	WHERE Id = @Id
END
GO


CREATE PROCEDURE [dbo].[Delete_Link_MovieGenre_ByMovieId]
	@MovieId int
AS
BEGIN
	DELETE Link_MovieGenre
	WHERE MovieId = @MovieId
END
GO


CREATE PROCEDURE [dbo].[Get_Movie_ById]
	@Id int
AS
BEGIN
	SELECT *
	FROM Movie
	WHERE id = @id
END
GO


CREATE PROCEDURE [dbo].[Get_Genre_ById]
	@Id int
AS
BEGIN
	SELECT *
	FROM Genre
	WHERE id = @id
END
GO


CREATE PROCEDURE [dbo].[Get_Genre_ByMovieId]
	@movieId int
AS
BEGIN
	SELECT Genre.*
	FROM Genre
	INNER JOIN Link_MovieGenre
		ON Link_MovieGenre.GenreId = Genre.Id
	WHERE Link_MovieGenre.MovieId = @movieId
END
GO


CREATE PROCEDURE [dbo].[Get_Movie_ByGenreId]
	@genreId int
AS
BEGIN
	SELECT Movie.*
	FROM Movie
	INNER JOIN Link_MovieGenre
		ON Link_MovieGenre.MovieId = Movie.Id
	WHERE Link_MovieGenre.GenreId = @genreId
END
GO


CREATE PROCEDURE [dbo].[Get_Movie_All]
AS
BEGIN
	SELECT *
	FROM Movie
END
GO


CREATE PROCEDURE [dbo].[Get_Genre_All]
AS
BEGIN
	SELECT *
	FROM Genre
END
GO