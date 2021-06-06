CREATE PROCEDURE [dbo].[sp_ComboUpdate]
    @name NCHAR (50),
    @actionList NCHAR (100),
    @championKey NVARCHAR (450),
    @comboID int 
AS
    UPDATE [dbo].[Combo] 
    SET Name = @name, ActionList = @actionList, ChampionKey = @championKey
    WHERE Id = @comboID
