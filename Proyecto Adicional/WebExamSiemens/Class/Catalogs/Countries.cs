using Business_Logic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExamSiemens.Class.Interface;
using WebExamSiemens.Models;

namespace WebExamSiemens.Class.Catalogs
{
    public class Countries: ICatalogItem
    {
        readonly INorthwind repNorthwind = new Northwind();
        public List<ItemModel> GetValues()
        {
            List<ItemModel> items = new List<ItemModel>();
            try
            {
                var listCountries = repNorthwind.GetCountries();
                listCountries.ForEach(c =>
                {
                    items.Add(new ItemModel()
                    {
                        Value = c.Name,
                        Text = c.Name
                    });
                });
            }
            catch (Exception er)
            {
                items.Add(new ItemModel()
                {
                    Value = er.Message,
                    Text = "No hay datos..."
                });
            }
            return items;
        }

        CompanyModel ICatalogItem.GetCompanies()
        {
            throw new NotImplementedException();
        }

    }
}