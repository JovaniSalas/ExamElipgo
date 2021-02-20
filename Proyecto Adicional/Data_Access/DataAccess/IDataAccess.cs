using Business_Entities.Northwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DataAccess
{
    public interface IDataAccess
    {
        List<Country> GetCountries();
        List<Company> GetCompanyByCountry();
        List<Order> GetOrders(string customerId);
        bool Insert(Order order);
        bool Update(Order order);
        bool DeleteOrders(List<Order> orders);
    }
}
