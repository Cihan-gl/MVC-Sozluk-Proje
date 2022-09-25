using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Galeri

        ImageFileManager im = new ImageFileManager(new EFImageFileDal());
        public ActionResult Index()
        {
            var files = im.GetList();
            return View(files);
        }
    }
}