USE [Northwind]
GO
CREATE PROCEDURE UpdateOrder
(
 @p_OrderID As int,
 @p_Freight As money
)
AS
Begin	
	UPDATE [dbo].[Orders] SET Freight=@p_Freight WHERE OrderID =@p_OrderID
END