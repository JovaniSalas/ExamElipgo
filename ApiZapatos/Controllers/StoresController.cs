using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiZapatos.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/services")]
    public class StoresController : ApiController
    {
        readonly ShoeShopLogic ssr = new ShoeShopLogic();
        readonly AnswareApi aapi = new AnswareApi();

        [HttpGet]
        [Route("stores/")]
        public IHttpActionResult Get()
        {
            var result = aapi.Good(ssr.GetStores());
            return Ok(result);
        }
    }
}
