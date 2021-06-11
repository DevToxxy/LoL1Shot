CREATE PROCEDURE[dbo].[sp_ComboAdd]
    @name NVARCHAR (50),
    @actionList NVARCHAR (100),
    @championKey NVARCHAR (450),
	@killedByComboKeys NVARCHAR (1000),
    @comboID int OUTPUT
AS 
    INSERT INTO [dbo].[Combo](Name,ActionList,ChampionKey,killedByComboKeys)
	VALUES (@name,@actionList,@championKey,@killedByComboKeys)
    SET @comboID = @@IDENTITY