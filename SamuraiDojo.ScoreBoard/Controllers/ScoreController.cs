using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SamuraiDojo.ScoreBoard.Controllers
{
    public class ScoreController : BaseApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {


            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "The api worked!");
            return response;
        }
    }
}