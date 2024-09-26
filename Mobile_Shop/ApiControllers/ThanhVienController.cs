using Mobile_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mobile_Shop.ApiControllers
{
    public class ThanhVienController : ApiController
    {
        // api/thanhvien (trả về tất cả thành viên)
        public IEnumerable<THANHVIEN> Get()
        {
            using (DB_ShopMobileEntities dbContext = new DB_ShopMobileEntities())
            {
                return dbContext.THANHVIENs.AsNoTracking().ToList();
            }
        }

        // api/thanhvien/id (trả về thành viên với id đc truyền)
        public THANHVIEN Get(int id)
        {
            using (DB_ShopMobileEntities dbContext = new DB_ShopMobileEntities())
            {
                return dbContext.THANHVIENs.FirstOrDefault(e => e.MaTV == id);
            }
        }

        // api/thanhvien (cập nhật thông tin thành viên theo id lay tu thanhvien)
        public void PutThanhVien(THANHVIEN thanhvien)
        {
            using(DB_ShopMobileEntities dbContext = new DB_ShopMobileEntities())
            {
                THANHVIEN oldThanhVien = dbContext.THANHVIENs.Where(row => row.MaTV == thanhvien.MaTV).FirstOrDefault();
                oldThanhVien.HoTen = thanhvien.HoTen;
                oldThanhVien.DiaChi = thanhvien.DiaChi;
                oldThanhVien.SoDienThoai = thanhvien.SoDienThoai;
                dbContext.SaveChanges();
            }
        }

        // api/thanhvien/id (Xóa Thành viên theo id truyền vào)
        public void DeleteThanhVien(long id)
        {
            using (DB_ShopMobileEntities dbContext = new DB_ShopMobileEntities())
            {
                THANHVIEN oldThanhVien = dbContext.THANHVIENs.Where(row => row.MaTV == id).FirstOrDefault();
                dbContext.THANHVIENs.Remove(oldThanhVien);
                dbContext.SaveChanges();
            }
        }
    }
}
