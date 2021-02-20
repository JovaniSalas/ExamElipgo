using Business_Entities.Northwind;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExamSiemens.Class.Catalogs;
using WebExamSiemens.Class.Interface;
using WebExamSiemens.Class.Resources;
using WebExamSiemens.Models;

namespace WebExamSiemens.Controllers
{
    public class OrdersController : Controller
    {
        
        // GET: Orders
        public ActionResult Index()
        {
            var objec = new CatalogModel();
            ICatalogItem catalogItem = new CatalogItem(new Countries());
            objec.Countries= catalogItem.GetValues();
            return View(objec);
        }

        [HttpGet]
        public JsonResult GetCompanies(string country)
        {
            ICatalogItem catalog = new CatalogItem(new Companies(country));
            var objCompanies = catalog.GetCompanies();
            return Json(objCompanies, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetOrders(string customer)
        {
            IOrderData orderData = new OrderData(customer);
            var objOrder = orderData.GetOrderByCompany();
            return Json(objOrder, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveOrder(OrderModel order)
        {
            var form = order;
            return Json("", JsonRequestBehavior.AllowGet);
        }



    }
}