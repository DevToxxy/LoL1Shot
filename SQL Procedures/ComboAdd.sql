CREATE PROCEDURE[dbo].[sp_ComboAdd]
    @name NVARCHAR (50),
    @actionList NVARCHAR (100),
    @championKey NVARCHAR (450),
    @comboID int OUTPUT
AS 
    INSERT INTO [dbo].[Combo](Name,ActionList,ChampionKey) VALUES (@name,@actionList,@championKey)
    SET @comboID = @@IDENTITY