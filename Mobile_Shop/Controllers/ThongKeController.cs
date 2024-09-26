using Mobile_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mobile_Shop.Controllers
{
    public class ThongKeController : Controller
    {
        DB_ShopMobileEntities db = new DB_ShopMobileEntities();
        // GET: ThongKe
        [Authorize(Roles = "QuanLyKhachHang,QuanLySanPham")]
        public ActionResult Index()
        {
            ViewBag.SoNguoiTruyCap = HttpContext.Application["SoNguoiTruyCap"].ToString(); // lấy số lượng người truy cập application
            ViewBag.SoNguoiDangOnline = HttpContext.Application["SoNguoiDangOnline"].ToString(); // lấy số lượng người truy cập application
            ViewBag.TongDoanhThu = ThongKeDoanhThu();// thống kê tổng doanh thu
            ViewBag.TongThanhVien = ThongKeThanhVien();
            ViewBag.TongDonDatHang = ThongKeDonHang();
            return View();
        }

        public double ThongKeDonHang()
        {
            return db.DONDATHANGs.Count();
        }

        public double ThongKeThanhVien()
        {
            return db.THANHVIENs.Count();
        }

        public decimal ThongKeDoanhThu()
        {
            // thông kê theo tất cả doanh thu từ khi web thành lập
            decimal TongDoanhThu = db.CHITIETDONDATHANGs.Sum(n => n.SoLuong * n.DonGia).Value;
            return TongDoanhThu;

        }

        public decimal ThongKeDoanhThuTheoThang(int Thang, int Nam)
        {
            // thông kê theo tất cả doanh thu từ khi web thành lập
            var listDDH = db.DONDATHANGs.Where(n => n.NgayDat.Value.Month == Thang && n.NgayDat.Value.Year == Nam);
            decimal TongTien = 0;
            foreach (var item in listDDH)
            {
                TongTien += item.CHITIETDONDATHANGs.Sum(n => n.SoLuong * n.DonGia).Value;
            }
            return TongTien;


        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                }
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}