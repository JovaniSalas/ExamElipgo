using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExamSiemens.Models;

namespace WebExamSiemens.Class.Interface
{
    public interface ICatalogItem
    {
        List<ItemModel> GetValues();
        CompanyModel GetCompanies();
    }
}
