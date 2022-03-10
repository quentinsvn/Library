CREATE PROCEDURE [dbo].[Set_Movie]
    @Id int,
    @Title nvarchar(MAX),
    @Date datetime2,
    @ImageUrl nvarchar(MAX),
    @OutputId int OUTPUT
AS
BEGIN
    SET @OutputId = @Id

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