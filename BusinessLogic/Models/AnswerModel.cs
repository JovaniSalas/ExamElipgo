using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AnswerModel
    {
        private List<Article> _articles;
        private List<Store> _stores;
        public List<Article> articles
        {
            get { return _articles; }
            set { _articles = value; message(); }
        }
        public List<Store> stores
        {
            get { return _stores; }
            set { _stores = value; message(); }
        }
        public string error_msg { get; set; }
        public int? error_code { get; set; }
        public bool? success { get; set; }
        public int? total_elements { get; set; }
        private void message()
        {
            string msg = string.Empty;
            if ((articles != null && articles.Count == 0) || (stores != null && stores.Count == 0))
            {
                error_msg = "Record not Found";
                articles = null;
                error_code = 404;
                success = false;
            }
            else
            {
                if (articles != null && articles.Count > 0)
                {
                    total_elements = articles.Count;
                }
                if (stores != null && stores.Count > 0)
                {
                    total_elements = stores.Count;
                }
                success = true;
            }
        }
    }
}
