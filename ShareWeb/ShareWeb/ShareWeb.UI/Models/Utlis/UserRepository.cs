using Facebook;
using Newtonsoft.Json;
using ShareWeb.UI.Models.Facebook;
using ShareWeb.UI.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShareWeb.UI.Models.Utlis
{
    public class UserRepository
    {
        public User FacebookModelToUser(FacebookUserModel fbModel)
        {
            User user = new User() {uuid=fbModel.id,
                fname=fbModel.first_name,
            lname=fbModel.last_name,
            emailId=fbModel.email,
            profilepicurl=fbModel.picture.data.url,
            homepageurl=fbModel.link,
            gender=fbModel.gender.ToUpper().ElementAt(0).ToString()
            };
            return user;
        }
        public async void CreateUser(string accessToken)
        {
            var fbClient = new FacebookClient(accessToken);
            dynamic fbresult = fbClient.Get("me?fields=id,email,first_name,last_name,gender,locale,link,timezone,location,picture");
            FacebookUserModel fbUser = Newtonsoft.Json.JsonConvert.DeserializeObject<FacebookUserModel>(fbresult.ToString());

            User user = FacebookModelToUser(fbUser);
            var client = new RestClient();
            client.EndPoint = @"http://leadonlinetestseries.com/registration/createUser/";
            client.Method = HttpVerb.POST;
            client.PostData = JsonConvert.SerializeObject(user);
            client.ContentType = "application/json";
            var json = client.MakeRequest();
                
        }
        public User GetUser(string uid)
        {
            var client = new RestClient();
            client.EndPoint = @"http://leadonlinetestseries.com/registration/getUser/" +uid;
            client.Method = HttpVerb.GET;
            client.ContentType = "application/json";
            var userJson = client.MakeRequest();
            User user = JsonConvert.DeserializeObject<User>(userJson.ToString());
            return user;
        }
    }
}