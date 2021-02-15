using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace ApiZapatos
{
    public class ExeptionFilter: ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext httpActionExecutedContext)
        {
            string msg = string.Empty;
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            var exceptionType = httpActionExecutedContext.GetType();
            if (exceptionType == typeof(NullReferenceException))
            {
                httpStatusCode = HttpStatusCode.NotFound;
                msg = "No se encontraron datos";
            }
            else if (exceptionType == typeof(NullReferenceException))
            {
                httpStatusCode = HttpStatusCode.NotFound;
                msg = "Acceso no autorizado";
            }

            var httpResponse = new HttpResponseMessage(httpStatusCode)
            {
                Content = new StringContent(msg)
            };
            httpActionExecutedContext.Response = httpResponse;
            base.OnException(httpActionExecutedContext);
        }
    }
}