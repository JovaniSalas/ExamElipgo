using Business_Entities.Northwind;
using Business_Logic.Repository;
using Data_Access.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Repository
{
    public class Northwind : INorthwind
    {
        private DataAccess dataAccess;
        public List<Country> GetCountries()
        {
            this.dataAccess = new DataAccess(new ConsultOrder());
            return dataAccess.GetCountries();
        }

        public List<Company> GetCompaniesByCountry(string country)
        {
            this.dataAccess = new DataAccess(new ConsultOrder(country));
            if (string.IsNullOrEmpty(country))
                throw new ArgumentException("The value country is requiered.");
            return this.dataAccess.GetCompanyByCountry();
        }

        public List<Order> GetOrders(string cutomerId)
        {
            this.dataAccess = new DataAccess(new ConsultOrder());
            if (string.IsNullOrEmpty(cutomerId))
                throw new ArgumentException("The value client is requiered.");
            return dataAccess.GetOrders(cutomerId);
        }

        public bool InsertOrder(Order order)
        {
            this.dataAccess = new DataAccess(new InsertOrder());
            var orderdate = order.OrderDate;
            order.ShippedDate = orderdate.AddDays(5);
            order.EmployeeID = 5;
            order.ProductID = 3;
            order.UnitPrice = (decimal)75.5;
            order.Quantity = 40;
            order.Discount = (decimal)0.12;
            return  dataAccess.Insert(order);
        }

    }
}
