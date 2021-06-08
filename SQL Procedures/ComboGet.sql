CREATE PROCEDURE [dbo].[sp_ComboGet]
    @comboID int
AS
    SELECT Id,Name,ActionList, ChampionKey FROM Combo where Id = @comboID