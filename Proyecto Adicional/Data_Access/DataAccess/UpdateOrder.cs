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
    public class UpdateOrder : IDataAccess
    {
        private string strgSqlConnection;
        public UpdateOrder()
        {
            this.strgSqlConnection = ConfigurationManager.ConnectionStrings["dbNorthwind"].ConnectionString;
        }

        public bool Update(Order order)
        {
            bool isUpdate=false;
            try
            {
                using (SqlConnection sc = new SqlConnection(this.strgSqlConnection))
                {
                    sc.Open();
                    using (SqlCommand command = new SqlCommand("UpdateOrder", sc))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_OrderID", order.Id);
                        command.Parameters.AddWithValue("@p_Freight", order.Freight);
                        command.ExecuteNonQuery();
                        isUpdate = true;
                    }
                }                
            }
            catch (Exception er)
            {
                throw new ArgumentException("-ERROR- to update order" + er.Message.ToString());
            }
            return isUpdate;
        }

        public List<Country> GetCountries()
        {
            throw new NotImplementedException();
        }
        public List<Company> GetCompanyByCountry()
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

        public bool DeleteOrders(List<Order> orders)
        {
            throw new NotImplementedException();
        }
    }
}
