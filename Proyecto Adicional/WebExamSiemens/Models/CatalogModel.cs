using Business_Entities.Northwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebExamSiemens.Models
{
    public class CatalogModel : BaseModel
    {
        public string NameCountry { get; set; }
        public List<ItemModel> Countries { get; set; }
        public List<Order> Orders { get; set; }
    }
}