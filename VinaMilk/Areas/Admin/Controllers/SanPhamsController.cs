using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using PagedList;
using VinaMilk.Models;
using System.Web.Mvc;

namespace VinaMilk.Areas.Admin.Controllers
{
    public class SanPhamsController : BaseController
    {
        private VinaMilkDbContext db = new VinaMilkDbContext();

        // GET: Admin/SanPhams
        public ActionResult Index(string sortOrder, string searchString, string currenFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SapTheoMa = String.IsNullOrEmpty(sortOrder) ? "ma_asc" : "";
            ViewBag.SapTheoGia = sortOrder == "gia" ? "gia_desc" : "gia";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currenFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var sanphams = db.SanPham.Select(s => s);
            if (!String.IsNullOrEmpty(searchString))
            {
                sanphams = sanphams.Where(s => s.TenSP.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "ma_asc":
                    sanphams = sanphams.OrderByDescending(s => s.MaSP);
                    break;
                case "gia":
                    sanphams = sanphams.OrderBy(s => s.GiaHT);
                    break;
                case "gia_desc":
                    sanphams = sanphams.OrderByDescending(s => s.GiaHT);
                    break;
                default:
                    sanphams = sanphams.OrderBy(s => s.MaSP);
                    break;
            }
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            //var sanPham = db.SanPham.Include(s => s.DanhMuc);
            //return View(sanphams.ToPagedList(pageNumber,pageSize))
            return View(sanphams.ToList());
        }
        // GET: Admin/SanPhams/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.MaDM = new SelectList(db.DanhMuc, "MaDM", "TenDM");
            return View();
        }

        // POST: Admin/SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,Anh,SoLuongCo,GiaHT,MoTa,MaDM")] SanPham sanPham)
        {

            try
            {
                if (true)
                {
                    sanPham.Anh = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string fileName = System.IO.Path.GetFileName(f.FileName);
                        string uploadPath = Server.MapPath("~/wwwroot/Images/" + fileName);
                        f.SaveAs(uploadPath);
                        sanPham.Anh = fileName;
                    }
                    
                    db.SanPham.Add(sanPham);
                    db.SaveChanges();
                    setAlert("Thêm Mới Sản Phẩm Thành Công!", "success");
                    return RedirectToAction("Index");
                }

                //ViewBag.MaDM = new SelectList(db.DanhMuc, "MaDM", "TenDM", sanPham.MaDM);
                //return View(sanPham);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Thêm sản phẩm thất bại " + ex.Message;
                return View(sanPham);
                //throw;
            }

        }

        // GET: Admin/SanPhams/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDM = new SelectList(db.DanhMuc, "MaDM", "TenDM", sanPham.MaDM);
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,Anh,SoLuongCo,GiaHT,MoTa,MaDM")] SanPham sanPham)
        {
            try
            {
                if (true)
                {
                    sanPham.Anh = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string fileName = System.IO.Path.GetFileName(f.FileName);
                        string uploadPath = Server.MapPath("~/wwwroot/Images/" + fileName);
                        f.SaveAs(uploadPath);
                        sanPham.Anh = fileName;
                    }
                    db.Entry(sanPham).State = EntityState.Modified;
                    db.SaveChanges();
                    setAlert("Cập Nhật Sản Phẩm Thành Công!", "success");
                return RedirectToAction("Index");
                }
                ViewBag.MaDM = new SelectList(db.DanhMuc, "MaDM", "TenDM", sanPham.MaDM);
                return View(sanPham);
            }
            catch (Exception ex)
            {

                ViewBag.Error = "Cập nhật sản phẩm thất bại " + ex.Message;
                return View("Edit", sanPham);
            }
        }
           
        // GET: Admin/SanPhams/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                SanPham sanPham = db.SanPham.Find(id);
                db.SanPham.Remove(sanPham);
                db.SaveChanges();
                setAlert("Xóa Sản Phẩm Thành Công!", "success");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Xóa sản phẩm thất bại " + ex.Message;
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
