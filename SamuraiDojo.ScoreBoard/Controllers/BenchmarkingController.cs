using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SamuraiDojo.ScoreBoard.Controllers
{
    public class BenchmarkingController : BaseApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            string output = "";
            return Request.CreateResponse(HttpStatusCode.OK, output);
        }
    }
}
