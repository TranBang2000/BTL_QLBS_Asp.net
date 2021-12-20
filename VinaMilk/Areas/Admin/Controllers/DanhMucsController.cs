using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VinaMilk.Models;
using PagedList;
using PagedList.Mvc;

namespace VinaMilk.Areas.Admin.Controllers
{
    public class DanhMucsController : BaseController
    {
        private VinaMilkDbContext db = new VinaMilkDbContext();

        // GET: Admin/DanhMucs
        public ActionResult Index(string sortOrder, string searchString, string currenFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SapTheoTen = String.IsNullOrEmpty(sortOrder) ? "ten_desc" : "";
            ViewBag.SapTheoMa = sortOrder == "ma" ? "ma_desc" : "ma";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currenFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var danhmucs = db.DanhMuc.Select(s => s);
            if (!String.IsNullOrEmpty(searchString))
            {
                danhmucs = danhmucs.Where(s => s.TenDM.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "ten_desc":
                    danhmucs = danhmucs.OrderByDescending(s => s.TenDM);
                    break;
                case "ma":
                    danhmucs = danhmucs.OrderBy(s => s.MaDM);
                    break;
                case "ma_desc":
                    danhmucs = danhmucs.OrderByDescending(s => s.MaDM);
                    break;
                default:
                    danhmucs = danhmucs.OrderBy(s => s.TenDM);
                    break;
            }
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            //return View(danhmucs.ToPagedList((pageNumber, pageSize)));
            return View(danhmucs.ToList());
            //return View(db.DanhMuc.ToList());
        }

        // GET: Admin/DanhMucs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMuc.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }

        // GET: Admin/DanhMucs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DanhMucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDM,TenDM")] DanhMuc danhMuc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.DanhMuc.Add(danhMuc);
                    db.SaveChanges();
                    setAlert("Thêm Mới Danh Mục Thành Công!", "success");
                    return RedirectToAction("Index");
                }

                return View(danhMuc);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Thêm danh mục thất bại " + ex.Message;
                return View("Create", danhMuc);
                //throw;
            }
        }

        // GET: Admin/DanhMucs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMuc.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }

        // POST: Admin/DanhMucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDM,TenDM")] DanhMuc danhMuc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(danhMuc).State = EntityState.Modified;
                    db.SaveChanges();
                    setAlert("Sửa Danh Mục Thành Công!", "success");
                    return RedirectToAction("Index", "DanhMucs");
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = "Cập nhật danh mục thất bại " + e.Message;
                return View("Edit", danhMuc);
                //throw;
            }
            return View();
        }

        // GET: Admin/DanhMucs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMuc.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }

        // POST: Admin/DanhMucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                DanhMuc danhMuc = db.DanhMuc.Find(id);
                db.DanhMuc.Remove(danhMuc);
                db.SaveChanges();
                setAlert("Xóa Danh Mục Thành Công!", "success");
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
