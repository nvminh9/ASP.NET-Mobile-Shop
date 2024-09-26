using Mobile_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Mobile_Shop.Controllers
{
    public class TimKiemController : Controller
    {
        DB_ShopMobileEntities db = new DB_ShopMobileEntities();
        // GET: TimKiem
        [HttpGet]
        public ActionResult KQTimKiem(string pTuKhoa, int? Page)
        {
            var listSP = db.SANPHAMs.Where(n => n.TenSP.Contains(pTuKhoa));
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
            //Tìm kiếm sản phẩm
            ViewBag.TuKhoa = pTuKhoa;
            return View(listSP.OrderBy(n => n.TenSP).ToPagedList(PageNumber, PageSize));
        }

        [HttpPost]
        public ActionResult KQTimKiem(string pTuKhoa, int? Page, FormCollection f)
        {
            var listSP = db.SANPHAMs.Where(n => n.TenSP.Contains(pTuKhoa));
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
            //Tìm kiếm sản phẩm
            ViewBag.TuKhoa = pTuKhoa;
            return View(listSP.OrderBy(n => n.TenSP).ToPagedList(PageNumber, PageSize));
        }

        public ActionResult KQTimKiemPartial(string pTuKhoa)
        {
            var listSP = db.SANPHAMs.Where(n => n.TenSP.Contains(pTuKhoa));
            ViewBag.TuKhoa = pTuKhoa;

            return PartialView(listSP.OrderBy(n => n.DonGia));
        }
    }
}