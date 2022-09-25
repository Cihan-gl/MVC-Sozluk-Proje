using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization

        AdminManager am = new AdminManager(new EFAdminDal());
        public ActionResult Index()
        {
            var adminvalues = am.GetList();
            return View(adminvalues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddAdmin(Admin p )
        {
            am.AdminAdd(p);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminvalue = am.GetByID(id);
            return View(adminvalue);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            am.AdminUpdate(p);
            return RedirectToAction("Index");
        }




    }
}