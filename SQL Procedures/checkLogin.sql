CREATE PROCEDURE [dbo].[sp_checkLogin]
    @username NVARCHAR (50),
    @password NVARCHAR (100) OUTPUT
AS
    SET @password = (SELECT Password
                    FROM [dbo].[User]
                    WHERE @username = Username COLLATE Latin1_General_CS_AS)