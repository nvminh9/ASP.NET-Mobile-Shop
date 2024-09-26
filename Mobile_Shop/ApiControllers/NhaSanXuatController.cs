using Mobile_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mobile_Shop.ApiControllers
{
    public class NhaSanXuatController : ApiController
    {
        // api/nhasanxuat (trả về tất cả sản phẩm)
        public IEnumerable<NHASANXUAT> Get()
        {
            using (DB_ShopMobileEntities dbContext = new DB_ShopMobileEntities())
            {
                return dbContext.NHASANXUATs.AsNoTracking().ToList();
            }
        }

        // api/nhasanxuat/id (trả về sản phẩm với id đc truyền)
        public NHASANXUAT Get(int id)
        {
            using (DB_ShopMobileEntities dbContext = new DB_ShopMobileEntities())
            {
                return dbContext.NHASANXUATs.FirstOrDefault(e => e.MaNSX == id);
            }
        }
    }
}
