using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FarmerScheme.Models;

namespace FarmerScheme.Controllers
{
    public class DefaultController : ApiController
    {
        FarmerSchemeEntities db = new FarmerSchemeEntities();
        [HttpGet]
        public IHttpActionResult get()
        {
            var user = db.user_information.ToList();
            return Ok(user);
        }
    }
}
