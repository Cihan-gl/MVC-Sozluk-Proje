using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_Fluent;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class WriterController : Controller
    {
        // GET: Writer
        WriterManager wm = new WriterManager(new EFWriterDal());
        WriterValidator writervalidator = new WriterValidator();


        public ActionResult Index()
        {
            var WriterValues = wm.GetList();
            return View(WriterValues);
        }


        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
            ValidationResult results = writervalidator.Validate(p);
            if(results.IsValid)
            {
                wm.WriterAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writevalue = wm.GetByID(id);
            return View(writevalue);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {

            ValidationResult results = writervalidator.Validate(p);
            if (results.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }


    }
}