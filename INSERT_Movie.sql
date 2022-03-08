DECLARE @newId int

-- Avatar
INSERT INTO Movie (Title, Date, ImageUrl) VALUES ('Avatar', '2009-12-16', 'http://fr.web.img3.acsta.net/medias/nmedia/18/64/43/65/19150275.jpg')
SET @newId = @@IDENTITY
INSERT INTO Link_MovieGenre VALUES (@newId, 1) -- action
INSERT INTO Link_MovieGenre VALUES (@newId, 2) -- aventure
INSERT INTO Link_MovieGenre VALUES (@newId, 8) -- fantastique

-- Full metal jacket
INSERT INTO Movie (Title, Date, ImageUrl) VALUES ('Full Metal Jacket', '1987-10-21', 'http://fr.web.img5.acsta.net/medias/nmedia/18/65/57/12/19254508.jpg')
SET @newId = @@IDENTITY
INSERT INTO Link_MovieGenre VALUES (@newId, 7) -- drame
INSERT INTO Link_MovieGenre VALUES (@newId, 16) -- guerre

-- Scarface
INSERT INTO Movie (Title, Date, ImageUrl) VALUES ('Scarface', '1984-3-7', 'http://fr.web.img3.acsta.net/medias/nmedia/18/35/23/36/18376641.jpg')
SET @newId = @@IDENTITY
INSERT INTO Link_MovieGenre VALUES (@newId, 7) -- drame
INSERT INTO Link_MovieGenre VALUES (@newId, 5) -- policier

-- Gladiator
INSERT INTO Movie (Title, Date, ImageUrl) VALUES ('Gladiator', '2000-6-20', 'http://fr.web.img6.acsta.net/r_1280_720/medias/nmedia/18/68/64/41/19254510.jpg')
SET @newId = @@IDENTITY
INSERT INTO Link_MovieGenre VALUES (@newId, 1) -- action
INSERT INTO Link_MovieGenre VALUES (@newId, 2) -- aventure
INSERT INTO Link_MovieGenre VALUES (@newId, 7) -- drame

-- Human Traffic
INSERT INTO Movie (Title, Date, ImageUrl) VALUES ('Human Traffic', '2000-6-14', 'https://media.senscritique.com/media/000007095036/source_big/Human_Traffic.jpg')
SET @newId = @@IDENTITY
INSERT INTO Link_MovieGenre VALUES (@newId, 4) -- comedie

-- Arnaques, crimes et botanique
INSERT INTO Movie (Title, Date, ImageUrl) VALUES ('Arnaques, crimes et botanique', '1998-10-28', 'http://fr.web.img6.acsta.net/medias/nmedia/18/60/07/87/18607605.jpg')
SET @newId = @@IDENTITY
INSERT INTO Link_MovieGenre VALUES (@newId, 4) -- comedie
INSERT INTO Link_MovieGenre VALUES (@newId, 5) -- policier

-- Snatch
INSERT INTO Movie (Title, Date, ImageUrl) VALUES ('Snatch', '2000-11-15', 'http://fr.web.img4.acsta.net/medias/03/28/61/032861_af.jpg')
SET @newId = @@IDENTITY
INSERT INTO Link_MovieGenre VALUES (@newId, 4) -- comedie
INSERT INTO Link_MovieGenre VALUES (@newId, 5) -- policier

-- Bernie
INSERT INTO Movie (Title, Date, ImageUrl) VALUES ('Bernie', '1996-11-27', 'http://fr.web.img5.acsta.net/r_1280_720/medias/nmedia/18/64/13/46/18754633.jpg')
SET @newId = @@IDENTITY
INSERT INTO Link_MovieGenre VALUES (@newId, 4) -- comedie

-- Dobermann
INSERT INTO Movie (Title, Date, ImageUrl) VALUES ('Dobermann', '1997-6-18', 'http://fr.web.img3.acsta.net/medias/nmedia/18/62/87/53/18656634.jpg')
SET @newId = @@IDENTITY
INSERT INTO Link_MovieGenre VALUES (@newId, 1) -- action
INSERT INTO Link_MovieGenre VALUES (@newId, 5) -- crime
INSERT INTO Link_MovieGenre VALUES (@newId, 15) -- thriller

-- Léon
INSERT INTO Movie (Title, Date, ImageUrl) VALUES ('Léon', '1994-9-14', 'http://fr.web.img6.acsta.net/r_1280_720/pictures/14/08/21/14/15/233032.jpg')
SET @newId = @@IDENTITY
INSERT INTO Link_MovieGenre VALUES (@newId, 5) -- policier
INSERT INTO Link_MovieGenre VALUES (@newId, 7) -- drame
INSERT INTO Link_MovieGenre VALUES (@newId, 15) -- thriller

-- Appaloosa
INSERT INTO Movie (Title, Date, ImageUrl) VALUES ('Appaloosa', '2008-10-1', 'http://fr.web.img6.acsta.net/medias/nmedia/18/66/88/65/18982297.jpg')
SET @newId = @@IDENTITY
INSERT INTO Link_MovieGenre VALUES (@newId, 5) -- policier
INSERT INTO Link_MovieGenre VALUES (@newId, 7) -- drame
INSERT INTO Link_MovieGenre VALUES (@newId, 17) -- western

-- Les bouchers verts
INSERT INTO Movie (Title, Date, ImageUrl) VALUES ('Les bouchers verts', '2005-1-26', 'http://fr.web.img2.acsta.net/medias/nmedia/18/35/49/73/18405167.jpg')
SET @newId = @@IDENTITY
INSERT INTO Link_MovieGenre VALUES (@newId, 4) -- comedie
INSERT INTO Link_MovieGenre VALUES (@newId, 7) -- drame

-- Insidious
INSERT INTO Movie (Title, Date, ImageUrl) VALUES ('Insidious', '2011-6-15', 'http://fr.web.img6.acsta.net/medias/nmedia/18/82/91/46/19720507.jpg')
SET @newId = @@IDENTITY
INSERT INTO Link_MovieGenre VALUES (@newId, 9) -- horreur
INSERT INTO Link_MovieGenre VALUES (@newId, 18) -- mystère
INSERT INTO Link_MovieGenre VALUES (@newId, 15) -- thriller

-- Pixels
INSERT INTO Movie (Title, Date, ImageUrl) VALUES ('Pixels', '2015-7-22', 'http://fr.web.img6.acsta.net/pictures/15/05/29/10/30/471024.jpg')
SET @newId = @@IDENTITY
INSERT INTO Link_MovieGenre VALUES (@newId, 1) -- action
INSERT INTO Link_MovieGenre VALUES (@newId, 4) -- comedie
INSERT INTO Link_MovieGenre VALUES (@newId, 19) -- famille

-- Mister Babadook
INSERT INTO Movie (Title, Date, ImageUrl) VALUES ('Mister Babadook', '2014-7-30', 'http://fr.web.img3.acsta.net/pictures/14/06/12/14/20/320768.jpg')
SET @newId = @@IDENTITY
INSERT INTO Link_MovieGenre VALUES (@newId, 7) -- drame
INSERT INTO Link_MovieGenre VALUES (@newId, 9) -- horreur

-- The Gentlemen
INSERT INTO Movie (Title, Date, ImageUrl) VALUES ('The Gentlemen', '2020-2-5', 'https://fr.web.img6.acsta.net/pictures/19/12/16/17/08/1716990.jpg')
SET @newId = @@IDENTITY
INSERT INTO Link_MovieGenre VALUES (@newId, 1) -- action
INSERT INTO Link_MovieGenre VALUES (@newId, 5) -- policier

