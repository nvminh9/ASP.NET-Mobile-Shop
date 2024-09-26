using Mobile_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mobile_Shop.ApiControllers
{
    public class KhachHangController : ApiController
    {
        // api/khachhang (trả về tất cả khách hàng)
        public IEnumerable<KHACHHANG> Get()
        {
            using (DB_ShopMobileEntities dbContext = new DB_ShopMobileEntities())
            {
                return dbContext.KHACHHANGs.AsNoTracking().ToList();
            }
        }

        // api/khachhang/id (trả về khách hàng với id đc truyền)
        public KHACHHANG Get(int id)
        {
            using (DB_ShopMobileEntities dbContext = new DB_ShopMobileEntities())
            {
                return dbContext.KHACHHANGs.FirstOrDefault(e => e.MaKH == id);
            }
        }
    }
}
