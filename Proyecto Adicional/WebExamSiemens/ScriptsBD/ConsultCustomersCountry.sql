USE [Northwind]
GO
CREATE PROCEDURE ConsultCustomersCountry 
AS
Begin
	SELECT
		DISTINCT
		c.Country 
	FROM 
	[dbo].[Customers] As c
END