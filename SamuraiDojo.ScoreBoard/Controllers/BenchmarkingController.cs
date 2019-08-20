using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Hosting;
using System.Web.Http;
using SamuraiDojo.Utility;

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
