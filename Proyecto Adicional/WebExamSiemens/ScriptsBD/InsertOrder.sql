USE [Northwind]
GO
CREATE PROCEDURE InsertOrder
 (
 @p_CustomerID As nchar(5), 
 @p_EmployeeID As int, 
 @p_OrderDate As datetime, 
 @p_RequiredDate As datetime, 
 @p_ShippedDate As datetime,  
 @p_Freight As money,  
 @p_ShipCity As nvarchar(15),
 @p_ProductID As int, 
 @p_UnitPrice As money, 
 @p_Quantity As smallint,
 @p_Discount As real
 )
 AS
 BEGIN	
	BEGIN TRANSACTION;
	SAVE TRANSACTION SaveOrder;
	BEGIN TRY
		DECLARE @p_OrderId As int;
		INSERT INTO [dbo].[Orders] (CustomerID, EmployeeID, OrderDate,  RequiredDate,  ShippedDate, Freight,   ShipCity)
		VALUES (@p_CustomerID, @p_EmployeeID, @p_OrderDate, @p_RequiredDate,  @p_ShippedDate,  @p_Freight,  @p_ShipCity);
		SET @p_OrderId =(SELECT @@IDENTITY)
		INSERT INTO [dbo].[Order Details] (OrderID, ProductID, UnitPrice, Quantity, Discount) 
		VALUES(@p_OrderId, @p_ProductID , @p_UnitPrice,  @p_Quantity, @p_Discount); 
		COMMIT TRANSACTION;
	END TRY
    BEGIN CATCH
		ROLLBACK TRANSACTION SaveOrder;
		Select 'Error to save order';
	END CATCH
END
GO
