using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShopWF.Models
{
    public class ArticleResponseModel: BaseResponseModel
    {
        public List<Article> articles { get; set; }
    }
}
