using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiZapatos
{
    public class AnswareApi
    {
        /**
         * Clase respuesta para limpiar atributos nulos
         */
        public JObject Good(object value)
        {
            var result = JsonConvert.SerializeObject(value, Formatting.None,
            new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,                
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
            JObject jsonObject = JObject.Parse(result);
            return jsonObject;
        }
    }
}