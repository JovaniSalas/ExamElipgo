using Business_Entities.Northwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebExamSiemens.Models
{
    public class CompanyModel: BaseModel
    {
        public List<Company> Companies { get; set; }
    }
}