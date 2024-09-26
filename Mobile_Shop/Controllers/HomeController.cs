using Mobile_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mobile_Shop.Controllers
{
    public class HomeController : Controller
    {
        DB_ShopMobileEntities objModel = new DB_ShopMobileEntities();
        // GET: Home
        public ActionResult Index()
        {
            var listSP = objModel.SANPHAMs.Where(n => n.Moi == 1);
            return View(listSP);
        }
        public ActionResult GioiThieu()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        // action Đăng ký thành viên
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(THANHVIEN tv)
        {
            // thêm khách hàng vào cơ sở dữ liệu
            int check = objModel.THANHVIENs.Where(n => n.TaiKhoan == tv.TaiKhoan).Count();
            int checkDupliEmail = objModel.THANHVIENs.Where(n => n.Email == tv.Email).Count();
            if (check != 0 || checkDupliEmail != 0)
            {
                ViewBag.ThongBao = "Đăng ký thất bại, Email hoặc Username đã tồn tại !";
                //return RedirectToAction("DangKy", "Home");
            }
            else
            {
                if (tv != null)
                {
                    ViewBag.ThongBao = "Đăng ký thành công";
                    tv.MaLTV = 3;
                    objModel.THANHVIENs.Add(tv);
                    objModel.SaveChanges();
                }
            }



            return View();
        }


        // action đăng nhập
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {

            string taikhoan = f["Name"].ToString();
            string matkhau = f["password"].ToString();
            // truy vấn kiểm tra đăng nhập lấy thông tin thành viên
            THANHVIEN tv = objModel.THANHVIENs.SingleOrDefault(n => n.TaiKhoan == taikhoan && n.MatKhau == matkhau);
            if (tv != null)
            {
                Session["TaiKhoan"] = tv;
                if (tv.MaLTV == 3 || tv.MaLTV == 4)
                {
                    Session["TaiKhoan"] = tv;
                    return RedirectToAction("Index");
                }
                else
                {
                    // lấy ra list quyền của thành viên tương ứng với loại thành viên
                    var listQuyen = objModel.LOAITHANHVIEN_QUYEN.Where(n => n.MaLTV == tv.MaLTV);
                    // duyệt list quyền 
                    string Quyen = "";
                    foreach (var item in listQuyen)
                    {
                        Quyen += item.MaQuyen + ",";
                    }
                    Quyen = Quyen.Substring(0, Quyen.Length - 1);// cắt dấu ,
                    PhanQuyen(tv.TaiKhoan.ToString(), Quyen);
                    return RedirectToAction("Index", "Admin");
                }

            }
            else
            {
                return Content("Tài khoản hoặc mật khẩu không đúng");
            }
        }

        public void PhanQuyen(string TaiKhoan, string Quyen)
        {
            FormsAuthentication.Initialize();
            var ticker = new FormsAuthenticationTicket(1, TaiKhoan, DateTime.Now, DateTime.Now.AddHours(3), false, Quyen, FormsAuthentication.FormsCookiePath);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticker));
            if (ticker.IsPersistent) cookie.Expires = ticker.Expiration;
            Response.Cookies.Add(cookie);
        }

        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }



        public ActionResult Error404()
        {
            return View();
        }

        //tạo trang ngăn chặn quyền truy cập
        public ActionResult LoiPhanQuyen()
        {
            return View();
        }

        // partial MENU đa cấp động
        public ActionResult MenuPartial()
        {
            var listSP = objModel.SANPHAMs;
            return PartialView(listSP);
        }

        public ActionResult IphonePartial()
        {
            var listIPhone = objModel.SANPHAMs.Where(t => t.MaNCC == 3);
            return PartialView(listIPhone);
        }

        public ActionResult SamSungPartial()
        {
            var listSamSung = objModel.SANPHAMs.Where(t => t.MaNCC == 2);
            return PartialView(listSamSung);
        }

        public ActionResult OPPOPartial()
        {
            var listOPPO = objModel.SANPHAMs.Where(t => t.MaNCC == 5);
            return PartialView(listOPPO);
        }
    }
}