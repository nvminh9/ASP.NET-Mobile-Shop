using Mobile_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mobile_Shop.Controllers
{
    public class GioHangController : Controller
    {
        DB_ShopMobileEntities db = new DB_ShopMobileEntities();
        // Lấy giỏ hàng
        public List<ItemGioHang> LayGioHang()
        {
            // giỏ hàng tồn tại
            List<ItemGioHang> listGioHang = Session["GioHang"] as List<ItemGioHang>;
            if (listGioHang == null)
            {
                listGioHang = new List<ItemGioHang>();
                Session["GioHang"] = listGioHang;
            }
            return listGioHang;
        }

        // Thêm giỏ hàng thông thường (Load lại trang)
        public ActionResult ThemGioHang(int pMaSP, string strUrl)
        {
            // Kiểm tra sản phẩm có tồn tại trong CSDL hay không
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MaSP == pMaSP);
            if (sp == null)
            {
                // trang đường dẫn không hợp lệ
                return RedirectToAction("Error404", "Home");
            }
            // Lấy giỏ hàng
            List<ItemGioHang> listGioHang = LayGioHang();

            //Trường hợp 1  nếu sản phẩm đã tồn tại trong giỏ hàng
            ItemGioHang spCheck = listGioHang.SingleOrDefault(n => n.MaSP == pMaSP);

            if (spCheck != null)
            {
                // kiểm tra số lượng tồn trước khi cho khách hàng đặt hàng
                if (sp.SoLuongTon < spCheck.SoLuong)
                {
                    return View("ThongBao");
                }
                spCheck.SoLuong++;
                spCheck.ThanhTien = spCheck.SoLuong * spCheck.DonGia;
                return Redirect(strUrl);
            }
            ItemGioHang itemGH = new ItemGioHang(pMaSP);
            if (sp.SoLuongTon < itemGH.SoLuong)
            {
                return View("ThongBao");
            }
            listGioHang.Add(itemGH);
            return Redirect(strUrl);

        }

        // Tính tổng số lượng
        public double TinhTongSoLuong()
        {
            // lấy giỏ hàng 
            List<ItemGioHang> listGioHang = Session["GioHang"] as List<ItemGioHang>;
            if (listGioHang == null)
                return 0;
            return listGioHang.Sum(n => n.SoLuong);

        }

        // Tính tổng tiền
        public decimal TinhTongTien()
        {
            // lấy giỏ hàng 
            List<ItemGioHang> listGioHang = Session["GioHang"] as List<ItemGioHang>;
            if (listGioHang == null)
                return 0;
            return listGioHang.Sum(n => n.ThanhTien);
        }


        // GET: GioHang
        public ActionResult XemGioHang()
        {
            // lấy giỏ hàng
            List<ItemGioHang> listGH = LayGioHang();

            return View(listGH);
        }


        // nút giỏ hàng ở trên đầu gốc phải
        public ActionResult GioHangPartial()
        {
            if (TinhTongSoLuong() == 0)
            {
                ViewBag.TongSoLuong = 0;
                ViewBag.TongTien = 0;
                return PartialView();
            }
            ViewBag.TongSoLuong = TinhTongSoLuong();
            ViewBag.TongTien = TinhTongTien();
            return PartialView();
        }


        // Chỉnh sửa giỏ hàng
        [HttpGet]
        public ActionResult SuaGioHang(int pMaSP)
        {
            // Kiểm tra session có tồn tại trong giỏ hàng chưa
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            // Kiểm tra sản phẩm có tồn tại trong CSDL hay không
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MaSP == pMaSP);
            if (sp == null)
            {
                // trang đường dẫn không hợp lệ
                return RedirectToAction("Error404", "Home");
            }
            // lấy list giỏ hàng từ sesion
            List<ItemGioHang> listGioHang = LayGioHang();
            // Kiểm tra xem sản phẩm đó có tồn tại trong giỏ hàng hay không
            ItemGioHang spCheck = listGioHang.SingleOrDefault(n => n.MaSP == pMaSP);
            if (spCheck == null)
            {
                return RedirectToAction("Index", "Home");
            }

            // lấy list giỏ hàng tạo giao diện
            ViewBag.GioHang = listGioHang;
            return View(spCheck);
        }

        // Xử lý cập nhật giỏ hàng
        [HttpPost]
        public ActionResult CapNhatGioHang(int MaSP, int SoLuong)
        {
            SANPHAM spCheck = db.SANPHAMs.Single(n => n.MaSP == MaSP);
            if (spCheck.SoLuongBan < SoLuong)
            {
                return View("ThongBao");
            }
            //Cập nhật số lượng trong seesion giỏ hang
            // bước 1: lấy list<GioHang> từ session ["GioHang"]
            List<ItemGioHang> listGH = LayGioHang();
            ItemGioHang itemGHUpdate = listGH.Find(n => n.MaSP == MaSP);
            // Bước 2: Lấy sản phẩm cần cập nhật từ trong list<GioHang> ra
            itemGHUpdate.SoLuong = SoLuong;
            // Bước 3: Tiến hành cập nhật lại số lượng của thành tiền
            itemGHUpdate.ThanhTien = itemGHUpdate.SoLuong * itemGHUpdate.DonGia;
            return RedirectToAction("XemGioHang");
        }

        public ActionResult XoaGioHang(int pMaSP)
        {
            // Kiểm tra session có tồn tại trong giỏ hàng chưa
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            // Kiểm tra sản phẩm có tồn tại trong CSDL hay không
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MaSP == pMaSP);
            if (sp == null)
            {
                // trang đường dẫn không hợp lệ
                return RedirectToAction("Error404", "Home");
            }
            // lấy list giỏ hàng từ sesion
            List<ItemGioHang> listGioHang = LayGioHang();
            // Kiểm tra xem sản phẩm đó có tồn tại trong giỏ hàng hay không
            ItemGioHang spCheck = listGioHang.SingleOrDefault(n => n.MaSP == pMaSP);
            if (spCheck == null)
            {
                return RedirectToAction("Index", "Home");
            }

            // Xóa item trong giỏ hàng
            listGioHang.Remove(spCheck);
            return RedirectToAction("XemGioHang");
        }

        public ActionResult DatHang(KHACHHANG kh)
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            KHACHHANG khach = new KHACHHANG();
            if (Session["TaiKhoan"] == null)
            {
                // thêm khách hàng vào bảng khách hàng đối với khách hàng vãng lai (chưa có đăng ký tài khoản)
                khach = kh;
                db.KHACHHANGs.Add(khach);
                db.SaveChanges();
                ViewBag.ThongBao = "Dat hang thanh cong";
            }
            else
            {
                // đối với khách hàng là thành viên
                THANHVIEN tv = Session["TaiKhoan"] as THANHVIEN;
                khach.TenKH = tv.HoTen;
                khach.DiaChi = tv.DiaChi;
                khach.SoDienThoai = tv.SoDienThoai;
                khach.MaTV = tv.MaTV;
                db.KHACHHANGs.Add(khach);
                db.SaveChanges();
            }

            //thêm đơn hàng
            DONDATHANG ddh = new DONDATHANG();
            ddh.MaKH = khach.MaKH;
            ddh.NgayDat = DateTime.Now;
            ddh.TrinhTrangGiao = false;
            ddh.DaThanhToan = false;
            ddh.UuDai = 0;
            ddh.DaHuy = false;
            ddh.DaXoa = false;
            db.DONDATHANGs.Add(ddh);
            db.SaveChanges();
            //thêm chi tiết đơn đặt hàng
            List<ItemGioHang> listGH = LayGioHang();
            foreach (var item in listGH)
            {
                CHITIETDONDATHANG ctdh = new CHITIETDONDATHANG();
                ctdh.MaDDH = ddh.MaDDH;
                ctdh.MaSP = item.MaSP;
                ctdh.TenSP = item.TenSP;
                ctdh.SoLuong = item.SoLuong;
                ctdh.DonGia = item.DonGia;
                db.CHITIETDONDATHANGs.Add(ctdh);
            }
            db.SaveChanges();
            Session["GioHang"] = null;
            return RedirectToAction("XemGioHang");

        }
    }
}