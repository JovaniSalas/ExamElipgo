using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShopWF.Models
{
    public class BaseResponseModel
    {
        public bool success { get; set; }
        public int total_elements { get; set; }
        public string error_msg { get; set; }
        public int? error_code { get; set; }
    }
}
