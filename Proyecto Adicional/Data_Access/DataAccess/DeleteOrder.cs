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
    public class DeleteOrder: IDataAccess
    {
        private string strgSqlConnection;
        public DeleteOrder()
        {
            this.strgSqlConnection = ConfigurationManager.ConnectionStrings["dbNorthwind"].ConnectionString;
        }

        public bool DeleteOrders(List<Order> orders)
        {
            bool isDelete = false;
            try
            {
                using (SqlConnection sc = new SqlConnection(this.strgSqlConnection))
                {
                    sc.Open();
                    foreach (var order in orders)
                    {
                        using (SqlCommand command = new SqlCommand("UpdateOrder", sc))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@p_OrderID", order.Id);
                            command.ExecuteNonQuery();
                        }
                    }
                    isDelete = true;
                }
            }
            catch (Exception er)
            {
                throw new ArgumentException("-ERROR- to delete orders" + er.Message.ToString());
            }
            return isDelete;
        }

        public List<Company> GetCompanyByCountry()
        {
            throw new NotImplementedException();
        }

        public List<Country> GetCountries()
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrders(string customerId)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Order order)
        {
            throw new NotImplementedException();
        }

        public bool Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
