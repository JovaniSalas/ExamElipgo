using BusinessLogic;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiZapatos.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/services")]
    public class ArticlesController : ApiController
    {
        readonly ShoeShopLogic ssr = new ShoeShopLogic();
        readonly AnswareApi aapi = new AnswareApi();
        [HttpGet]
        [Route("articles/")]
        public IHttpActionResult Get()
        {
            var result = aapi.Good(ssr.GetArticles());
            return Ok(result);
        }

        [HttpGet]
        [Route("articles/stores/{id}")]
        public IHttpActionResult GetArticlesByStores(string id)
        {
            var result = aapi.Good(ssr.GetArticlesByStores(id));
            return Ok(result);
        }
    }
}

