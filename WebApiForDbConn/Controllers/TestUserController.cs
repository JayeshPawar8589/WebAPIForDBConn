using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer;

namespace WebApiForDbConn.Controllers
{
    public class TestUserController : ApiController
    {
        public IEnumerable<TestUser> Get()
        {
            using (SALTDevEntities entities = new SALTDevEntities())
            {
                return entities.TestUsers.ToList();
            }
        }


    }
}
