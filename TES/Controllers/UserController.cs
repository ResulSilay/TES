using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TES.Models;

namespace TES.Controllers
{
    public class UserController : Controller
    {
        TESDBEntities db = new TESDBEntities();

        // GET: User
        //public ActionResult Index()
        //{
        //    var datatable = new Models.TESDBEntities();

        //    if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
        //    {
        //        FormsAuthentication.SignOut();
        //        return View(datatable.Tender.ToList());
        //    }

        //    return View();
        //}

        [HttpGet]
        public ActionResult Index(int type=-1)
        {
            var datatable = new Models.TESDBEntities();

            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                if (type == -1)
                    return View(datatable.Tender.ToList());
                else
                    return View(datatable.Tender.ToList().Where(x => x.Type == type));
            }

            return View();
        }

        public ActionResult TenderDetail(int id)
        {
            var datatable = new Models.TESDBEntities();
            var table = datatable.Tender.Where(x => x.Id == id).FirstOrDefault();
            return View(table);
        }

        public ActionResult Refer(int id)
        {
            var datatable = new Models.TESDBEntities();
            var table = datatable.Tender.Where(x => x.Id == id).FirstOrDefault();
            return View(table);
        }

        [HttpPost]
        public ActionResult Refer(int id, FormCollection collection)
        {
            References references = new References();
            references.TenderId = id;
            references.AccountId = 1;
            references.Note = collection["note"];
            references.Note = collection["note"];
            db.References.Add(references);
            db.SaveChanges();

            return RedirectToAction("References");
        }

        public ActionResult References()
        {
            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View(db.References_View.ToList());
            }

            return View();
        }

        public ActionResult ReferUpdate(int id)
        {
            var datatable = new Models.TESDBEntities();
            var table = datatable.References.Where(x => x.Id == id).FirstOrDefault();
            return View(table);
        }

        [HttpPost]
        public ActionResult ReferUpdate(int id, FormCollection collection)
        {
            var references = db.References.Find(id);
            if (TryUpdateModel(references))
            {
                references.Note = collection["note"];
                //references.Money = 0;
                db.SaveChanges();

                return RedirectToAction("References");

            }

            return RedirectToAction("References");
        }

        public ActionResult Approved()
        {
            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View(db.Approved_View.ToList());
            }

            return View();
        }

        public ActionResult ApprovedDetail(int id)
        {
            var datatable = new Models.TESDBEntities();
            var table = datatable.Approved_View.Where(x => x.Id == id).FirstOrDefault();
            return View(table);
        }
    }
}