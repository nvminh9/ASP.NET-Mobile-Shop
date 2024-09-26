using Mobile_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Mobile_Shop.Controllers
{
    public class ShopController : Controller
    {
        DB_ShopMobileEntities objModel = new DB_ShopMobileEntities();
        // GET: Shop

        public ActionResult Index()
        {
            var listSP = objModel.SANPHAMs.Where(n => n.Moi == 1);
            return View(listSP);
        }

        // Xây dựng 1 action load sản phẩm theo mã nhà sản xuất
        public ActionResult SanPham(int? MaNSX)
        {
            if (MaNSX == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            var listSP = objModel.SANPHAMs.Where(n => n.MaNSX == MaNSX);
            return View(listSP);

        }

        public ActionResult Details(int id)
        {
            var obj = objModel.SANPHAMs.Where(n => n.MaSP == id).FirstOrDefault();
            ViewBag.lstSP = objModel.SANPHAMs.ToList();
            return View(obj);
        }

        public ActionResult SanPhamPartial(int? Page)
        {
            var listSP = objModel.SANPHAMs;
            if (listSP.Count() == 0)
            {
                // thông báo nếu ko có sản phẩm
                return HttpNotFound();
            }
            if (Request.HttpMethod != "GET")
            {
                Page = 1;
            }
            // thực hiện chức năng phân trang
            // tạo biến số sản phẩm bên trang
            int PageSize = 9;
            // tạo biến số trang hiện tại
            int PageNumber = (Page ?? 1);

            return PartialView(listSP.OrderBy(n => n.MaSP).ToPagedList(PageNumber, PageSize));
        }

        public ActionResult SanPhamLienQuanPartial(int id)
        {
            var listSP = objModel.SANPHAMs.Where(n => n.MaNSX == id);
            return PartialView(listSP);
        }
    }
}