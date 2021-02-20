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
    public class ConsultOrder: IDataAccess
    {
        private string strgSqlConnection;
        public string country { get; set; }
        public ConsultOrder(string _country="")
        {
            this.strgSqlConnection = ConfigurationManager.ConnectionStrings["dbNorthwind"].ConnectionString;
            country = _country;
        }
        public List<Country> GetCountries()
        {
            List<Country> listCountry = new List<Country>();
            try
            {
                using (SqlConnection sc = new SqlConnection(this.strgSqlConnection))
                {
                    sc.Open();
                    SqlCommand command = new SqlCommand("ConsultCustomersCountry", sc);
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listCountry.Add(new Country()
                            {
                                Name = (string)reader["Country"]
                            });
                        }
                    }
                }
            }
            catch (Exception er)
            {
                throw new ArgumentException("-ERROR-When consulting Country data" + er.Message.ToString());
            }
            return listCountry;
        }

        public List<Company> GetCompanyByCountry()
        {
            List<Company> listCompany = new List<Company>();
            try
            {
                using (SqlConnection sc = new SqlConnection(this.strgSqlConnection))
                {
                    sc.Open();
                    SqlCommand command = new SqlCommand("ConsultCompanyByCountry", sc);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_Country", this.country);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listCompany.Add(new Company()
                            {
                                Id = (string)reader["CustomerID"],
                                CompanyName = (string)reader["CompanyName"],
                                ContactName = (string)reader["ContactName"]
                            });
                        }
                    }
                }
            }
            catch (Exception er)
            {
                throw new ArgumentException("-ERROR-When consulting Company by Country data" + er.Message.ToString());
            }
            return listCompany;
        }

        public List<Order> GetOrders(string customerId)
        {
            List<Order> listOrders = new List<Order>();
            try
            {
                using (SqlConnection sc = new SqlConnection(this.strgSqlConnection))
                {
                    sc.Open();
                    SqlCommand command = new SqlCommand("ConsultOrdersByCustomerID", sc);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_CustomerID", customerId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listOrders.Add(new Order()
                            {
                                Id = (int)reader["OrderID"],
                                CustomerID = (string)reader["CustomerID"],
                                FirstName = (string)reader["FirstName"],
                                OrderDate = (DateTime)reader["OrderDate"],
                                RequiredDate = (DateTime)reader["RequiredDate"],
                                ShipCity = (string)reader["ShipCity"],
                                Freight = (decimal)reader["Freight"]
                            });
                        }
                    }
                }
            }
            catch (Exception er)
            {
                throw new ArgumentException("-ERROR-When consulting Orders data" + er.Message.ToString());
            }
            return listOrders;
        }

        public bool Insert(Order order)
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
