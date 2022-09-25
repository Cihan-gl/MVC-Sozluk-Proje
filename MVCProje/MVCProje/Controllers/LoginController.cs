using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProje.Controllers
{
    [AllowAnonymous]  // global olarak authorize verdik burası muhaf tutulsun
    public class LoginController : Controller
    {
        WriterLoginManager wm = new WriterLoginManager(new EFWriterDal());


        // GET: Login
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();
            var adminuserinfo = c.Admins.FirstOrDefault(x=>x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
            if(adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName,false);
                                                  //(form yetkisi sisteme giren kullanıcının bilgisi) , false = kalıcı cookie oluşmasın

                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                // oturum yönetimi

                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            //Context c = new Context();
            //var writeruserinfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            var writeruserinfo = wm.GetWriter(p.WriterMail, p.WriterPassword);
            if (writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                //(form yetkisi sisteme giren kullanıcının bilgisi) , false = kalıcı cookie oluşmasın

                Session["WriterMail"] = writeruserinfo.WriterMail;
                // oturum yönetimi

                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();      // oturum sonlandır
            return RedirectToAction("Headings", "Default");
        }



    }
}