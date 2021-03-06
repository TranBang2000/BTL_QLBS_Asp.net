using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VinaMilk.Areas.Admin.Data;
using VinaMilk.Common;

namespace VinaMilk.Controllers
{
    public class LoginController : Controller
    {
        

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LoginClient()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginClient(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserClientDao();
                var result = dao.Login(model.userName, model.Password);
                if (result == 1)
                {
                    var user = dao.GetByUserName(model.userName);
                    var userSession = new UserLogin();
                    userSession.userName = user.TenTK;
                    userSession.name = user.HoTen;
                    userSession.email = user.Email;
                    userSession.adress = user.Dia_Chi;
                    userSession.phoneNumbers = user.SDT;
                    Session.Add(CommonConstants.USERCLIENT_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
              
                else if (result == 0)
                {
                    return RedirectToAction("Index", "Home");
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Sai mật khẩu");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng");
                }
            }
            return View("LoginClient");
        }
        [HttpGet]
        public ActionResult RegisterClient()
        {
            try
            {
                var sessionUser = Session["USERCLIENT_SESSION"] as UserLogin;
                ViewBag.name = sessionUser.name;
                ViewBag.userName = sessionUser.userName;
                var ss = ViewBag.name;
                if (ViewBag.name != null)
                {
                    ViewBag.name = sessionUser.name;
                }
                else
                {
                    ViewBag.name = null;
                }
            }
            catch
            {
                ViewBag.name = null;
            }
            return View();
        }
        [HttpPost]
        public ActionResult RegisterClient(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new TaiKhoan1();
                user.TenTK = model.userName;
                user.HoTen = model.Name;
                user.SDT = model.PhoneNumbers;
                user.Dia_Chi = model.Adress;
                user.Email = model.Email;
                user.Mat_Khau = model.PassWord;
                if (user.TenTK.Length > 0)
                {
                    VinaMilkDbContext db = new VinaMilkDbContext();
                    db.TaiKhoans.Add(user);
                    db.SaveChanges();

                }
                return RedirectToAction("LoginClient", "Login");
            }

            return View("LoginClient");
        }
        public ActionResult Logout()
        {
            Session.Remove(CommonConstants.USERCLIENT_SESSION);
            return RedirectToAction("Index", "Home");
        }
    }
}