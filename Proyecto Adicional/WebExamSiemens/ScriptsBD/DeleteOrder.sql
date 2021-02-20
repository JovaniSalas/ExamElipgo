USE [Northwind]
GO
CREATE PROCEDURE DeleteOrder
(
 @p_OrderID As int
)
AS
BEGIN
	BEGIN TRANSACTION;
	SAVE TRANSACTION SaveOrder;
	BEGIN TRY
		DELETE FROM [dbo].[Order Details] WHERE OrderID =@p_OrderID;
		DELETE FROM [dbo].[Orders] WHERE OrderID =@p_OrderID;
		COMMIT TRANSACTION;
	END TRY
    BEGIN CATCH
		ROLLBACK TRANSACTION SaveOrder;
		Select 'Error to delete order';
	END CATCH
END
GO