using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiForDbConn.Models
{
    public class User
    {
        public string UserID { get; set; }
        public string UserEmail { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }
}