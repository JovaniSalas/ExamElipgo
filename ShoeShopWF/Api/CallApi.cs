using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace ShoeShopWF.Api
{
    public class CallApi
    {
        private string urlApi;
        public CallApi()
        {
            urlApi = ConfigurationManager.AppSettings["urlApi"];
        }
        public string Execute(string route, string method)
        {
            string result = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(urlApi))
                {
                    var url = urlApi + $"/{route}";
                    var request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = method;
                    request.ContentType = "application/json";
                    request.Accept = "application/json";
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            if (strReader == null) result = "";
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                result = objReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                result = "ERROR-API_"+ex.Message.ToString();
            }
            return result;
        }
    }
}
