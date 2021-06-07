CREATE PROCEDURE [dbo].[sp_ComboDelete]
    @comboID int
AS
    DELETE FROM [dbo].[Combo] 
    WHERE Id = @comboID