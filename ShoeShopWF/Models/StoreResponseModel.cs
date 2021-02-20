using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShopWF.Models
{
    public class StoreResponseModel: BaseResponseModel
    {
        public List<Store> stores { get; set; }        
    }
}
