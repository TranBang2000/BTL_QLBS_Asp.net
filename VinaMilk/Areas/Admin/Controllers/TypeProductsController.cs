using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VinaMilk.Common;

namespace VinaMilk.Areas.Admin.Controllers
{
    public class TypeProductsController : BaseController
    {
        // GET: Admin/TypeProducts
        VinaMilkDbContext db = new VinaMilkDbContext();
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new UserDAO();
            var model = dao.ListAllPaging1(searchString, page, pageSize);
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
        public ActionResult Create(DanhMuc danhmuc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.DanhMucs.Add(danhmuc);
                    db.SaveChanges();
                    setAlert("Thêm Mới Danh Mục Thành Công!", "success");
                    return RedirectToAction("Index", "TypeProducts");
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = "Thêm danh mục thất bại " + e.Message;
                return View("Create", danhmuc);
                //throw;
            }
            var sessionUser = Session["USER_SESSION"] as UserLogin;
            ViewBag.userName = sessionUser.userName;
            ViewBag.email = sessionUser.email;
            return View();
        }
        [HttpGet]
        public ActionResult Edit(string maDM)
        {
            var DM = db.DanhMucs.SingleOrDefault(x => x.MaDM == maDM);
            var sessionUser = Session["USER_SESSION"] as UserLogin;
            ViewBag.userName = sessionUser.userName;
            ViewBag.email = sessionUser.email;
            return View(DM);
        }
        [HttpPost]
        public ActionResult Edit(DanhMuc danhmuc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(danhmuc).State = EntityState.Modified;
                    db.SaveChanges();
                    setAlert("Sửa Danh Mục Thành Công!", "success");
                    return RedirectToAction("Index", "TypeProducts");
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = "Cập nhật danh mục thất bại " + e.Message;
                return View("Edit", danhmuc);
                //throw;
            }
           
            var sessionUser = Session["USER_SESSION"] as UserLogin;
            ViewBag.userName = sessionUser.userName;
            ViewBag.email = sessionUser.email;
            return View();
        }


        [HttpGet]
        public ActionResult Delete(string maDM)
        {
            var DM = db.DanhMucs.SingleOrDefault(x => x.MaDM == maDM);
            var sessionUser = Session["USER_SESSION"] as UserLogin;
            ViewBag.userName = sessionUser.userName;
            ViewBag.email = sessionUser.email;
            return View(DM);
        }
        [HttpPost]
        public ActionResult Delete(string maDM, string tenDM)
        {
            var user = db.DanhMucs.SingleOrDefault(x => x.MaDM == maDM);
            try
            {
                db.DanhMucs.Remove(user);
                db.SaveChanges();
                var sessionUser = Session["USER_SESSION"] as UserLogin;
                ViewBag.userName = sessionUser.userName;
                ViewBag.email = sessionUser.email;
                setAlert("Xóa Danh Mục Thành Công!", "success");
                return RedirectToAction("Index", "TypeProducts");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Xóa thất bại" + ex.Message;
                return View(user);
            }

        }
    }
}