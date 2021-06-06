CREATE PROCEDURE[dbo].[sp_ComboAdd]
    @name NCHAR (50),
    @actionList NCHAR (100),
    @championKey NVARCHAR (450),
    @comboID int OUTPUT
AS 
    INSERT INTO [dbo].[Combo](Name,ActionList,ChampionKey) VALUES (@name,@actionList,@championKey)
    SET @comboID = @@IDENTITY