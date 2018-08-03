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
using DataAccessLayer;
using System.Web.Http.Cors;

namespace WebApiForDbConn.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class TestUsersController : ApiController
    {
        private RAMASHelpdeskEntities db = new RAMASHelpdeskEntities();

        // GET: api/TestUsers
        public IQueryable<TestUser> GetTestUsers()
        {
            return db.TestUsers;
        }

        // GET: api/TestUsers/5
        [ResponseType(typeof(TestUser))]
        public IHttpActionResult GetTestUser(int id)
        {
            TestUser testUser = db.TestUsers.Find(id);
            if (testUser == null)
            {
                return NotFound();
            }

            return Ok(testUser);
        }

        // PUT: api/TestUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTestUser(int id, TestUser testUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testUser.Id)
            {
                return BadRequest();
            }

            db.Entry(testUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestUserExists(id))
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

        // POST: api/TestUsers
        [ResponseType(typeof(TestUser))]
        public IHttpActionResult PostTestUser(TestUser testUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TestUsers.Add(testUser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = testUser.Id }, testUser);
        }

        // DELETE: api/TestUsers/5
        [ResponseType(typeof(TestUser))]
        public IHttpActionResult DeleteTestUser(int id)
        {
            TestUser testUser = db.TestUsers.Find(id);
            if (testUser == null)
            {
                return NotFound();
            }

            db.TestUsers.Remove(testUser);
            db.SaveChanges();

            return Ok(testUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TestUserExists(int id)
        {
            return db.TestUsers.Count(e => e.Id == id) > 0;
        }
    }
}