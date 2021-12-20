using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VinaMilk.Models;

namespace VinaMilk.Areas.Admin.Controllers
{
    public class TaiKhoansController : BaseController
    {
        private VinaMilkDbContext db = new VinaMilkDbContext();

        // GET: Admin/TaiKhoans
        public ActionResult Index(string sortOrder, string searchString, string currenFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SapTheoTenTK = String.IsNullOrEmpty(sortOrder) ? "tentk_desc" : "";
            ViewBag.SapTheoHoTen = sortOrder == "hoten" ? "hoten_desc" : "hoten";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currenFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var taikhoans = db.TaiKhoan.Select(s => s);
            if (!String.IsNullOrEmpty(searchString))
            {
                taikhoans = taikhoans.Where(s => s.HoTen.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "tentk_desc":
                    taikhoans = taikhoans.OrderByDescending(s => s.TenTK);
                    break;
                case "hoten":
                    taikhoans = taikhoans.OrderBy(s => s.HoTen);
                    break;
                case "hoten_desc":
                    taikhoans = taikhoans.OrderByDescending(s => s.HoTen);
                    break;
                default:
                    taikhoans = taikhoans.OrderBy(s => s.TenTK);
                    break;
            }
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(taikhoans.ToList());
            return View(db.TaiKhoan.ToList());
        }

        // GET: Admin/TaiKhoans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoan.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // GET: Admin/TaiKhoans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TaiKhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenTK,Mat_Khau,HoTen,Dia_Chi,SDT,Email,Quyen")] TaiKhoan taiKhoan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.TaiKhoan.Add(taiKhoan);
                    db.SaveChanges();
                    setAlert("Thêm Mới Tài Khoản Thành Công!", "success");
                    return RedirectToAction("Index");
                }

                return View(taiKhoan);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Thêm tài khoản thất bại " + ex.Message;
                //throw;
                return View("Create", taiKhoan);
            }
        }

        // GET: Admin/TaiKhoans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoan.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // POST: Admin/TaiKhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TenTK,Mat_Khau,HoTen,Dia_Chi,SDT,Email,Quyen")] TaiKhoan taiKhoan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(taiKhoan).State = EntityState.Modified;
                    db.SaveChanges();
                    setAlert("Sửa Tài Khoản Thành Công!", "success");
                    return RedirectToAction("Index");
                }
                return View(taiKhoan);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Cập nhật tài khoản thất bại " + ex.Message;
                return View("Edit", taiKhoan);
                //throw;
            }
        }

        // GET: Admin/TaiKhoans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoan.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // POST: Admin/TaiKhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                TaiKhoan taiKhoan = db.TaiKhoan.Find(id);
                db.TaiKhoan.Remove(taiKhoan);
                db.SaveChanges();
                setAlert("Xóa Tài Khoản Thành Công!", "success");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Xóa thất bại" + ex.Message;
                return View();
                //throw;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
