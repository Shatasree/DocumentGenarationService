using DemoUsers.BL;
using DemoUsers.DAL;
using DemoUsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoUsers.Controllers
{
    public class UserController : Controller
    {
        private IUserDetailsBL _userDetails = null;
        public UserController(IUserDetailsBL userDetails)
        {
            _userDetails = userDetails;
        }
        // GET: User
        public ActionResult Index(UserDetails userDetails)
        {
            //UserDetails userDetails = new UserDetails();
            return View(userDetails);
        }
        public ActionResult GetUser(int Id)
        {
            UserDetails ud = new UserDetails();
            ud.dt = _userDetails.Get_User(Id).Tables[0];

            return View("Index",ud);
        }


        public ActionResult InsertUser(string Username, string Password,string Phone)
        {
            UserDetails userDetails = new UserDetails();
            userDetails.userName = Username;
            userDetails.password = Password;
            userDetails.phone = Phone;
            var status = _userDetails.Insert_User(userDetails);
            if (status > 0)
            {
                TempData["SuccessMessage"] = "Successfully Inserted";
            }
            return RedirectToAction("Index","Home");
        }
        
        public ActionResult UpdateUser(int Id,string Username, string Password, string Phone)
        {
            UserDetails userDetails = new UserDetails();
            userDetails.Id = Id;
            userDetails.userName = Username;
            userDetails.password = Password;
            userDetails.phone = Phone;
            var status = _userDetails.Update_User(userDetails);
            if (status>0)
            {
                TempData["SuccessMessage"] ="Successfully Updated";
            }
            return RedirectToAction("Index", "Home");
        }
    }
}