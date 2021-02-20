using Business_Logic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExamSiemens.Class.Interface;
using WebExamSiemens.Models;

namespace WebExamSiemens.Class.Catalogs
{
    public class Companies: ICatalogItem
    {
        public string _country { get; set; }
        readonly INorthwind repNorthwind = new Northwind();
        public Companies(string country)
        {
            this._country = country;
        }
        public CompanyModel GetCompanies()
        {
            CompanyModel companies = new CompanyModel();
            try
            {
                companies.Companies = repNorthwind.GetCompaniesByCountry(_country);               
            }
            catch (Exception e)
            {
                companies.Error = e.Message;
                companies.ExistError = true;
            }
            return companies;
        }

        List<ItemModel> ICatalogItem.GetValues()
        {
            throw new NotImplementedException();
        }

    }
}