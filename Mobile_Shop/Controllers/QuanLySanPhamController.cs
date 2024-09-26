using Mobile_Shop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mobile_Shop.Controllers
{
    public class QuanLySanPhamController : Controller
    {
        DB_ShopMobileEntities db = new DB_ShopMobileEntities();
        // GET: QuanLySanPham
        public ActionResult Index()
        {
            var listSP = db.SANPHAMs.OrderByDescending(n => n.MaSP);

            return View(listSP);
        }

        [HttpGet]
        public ActionResult TaoMoi()
        {
            // load dropdownlist nhà cung cấp và dropdownlist loại sản phẩm
            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs.OrderBy(n => n.TenNCC), "MaNCC", "TenNCC");
            ViewBag.MaNSX = new SelectList(db.NHASANXUATs.OrderBy(n => n.MaNSX), "MaNSX", "TenNSX");
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult TaoMoi(SANPHAM sp, HttpPostedFileBase HinhChinh, HttpPostedFileBase Hinh1, HttpPostedFileBase Hinh2, HttpPostedFileBase Hinh3)
        {
            // load dropdownlist nhà cung cấp và dropdownlist loại sản phẩm
            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs.OrderBy(n => n.TenNCC), "MaNCC", "TenNCC");
            ViewBag.MaNSX = new SelectList(db.NHASANXUATs.OrderBy(n => n.MaNSX), "MaNSX", "TenNSX");
            // kiểm tra hình ảnh đã tồn tại chưa
            if (HinhChinh.ContentLength > 0)
            {
                // lấy tên hình ảnh
                var fileName = Path.GetFileName(HinhChinh.FileName);

                // lấy hình chuyển vào thư mục hình ảnh
                var path = Path.Combine(Server.MapPath("~/Asset/images/product"), fileName);

                // kiểm tra nếu hình ảnh đã tồn tại thì thông báo hình ảnh đã tồn tại
                if (System.IO.File.Exists(path))
                {
                    ViewBag.UpLoad = "Hình ảnh đã tồn tại";
                    return View();
                }
                else
                {
                    // ngược lại lấy hình ảnh đưa vào thư mục images
                    HinhChinh.SaveAs(path);
                    sp.HinhChinh = fileName;
                }
            }

            if (Hinh1.ContentLength > 0)
            {
                // lấy tên hình ảnh
                var fileName = Path.GetFileName(Hinh1.FileName);

                // lấy hình chuyển vào thư mục hình ảnh
                var path = Path.Combine(Server.MapPath("~/Asset/images/product"), fileName);

                // kiểm tra nếu hình ảnh đã tồn tại thì thông báo hình ảnh đã tồn tại
                if (System.IO.File.Exists(path))
                {
                    ViewBag.UpLoad1 = "Hình ảnh đã tồn tại";
                    return View();
                }
                else
                {
                    // ngược lại lấy hình ảnh đưa vào thư mục images
                    Hinh1.SaveAs(path);
                    sp.Hinh1 = fileName;
                }
            }


            if (Hinh2.ContentLength > 0)
            {
                // lấy tên hình ảnh
                var fileName = Path.GetFileName(Hinh2.FileName);

                // lấy hình chuyển vào thư mục hình ảnh
                var path = Path.Combine(Server.MapPath("~/Asset/images/product"), fileName);

                // kiểm tra nếu hình ảnh đã tồn tại thì thông báo hình ảnh đã tồn tại
                if (System.IO.File.Exists(path))
                {
                    ViewBag.UpLoad2 = "Hình ảnh đã tồn tại";
                    return View();
                }
                else
                {
                    // ngược lại lấy hình ảnh đưa vào thư mục images
                    Hinh2.SaveAs(path);
                    sp.Hinh2 = fileName;
                }
            }

            if (Hinh3.ContentLength > 0)
            {
                // lấy tên hình ảnh
                var fileName = Path.GetFileName(Hinh3.FileName);

                // lấy hình chuyển vào thư mục hình ảnh
                var path = Path.Combine(Server.MapPath("~/Asset/images/product"), fileName);

                // kiểm tra nếu hình ảnh đã tồn tại thì thông báo hình ảnh đã tồn tại
                if (System.IO.File.Exists(path))
                {
                    ViewBag.UpLoad3 = "Hình ảnh đã tồn tại";
                    return View();
                }
                else
                {
                    // ngược lại lấy hình ảnh đưa vào thư mục images
                    Hinh3.SaveAs(path);
                    sp.Hinh3 = fileName;
                }
            }
            db.SANPHAMs.Add(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ChinhSua(int? id)
        {
            // lấy sản phẩm cần chỉnh sửa dựa vào id
            if (id == null)
            {
                return RedirectToAction("Error404", "Home");
            }

            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MaSP == id);
            if (sp == null)
            {
                return HttpNotFound();
            }

            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs.OrderBy(n => n.TenNCC), "MaNCC", "TenNCC", sp.MaNCC);
            ViewBag.MaNSX = new SelectList(db.NHASANXUATs.OrderBy(n => n.MaNSX), "MaNSX", "TenNSX", sp.MaNSX);

            return View(sp);
        }

        [HttpPost]
        public ActionResult ChinhSua(SANPHAM model)
        {
            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs.OrderBy(n => n.TenNCC), "MaNCC", "TenNCC", model.MaNCC);
            ViewBag.MaNSX = new SelectList(db.NHASANXUATs.OrderBy(n => n.MaNSX), "MaNSX", "TenNSX", model.MaNSX);
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Xoa(int? id)
        {
            // lấy sản phẩm cần chỉnh sửa dựa vào id
            if (id == null)
            {
                return RedirectToAction("Error404", "Home");
            }

            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MaSP == id);
            if (sp == null)
            {
                return HttpNotFound();
            }

            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs.OrderBy(n => n.TenNCC), "MaNCC", "TenNCC", sp.MaNCC);
            ViewBag.MaNSX = new SelectList(db.NHASANXUATs.OrderBy(n => n.MaNSX), "MaNSX", "TenNSX", sp.MaNSX);
            return View(sp);
        }

        [HttpPost]
        public ActionResult Xoa(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            SANPHAM model = db.SANPHAMs.SingleOrDefault(n => n.MaSP == id);
            if (model == null)
            {
                return HttpNotFound();
            }
            db.SANPHAMs.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}