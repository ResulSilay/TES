using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TES.Models;

namespace TES.Controllers
{
    public class AdminController : Controller
    {
        TESDBEntities db = new TESDBEntities();

        [HttpGet]
        public ActionResult Tender(int type = -1)
        {
            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                if (type == -1)
                    return View(db.Tender.ToList());
                else
                    return View(db.Tender.ToList().Where(x => x.Type == type).OrderByDescending(x => x.Id));
            }

            return View();
        }

        public ActionResult TenderEdit(int id)
        {
            var table = db.Tender.Where(x => x.Id == id).FirstOrDefault();
            return View(table);
        }

        [HttpPost]
        public ActionResult TenderEdit(int id, FormCollection collection)
        {
            var tender = db.Tender.Find(id);
            if (TryUpdateModel(tender))
            {
                tender.Title = collection["Title"];
                tender.Description = collection["Description"];
                tender.Context = collection["Context"];
                //tender.StartDate = collection["StartDate"];
                //tender.EndDate = collection["EndDate"];
                db.SaveChanges();

                return RedirectToAction("Tender");
            }

            return RedirectToAction("Tender");
        }

        [HttpGet]
        public ActionResult TenderInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TenderInsert(FormCollection collection)
        {
            Tender tender = new Models.Tender();
            tender.Title = collection["Title"];
            tender.Description = collection["Description"];
            tender.Context = collection["Context"];
            //tender.StartDate = collection["StartDate"];
            //tender.EndDate = collection["EndDate"];
            //tender.Money = collection["Money"];
            tender.Status = 1;
            tender.Type = 1;
            db.Tender.Add(tender);
            db.SaveChanges();

            return RedirectToAction("Tender");
        }

        public ActionResult TenderDel(int id)
        {
            var table = db.Tender.Where(x => x.Id == id).FirstOrDefault();
            return View(table);
        }

        [HttpPost]
        public ActionResult TenderDel(int id, FormCollection collection)
        {
            var tender = db.Tender.Find(id);
            if (TryUpdateModel(tender))
            {
                db.Tender.Remove(tender);
                db.SaveChanges();
                return RedirectToAction("Tender");
            }

            return RedirectToAction("Tender");
        }

        [HttpGet]
        public ActionResult References(int id = -1)
        {
            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                if (id == -1)
                    return View(db.References_View.ToList());
                else
                    return View(db.References_View.ToList().Where(x => x.TenderId == id));
            }

            return View();
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

        public ActionResult ApprovedEdit(int id)
        {
            var table = db.Approved.Where(x => x.Id == id).FirstOrDefault();
            return View(table);
        }

        [HttpPost]
        public ActionResult ApprovedEdit(int id, FormCollection collection)
        {
            var approved = db.Approved.Find(id);
            if (TryUpdateModel(approved))
            {
                approved.Description = collection["Description"];
                //references.Money = 0;
                db.SaveChanges();

                return RedirectToAction("Approved");

            }

            return RedirectToAction("References");
        }

        public ActionResult ApprovedInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ApprovedInsert(int t_id, FormCollection collection)
        {
            Approved approved = new Models.Approved();
            approved.TenderId = t_id;
            approved.AccountId = Convert.ToInt32(collection["AccountId"].ToString());
            approved.Description = collection["Description"];
            approved.Status = 1;
            approved.Type = 1;
            db.Approved.Add(approved);
            db.SaveChanges();

            return RedirectToAction("Approved");
        }

        public ActionResult ApprovedDel(int id)
        {
            var table = db.Approved.Where(x => x.Id == id).FirstOrDefault();
            return View(table);
        }

        [HttpPost]
        public ActionResult ApprovedDel(int id, FormCollection collection)
        {
            var approved = db.Approved.Find(id);
            if (TryUpdateModel(approved))
            {
                db.Approved.Remove(approved);
                db.SaveChanges();
                return RedirectToAction("Approved");
            }

            return RedirectToAction("Approved");
        }

        public ActionResult Account()
        {
            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View(db.Account.ToList());
            }

            return View();
        }
    }
}