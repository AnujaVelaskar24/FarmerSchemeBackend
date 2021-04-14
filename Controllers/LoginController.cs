using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FarmerScheme.Models;

namespace FarmerScheme.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public IHttpActionResult loginuser([FromBody] Login log)
        {
            FarmerSchemeEntities db = new FarmerSchemeEntities();

            var res = db.user_information.Where(x => x.username == log.username && x.password == log.password).FirstOrDefault();
            Console.WriteLine(res+"vs19");
            if (res != null)
            {
                //log.message = "Successful";
                return Ok("Successful");
            }
            else
            {
                //log.message = "Unsuccessful";
                return Ok("Unsuccessful");
            }

        }
    }
}
