CREATE PROCEDURE [dbo].[sp_ComboUpdate]
    @name NVARCHAR (50),
    @actionList NVARCHAR (100),
    @championKey NVARCHAR (450),
	@killedByComboKeys NVARCHAR (1000),
    @comboID int 
AS
    UPDATE [dbo].[Combo] 
    SET Name = @name,
		ActionList = @actionList,
		ChampionKey = @championKey,
		killedByComboKeys = @killedByComboKeys
    WHERE Id = @comboID