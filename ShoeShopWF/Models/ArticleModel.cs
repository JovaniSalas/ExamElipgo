using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShopWF.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Total_in_shelf { get; set; }
        public int Total_in_vault { get; set; }
        public string Store { get; set; }
    }
}
