using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIAuthentication.Controllers
{
    [Authorize]
    public class AuthTestController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Test()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "You can access to API");
        }
    }
}
