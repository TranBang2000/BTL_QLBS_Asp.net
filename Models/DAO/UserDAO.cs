using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;

namespace Models.DAO
{
    public class UserDAO
    {
        VinaMilkDbContext db = null;
        public UserDAO()
        {
            db = new VinaMilkDbContext();

        }
        public string Insert(TaiKhoan1 entity)
        {
            db.TaiKhoans.Add(entity);
            db.SaveChanges();
            return entity.TenTK;

        }

        public object ListAllPaging2(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public TaiKhoan1 GetByID(string tenTK)
        {
            return db.TaiKhoans.FirstOrDefault(x => x.TenTK == tenTK);
        }
        public IEnumerable<TaiKhoan1> GetAllTaiKhoan()
        {
            return db.TaiKhoans.Select(x => x);
        }
        public int Login(string tenTK, string matKhau)
        {
            var result = db.TaiKhoans.SingleOrDefault(x => x.TenTK == tenTK);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Quyen == null)
                {
                    return -3;
                }
                else
                {
                    if (result.Mat_Khau == matKhau)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }
        public IEnumerable<TaiKhoan1> ListAllPaging(string searchString,int page, int pageSize)
        {
            IQueryable<TaiKhoan1> model = db.TaiKhoans;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenTK.Contains(searchString) || x.HoTen.Contains(searchString));
            }
            return model.OrderBy(x=>x.TenTK).ToPagedList(page,pageSize);
        }
        public IEnumerable<DanhMuc> ListAllPaging1(string searchString, int page, int pageSize)
        {
            IQueryable<DanhMuc> model = db.DanhMucs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.MaDM.Contains(searchString) || x.TenDM.Contains(searchString));
            }
            return model.OrderBy(x => x.MaDM).ToPagedList(page, pageSize);
        }
        public IEnumerable<SanPham> ListAllPaging2(string searchString, int page, int pageSize)
        {
            IQueryable<SanPham> model = db.SanPhams;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.MaSP.Contains(searchString) || x.TenSP.Contains(searchString));
            }
            return model.OrderBy(x => x.MaSP).ToPagedList(page, pageSize);
        }

    }
}

