using Mobile_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mobile_Shop.ApiControllers
{
    public class SanPhamController : ApiController
    {
        // api/sanpham (trả về tất cả sản phẩm)
        public IEnumerable<SANPHAM> Get()
        {
            using (DB_ShopMobileEntities dbContext = new DB_ShopMobileEntities())
            {
                return dbContext.SANPHAMs.AsNoTracking().ToList();
            }
        }

        // api/sanpham/id (trả về sản phẩm với id đc truyền)
        public SANPHAM Get(int id)
        {
            using (DB_ShopMobileEntities dbContext = new DB_ShopMobileEntities())
            {
                return dbContext.SANPHAMs.FirstOrDefault(e => e.MaSP == id);
            }
        }

        // Sửa
        // api/sanpham (cập nhật thông tin sản phẩm theo id lay tu SANPHAM)
        public void PutSanPham(SANPHAM sanpham)
        {
            using (DB_ShopMobileEntities dbContext = new DB_ShopMobileEntities())
            {
                SANPHAM oldsanpham = dbContext.SANPHAMs.Where(row => row.MaSP == sanpham.MaSP).FirstOrDefault();
                oldsanpham.TenSP = sanpham.TenSP;
                oldsanpham.DonGia = sanpham.DonGia;
                oldsanpham.MoTa = sanpham.MoTa;
                dbContext.SaveChanges();
            }
        }

        // Xóa
        // api/sanpham/id (Xóa Sản phẩm theo id truyền vào)
        public void DeleteSanPham(long id)
        {
            using (DB_ShopMobileEntities dbContext = new DB_ShopMobileEntities())
            {
                SANPHAM oldsanpham = dbContext.SANPHAMs.Where(row => row.MaSP == id).FirstOrDefault();
                dbContext.SANPHAMs.Remove(oldsanpham);
                dbContext.SaveChanges();
            }
        }
    }
}
