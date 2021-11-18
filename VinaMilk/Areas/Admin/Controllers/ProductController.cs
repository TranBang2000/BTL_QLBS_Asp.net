using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;   
using System.Web.Mvc;
using VinaMilk.Common;
using System.IO;
using System.Net;

namespace VinaMilk.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        VinaMilkDbContext db = new VinaMilkDbContext();
        public ActionResult Index(string searchString, int page = 1, int pageSize = 4)
        {
            var dao = new UserDAO();
            var model = dao.ListAllPaging2(searchString, page, pageSize);
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
        public ActionResult Create([Bind(Include = "MaSP,TenSP,Anh,SoLuongCo,GiaHT,MoTa,MaDM")] SanPham product)
        {
            var f = Request.Files["ImageFile"];
            if (f != null && f.ContentLength > 0)
            {
                string fileName = Path.GetFileName(f.FileName);
                string uploadPath = Server.MapPath("~/Assest/Admin/img/images/" + fileName);
                //string uploadPaths = Server.MapPath("~/Anh/" + fileName);
                //f.SaveAs(uploadPaths);
                f.SaveAs(uploadPath);
                product.Anh = fileName;
            }
            if (true)
            {
                try
                {
                    db.SanPhams.Add(product);
                    db.SaveChanges();
                    setAlert("Thêm Mới Sản Phẩm Thành Công!", "success");
                    return RedirectToAction("Index", "Product");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Thêm sản phẩm thất bại " + ex.Message;
                    return View("Create", product);
                }

            }
            var sessionUser = Session["USER_SESSION"] as UserLogin;
            ViewBag.userName = sessionUser.userName;
            ViewBag.email = sessionUser.email;
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string MaSP)
        {
            var product = db.SanPhams.SingleOrDefault(x => x.MaSP == MaSP);
            var sessionUser = Session["USER_SESSION"] as UserLogin;
            ViewBag.userName = sessionUser.userName;
            ViewBag.email = sessionUser.email;
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(SanPham product)
        {
            var f = Request.Files["ImageFile"];
            if (f != null && f.ContentLength > 0)
            {
                string fileName = Path.GetFileName(f.FileName);
                string uploadPath = Server.MapPath("~/Assest/Admin/img/images/" + fileName);
                //string uploadPaths = Server.MapPath("~/Anh/" + fileName);
                //f.SaveAs(uploadPaths);
                f.SaveAs(uploadPath);
                product.Anh = fileName;
            }
            if (true)
            {
                try
                {
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    setAlert("Sửa Thông tin Sản Phẩm Thành Công!", "success");
                    return RedirectToAction("Index", "Product");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Cập nhật thất bại " + ex.Message;
                    return View(product);
                }
            }
            var sessionUser = Session["USER_SESSION"] as UserLogin;
            ViewBag.userName = sessionUser.userName;
            ViewBag.email = sessionUser.email;
            return View();
        }
        [HttpGet]
        public ActionResult Delete(string MaSP)
        {
            var product = db.SanPhams.SingleOrDefault(x => x.MaSP == MaSP);
            var sessionUser = Session["USER_SESSION"] as UserLogin;
            ViewBag.userName = sessionUser.userName;
            ViewBag.email = sessionUser.email;
            return View(product);
        }
        [HttpPost]
        public ActionResult Delete(string MaSP, string TenSP)
        {
            var user = db.SanPhams.SingleOrDefault(x => x.MaSP == MaSP);
            try
            {
                db.SanPhams.Remove(user);
                db.SaveChanges();
                setAlert("Xóa Sản Phẩm Thành Công!", "success");
                var sessionUser = Session["USER_SESSION"] as UserLogin;
                ViewBag.userName = sessionUser.userName;
                ViewBag.email = sessionUser.email;
                return RedirectToAction("Index", "Product");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Xóa thất bại " + ex.Message;
                return View(user);
            }

        }
    }
}