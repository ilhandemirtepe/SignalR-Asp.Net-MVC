using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.Models;

namespace WebChat.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }


        }

        [HttpGet]
        public ActionResult KayitOl()
        {

            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(UserAccount user)
        {

            if (ModelState.IsValid)
            {
                using (OurDBContext db = new OurDBContext())
                {

                    db.kullaniciHesap.Add(user);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = user.Name + "Eklenmesi Başarılı";


            }

            return View();
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (OurDBContext db = new OurDBContext())
            {
                var vv = db.kullaniciHesap.Where(a => a.UserName.Equals(user.UserName) && a.PassWord.Equals(user.PassWord)).FirstOrDefault();
               // var usr = db.kullaniciHesap.Single(u => u.UserName == user.UserName && u.PassWord == user.PassWord);
                if (vv != null)
                {

                    Session["UserID"] = vv.UserID.ToString();
                    Session["Name"] =vv.Name.ToString();
                    return RedirectToAction("Index");

                }
                else
                {

                    ViewData["Message"] = "kullanıcı adı yada şifre yanlış";
                }
            }
            return View();
        }



    }
}
//[HttpGet]
//public ActionResult Login()
//{



//    Session["UserName1"] = "Ali";



//    return View();
//}
//[HttpPost]
//public ActionResult Login( String user)
//{
//    user= "Ali";


//    Session["UserName1"] = user;



//    return View();
//}