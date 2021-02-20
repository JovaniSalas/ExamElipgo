USE [Northwind]
GO
CREATE PROCEDURE ConsultOrdersByCustomerID
@p_CustomerID AS nchar(5)
AS
Begin
	SELECT TOP 10 
		o.OrderID,
		o.CustomerID,
		e.FirstName,
		o.OrderDate,  
		o.RequiredDate,
		o.ShipCity, 
		o.Freight
	FROM [dbo].[Orders] AS o 
	Inner Join Employees AS e
	ON e.EmployeeID =o.EmployeeID
	WHERE o.CustomerID =@p_CustomerID
	ORDER BY o.OrderDate DESC
END