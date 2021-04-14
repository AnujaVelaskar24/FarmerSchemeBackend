using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FarmerScheme.Models;

namespace FarmerScheme.Controllers
{
    public class Default1Controller : ApiController
    {
        FarmerSchemeEntities db = new FarmerSchemeEntities();
        public IHttpActionResult GetUser()
        {
            return Ok(db.user_information.ToList());
        }
        public IHttpActionResult GetUserByID(int userid)
        {
            return Ok(db.user_information.Where(x => x.userid == userid).FirstOrDefault());
        }
        [HttpPost]
        public IHttpActionResult Register(user_information user)
        {
            db.user_information.Add(user);
            db.SaveChanges();
            return Ok(db.user_information);
        }

        public IHttpActionResult PutUser(int userid, user_information user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(user);
        }

        public IHttpActionResult DeleteUser(int userid)
        {
            user_information user = db.user_information.Find(userid);
            db.user_information.Remove(user);
            db.SaveChanges();
            return Ok(user);
        }
    }
}
