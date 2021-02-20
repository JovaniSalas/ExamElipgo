using Business_Entities.Northwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Repository
{
    public interface INorthwind
    {
        List<Country> GetCountries();
        List<Company> GetCompaniesByCountry(string country);
        List<Order> GetOrders(string cutomerId);
        bool InsertOrder(Order order);
    }
}
