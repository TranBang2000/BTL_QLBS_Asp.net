using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Model.DAO
{
    public class ProductDAO
    {
        VinaMilkDbContext db = null;
        public ProductDAO()
        {
            db = new VinaMilkDbContext();
        }
        public List<DanhMuc> GetAllDanhmuc()
        {
            return db.DanhMucs.Select(x => x).ToList();
        }
    }
}
