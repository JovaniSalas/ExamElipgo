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
    public class InsertOrder: IDataAccess
    {
        private string strgSqlConnection;
        public InsertOrder()
        {
            this.strgSqlConnection = ConfigurationManager.ConnectionStrings["dbNorthwind"].ConnectionString;
        }

        public bool Insert(Order order)
        {
            bool isSaved = false;
            try
            {
                using (SqlConnection sc = new SqlConnection(this.strgSqlConnection))
                {
                    sc.Open();
                    using (SqlCommand command = new SqlCommand("InsertOrder", sc))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@p_CustomerID", order.CustomerID);
                        command.Parameters.AddWithValue("@p_EmployeeID", order.EmployeeID);
                        command.Parameters.AddWithValue("@p_OrderDate", order.OrderDate);
                        command.Parameters.AddWithValue("@p_RequiredDate", order.RequiredDate);
                        command.Parameters.AddWithValue("@p_ShippedDate", order.ShippedDate);
                        command.Parameters.AddWithValue("@p_Freight", order.Freight);
                        command.Parameters.AddWithValue("@p_ShipCity", order.ShipCity);
                        command.Parameters.AddWithValue("@p_ProductID", order.ProductID);
                        command.Parameters.AddWithValue("@p_UnitPrice", order.UnitPrice);
                        command.Parameters.AddWithValue("@p_Quantity", order.Quantity);
                        command.Parameters.AddWithValue("@p_Discount", order.Discount);
                        command.ExecuteNonQuery();
                        isSaved = true;
                    }
                }
            }
            catch (Exception er)
            {
                throw new ArgumentException("-ERROR- to save order" + er.Message.ToString());
            }
            return isSaved;
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

        public bool Update(Order order)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrders(List<Order> orders)
        {
            throw new NotImplementedException();
        }
    }
}
