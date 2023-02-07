using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUsers.Models;
using DemoUsers.DAL;
using System.Data;
using DemoUsers.BL;

namespace DemoUsers.Controllers
{
    public class HomeController : Controller
    {
        private IHomeBL _homeBL=null;
        public HomeController(IHomeBL homeBL)
        {
            _homeBL=homeBL;
        }
        public ActionResult Index()
        {
            
            return View();
        }
        public JsonResult Get_Data()
        {
            var result = _homeBL.Get_UserList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Remove_data(int Id)
        {
            var status=_homeBL.Delete_User(Id);
            if (status > 0)
            {
                TempData["SuccessMessage"] = "Successfully Removed";
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult InsertUser()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}