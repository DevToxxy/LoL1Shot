CREATE PROCEDURE [dbo].[sp_ComboList]
AS
    SELECT Id,Name,ActionList,ChampionKey, killedByComboKeys FROM Combo