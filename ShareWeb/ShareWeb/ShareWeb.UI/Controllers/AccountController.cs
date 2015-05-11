using Facebook;
using ShareWeb.UI.Models.Facebook;
using ShareWeb.UI.Models.RequestModel;
using ShareWeb.UI.Models.Utlis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShareWeb.UI.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        [HttpPost]
        public async Task<JsonResult> FacebookLogin(FacebookLoginModel model)
        {
            Session["uid"] = model.uid;
            Session["accessToken"] = model.accessToken;
            
            new UserRepository().CreateUser(model.accessToken);
            
            return Json(new { success = true });
        }

        [HttpGet]
        public ActionResult UserDetails()
        {
            var client = new FacebookClient(Session["accessToken"].ToString());
            dynamic fbresult = client.Get("me?fields=id,email,first_name,last_name,gender,locale,link,timezone,location,picture");
            FacebookUserModel facebookUser = Newtonsoft.Json.JsonConvert.DeserializeObject<FacebookUserModel>(fbresult.ToString());
            Session["user"] = fbresult.ToString();
            return PartialView("Navbar", facebookUser);
        }
        [HttpGet]
        public ActionResult GetUserProfile()
        {
            User user = new UserRepository().GetUser(Session["uid"].ToString());
            return PartialView("Profile", user);
        }

    }
}
