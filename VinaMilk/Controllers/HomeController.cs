using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using VinaMilk.Common;
//using VinaMilk.Models;
using Models.DAO;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Web.UI;

namespace VinaMilk.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        VinaMilkDbContext db = new VinaMilkDbContext();
        public ActionResult Index(string searchString, int page = 1, int pageSize = 20)
        {
            var dao = new UserDAO();
            var model = dao.ListAllPaging1(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [ChildActionOnly]
        public ActionResult ProductCartelogy()
        {
            var model = db.DanhMucs.Select(x => x).ToList();
            return PartialView(model);
        }
        public ActionResult Products(string id,string searchString, int page=1, int pageSize=4)
        {
            var dao = new UserDAO();
            var model = dao.ListAllPaging2(id, searchString, page, pageSize);
            //ViewBag.SearchString = searchString;
            return View(model);
            List<SanPham> sp = new List<SanPham>();
            if (id == null)
            {
                sp = db.SanPhams.Select(s => s).ToList();
            }
            else
            {
                //Lấy hàng theo mã nhà cugn cấp được chọn
                sp = db.SanPhams.Where(s => s.MaDM.Equals(id)).Select(s => s).ToList();
            }
            return View(model);
        }
    }
}