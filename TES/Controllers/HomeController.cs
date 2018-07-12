using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TES.Models;

namespace TES.Controllers
{
    public class HomeController : Controller
    {
        TESDBEntities db = new Models.TESDBEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Tender(int type = -1)
        {
            db.usp_Tender_Control();

            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                if (type == -1)
                    return View(db.Tender.ToList());
                else
                    return View(db.Tender.ToList().Where(x => x.Type == type || x.Status==1).OrderByDescending(x => x.Id));
            }

            return Redirect("/User/Index");
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

        public ActionResult Detail(int id)
        {
            var datatable = new Models.TESDBEntities();
            var table = datatable.Tender.Where(x => x.Id == id).FirstOrDefault();
            return View(table);
        }

        string email, password;

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                email = collection.Get("txt_Login_Email");
                password = collection.Get("txt_Login_Email");

                var datatable = new Models.TESDBEntities();
                var data = datatable.Account.Where(x => x.eMail == email || x.Password == password).FirstOrDefault();
                if (data != null)
                {
                    FormsAuthentication.SetAuthCookie(email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("","E-Mail veya şifre hatalı.");
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult Register(FormCollection collection)
        {
            Response.Write(collection.Get("txtName"));
            return View();
        }
    }
}