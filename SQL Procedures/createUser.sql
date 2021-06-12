CREATE PROCEDURE [dbo].[sp_createUser]
    @username NVARCHAR (50),
    @email NVARCHAR (50),
    @password NVARCHAR (100),
    @userID int OUTPUT
AS 
    INSERT INTO [dbo].[User](Username,Email,Password) VALUES (@username,@email,@password)
    SET @userID = @@IDENTITY