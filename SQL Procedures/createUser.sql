CREATE PROCEDURE [dbo].[sp_createUser]
    @username NCHAR (50),
    @email NCHAR (50),
    @password NCHAR (100),
    @userID int OUTPUT
AS 
    INSERT INTO [dbo].[User](Username,Email,Password) VALUES (@username,@email,@password)
    SET @userID = @@IDENTITY