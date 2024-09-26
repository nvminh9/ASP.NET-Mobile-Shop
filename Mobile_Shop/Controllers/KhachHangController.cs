using Mobile_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mobile_Shop.Controllers
{
    [Authorize(Roles = "QuanLyKhachHang,QuanLySanPham")]
    public class KhachHangController : Controller
    {

        DB_ShopMobileEntities db = new DB_ShopMobileEntities();
        // GET: KhachHang
        [Authorize(Roles = "QuanLySanPham,QuanLyKhachHang")]
        public ActionResult Index()
        {
            List<KHACHHANG> listKH = db.KHACHHANGs.ToList();
            return View(listKH);
        }

        [Authorize(Roles = "QuanLySanPham,QuanLyKhachHang")]
        public ActionResult SortDuLieu()
        {
            // phương thức sắp xếp dữ liệu
            List<KHACHHANG> listKH = db.KHACHHANGs.OrderBy(n => n.TenKH).ToList();
            return View(listKH);
        }
    }
}