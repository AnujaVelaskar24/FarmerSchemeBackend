using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FarmerScheme.Models;

namespace FarmerScheme.Controllers
{
    public class RegController : ApiController
    {
        private FarmerSchemeEntities db = new FarmerSchemeEntities();

        // GET: api/Reg
        public IQueryable<user_information> Getuser_information()
        {
            return db.user_information;
        }

        // GET: api/Reg/5
        [ResponseType(typeof(user_information))]
        public IHttpActionResult Getuser_information(int id)
        {
            user_information user_information = db.user_information.Find(id);
            if (user_information == null)
            {
                return NotFound();
            }

            return Ok(user_information);
        }

        // PUT: api/Reg/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putuser_information(int id, user_information user_information)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user_information.userid)
            {
                return BadRequest();
            }

            db.Entry(user_information).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!user_informationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Reg
        [ResponseType(typeof(user_information))]
        public IHttpActionResult Postuser_information(user_information user_information)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.user_information.Add(user_information);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user_information.userid }, user_information);
        }

        // DELETE: api/Reg/5
        [ResponseType(typeof(user_information))]
        public IHttpActionResult Deleteuser_information(int id)
        {
            user_information user_information = db.user_information.Find(id);
            if (user_information == null)
            {
                return NotFound();
            }

            db.user_information.Remove(user_information);
            db.SaveChanges();

            return Ok(user_information);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool user_informationExists(int id)
        {
            return db.user_information.Count(e => e.userid == id) > 0;
        }
    }
}