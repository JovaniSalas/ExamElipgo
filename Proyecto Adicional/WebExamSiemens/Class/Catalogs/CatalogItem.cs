using Business_Logic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExamSiemens.Class.Interface;
using WebExamSiemens.Models;

namespace WebExamSiemens.Class.Catalogs
{
    public class CatalogItem: ICatalogItem
    {
        ICatalogItem catalog;
        public CatalogItem(ICatalogItem _catalog)
        {
            this.catalog = _catalog;
        }

        List<ItemModel> ICatalogItem.GetValues()
        {
           return this.catalog.GetValues();
        }
        CompanyModel ICatalogItem.GetCompanies()
        {
            return this.catalog.GetCompanies();
        }
    }
}