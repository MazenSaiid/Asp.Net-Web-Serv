using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ProteinTrackerWebAppService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class ProteinTrackingService : WebService
    {
        private UserRepository repository = new UserRepository();


        [WebMethod(Description = "Add an amount to the total",EnableSession = true)]
        public int AddProteinRep(int amount, int userId)
        {
            var user = repository.GetUserById(userId);
            if(user == null)
                return -1;
            user.Total += amount;
            repository.Save(user);
            return user.Total;
        }

        [WebMethod(Description = "Adding a new User",EnableSession = true)]
        public int AddUserRep(string name, int goal)
        {
            var user = new User { Name = name, Goal = goal };
            repository.Add(user);
            return user.Id;
        }

        [WebMethod(Description = "List All Users", EnableSession = true)]
        public List<User> GetUsersRep()
        {
          
            return new List<User>(repository.GetAllUsers());
        }



        //[WebMethod(Description ="Add an amount to the total", EnableSession = true)]
        //public int AddProtein(int amount, int userId)
        //{
        //    if (Session["user" + userId] == null)
        //        return -1;
        //    var user = (User) Session["user" + userId];
        //    user.Total += amount;
        //    Session["user" + userId] = user;
        //    return user.Total;
        //}
        //[WebMethod(Description = "Adding a new User", EnableSession = true)]
        //public int AddUser(string name, int goal)
        //{
        //    int userId = 0;
        //    if (Session["userId"] != null)
        //    {
        //        userId = (int)Session["userId"];
        //    }
        //    else
        //    {
        //        Session["user" + userId] = new User { Name = name, Goal = goal, Total = 0, Id = userId };
        //        Session["userId"] = userId + 1;

        //    }
        //    return userId;
        //}

        //[WebMethod(Description ="List All Users", EnableSession = true)]
        //public List<User> GetUsers()
        //{
        //    List<User > users = new List<User>();
        //    int userId = 0;
        //    if (Session["userId"] != null)
        //        userId = (int)Session["userId"];
            
        //    for (int i = 0; i < userId; i++)
        //    {
        //        users.Add((User)Session["user" + i]);
        //    }
        //    return users;

        //}
    }
}
