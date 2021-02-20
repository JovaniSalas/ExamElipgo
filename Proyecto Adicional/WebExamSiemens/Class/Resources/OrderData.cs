using Business_Logic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExamSiemens.Class.Interface;
using WebExamSiemens.Models;

namespace WebExamSiemens.Class.Resources
{
    public class OrderData : IOrderData
    {        
        readonly INorthwind repNorthwind = new Northwind();
        private string customer;
        public OrderData(string _customer)
        {
            this.customer = _customer;
        }

        public CatalogModel GetOrderByCompany()
        {
            CatalogModel orderModels = new CatalogModel();
            try
            {
                orderModels.Orders = repNorthwind.GetOrders(this.customer);
            }
            catch (Exception er)
            {
                orderModels.Error = er.Message;
                orderModels.ExistError = true;
            }            
            return orderModels;
        }
    }
}