using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VinaMilk.Common;
using PagedList;

namespace VinaMilk.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        VinaMilkDbContext db = new VinaMilkDbContext();
        // GET: Admin/User
        public ActionResult Index(string searchString,int page=1,int pageSize=5)
        {
            var dao = new UserDAO();
            var model = dao.ListAllPaging(searchString,page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var sessionUser = Session["USER_SESSION"] as UserLogin;
            ViewBag.userName = sessionUser.userName;
            ViewBag.email = sessionUser.email;
            return View();
        }
        [HttpPost]
        public ActionResult Create(TaiKhoan user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var encrypt = Encryptor.MD5Hash(user.Mat_Khau);
                    user.Mat_Khau = encrypt;
                    db.TaiKhoans.Add(user);
                    db.SaveChanges();
                    setAlert("Tạo Mới Tài Khoản Thành Công!","success");
                    return RedirectToAction("Index", "User");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Tạo mới tài khoản thất bại " + ex.Message;
                return View(user);
            }
            var sessionUser = Session["USER_SESSION"] as UserLogin;
            ViewBag.userName = sessionUser.userName;
            ViewBag.email = sessionUser.email;
            return View();
        }

        private void setAlert(string v)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult Edit(string tenTk)
        {
            var user = db.TaiKhoans.SingleOrDefault(x => x.TenTK == tenTk);
            var sessionUser = Session["USER_SESSION"] as UserLogin;
            ViewBag.userName = sessionUser.userName;
            ViewBag.email = sessionUser.email;
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(TaiKhoan user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(user.TenTK) && !string.IsNullOrEmpty(user.Mat_Khau))
                    {
                        db.Entry(user).State = EntityState.Modified;
                        db.SaveChanges();
                        setAlert("Chỉnh Sửa Thông Tin Tài Khoản Thành Công!", "success");
                        return RedirectToAction("Index", "User");
                    }
                }
               
            }
            catch (Exception ex)
            {

                ViewBag.Error="Cập nhật thông tin thất bại "+ex.Message;
                return View(user);
            }
            var sessionUser = Session["USER_SESSION"] as UserLogin;
            ViewBag.userName = sessionUser.userName;
            ViewBag.email = sessionUser.email;
            return View();
        }
       
        [HttpGet]
        public ActionResult Delete(string tenTk)
        {
            var user = db.TaiKhoans.SingleOrDefault(x => x.TenTK == tenTk);
            var sessionUser = Session["USER_SESSION"] as UserLogin;
            ViewBag.userName = sessionUser.userName;
            ViewBag.email = sessionUser.email;
            return View(user);
        }
        [HttpPost]
        public ActionResult Delete(string tentk, string hoten)
        {
            var user = db.TaiKhoans.SingleOrDefault(x => x.TenTK == tentk);
            try
            {
                db.TaiKhoans.Remove(user);
                db.SaveChanges();
                setAlert("Xóa Tài Khoản Thành Công!", "success");
                var sessionUser = Session["USER_SESSION"] as UserLogin;
                ViewBag.userName = sessionUser.userName;
                ViewBag.email = sessionUser.email;
                return RedirectToAction("Index", "User");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Xóa thất bại" + ex.Message;
                return View(user);
            }

        }
        //[HttpGet]
        //public ActionResult EditPass(string tenTk)
        //{
        //    var user = db.TaiKhoans.SingleOrDefault(x => x.TenTK == tenTk);
        //    var sessionUser = Session["USER_SESSION"] as UserLogin;
        //    ViewBag.userName = sessionUser.userName;
        //    ViewBag.email = sessionUser.email;
        //    return View(user);
        //}
        //[HttpPost]
        //public ActionResult EditPass(string TenTK, string Mat_Khau)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var encrypt = Encryptor.MD5Hash(Mat_Khau);
        //        Mat_Khau = encrypt;
        //        var user = db.TaiKhoans.SingleOrDefault(x => x.TenTK == TenTK);
        //        user.Mat_Khau = Mat_Khau;
        //        db.SaveChanges();
        //        return RedirectToAction("Index", "User");
        //    }
        //    var sessionUser = Session["USER_SESSION"] as UserLogin;
        //    ViewBag.userName = sessionUser.userName;
        //    ViewBag.email = sessionUser.email;
        //    return View();
        //}
        //public ActionResult Logon(string tenTk)
        //{
        //    var user = db.TaiKhoans.SingleOrDefault(x => x.TenTK == tenTk);
        //    try
        //    {
        //        user.Khoa = false;
        //        db.SaveChanges();
        //        var sessionUser = Session["USER_SESSION"] as UserLogin;
        //        ViewBag.userName = sessionUser.userName;
        //        ViewBag.email = sessionUser.email;
        //        return RedirectToAction("Index", "User");
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Error = "Mở Khóa tài khoản thất bại" + ex.Message;
        //        return View(user);
        //    }

        //}
    }
}