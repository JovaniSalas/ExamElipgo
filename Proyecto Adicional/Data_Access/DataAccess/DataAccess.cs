using Business_Entities.Northwind;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DataAccess
{
    public class DataAccess : IDataAccess
    {
        IDataAccess dataAccess;

        public DataAccess(IDataAccess _dataAccess)
        {
            this.dataAccess = _dataAccess;
        }

        public List<Country> GetCountries()
        {
            return this.dataAccess.GetCountries();
        }

        public List<Company> GetCompanyByCountry()
        {
             return this.dataAccess.GetCompanyByCountry();
        }

        public List<Order> GetOrders(string customerId)
        {
            return this.dataAccess.GetOrders(customerId);
        }

        public bool Insert(Order order)
        {
            return this.dataAccess.Insert(order);
        }
        public bool Update(Order order)
        {
            return this.dataAccess.Update(order);
        }

        public bool DeleteOrders(List<Order> orders)
        {
            throw new NotImplementedException();
        }
    }
}
