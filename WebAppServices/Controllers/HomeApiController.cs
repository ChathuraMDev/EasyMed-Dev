using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAppServices.Controllers
{
    [Authorize]
    public class HomeApiController : ApiController
    {
        [HttpGet]
        public string GetDashBoard()
        {
            return "Authorized success here is the dashboard..";
        }


    }
}
