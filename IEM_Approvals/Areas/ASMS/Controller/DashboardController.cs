using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IEM_Approvals.Areas.ASMS.Controller
{
    public class DashboardController : ApiController
    {
        [HttpGet]
        public string Returnstring()
        {
            return "Ramya chk";
        }
    }
}
