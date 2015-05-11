using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShareWeb.UI.Models.RequestModel
{


    public class User
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string uuid { get; set; }
        public string password { get; set; }
        public string emailId { get; set; }
        public string gender { get; set; }
        public string homepageurl { get; set; }
        public string profilepicurl { get; set; }
        public string mobile { get; set; }
        public string add1 { get; set; }
        public string add2 { get; set; }
        public string add3 { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string pin { get; set; }
    }


}