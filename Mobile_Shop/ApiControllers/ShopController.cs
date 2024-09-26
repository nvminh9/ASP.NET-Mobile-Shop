using Mobile_Shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Web.DynamicData;

namespace Mobile_Shop.ApiControllers
{
    public class ShopController : ApiController
    {
        // GET api/shop (get all product)
        public List<SANPHAM> GetSANPHAMs()
        {
            using (DB_ShopMobileEntities dbContext = new DB_ShopMobileEntities())
            {
                return dbContext.SANPHAMs.AsNoTracking().ToList();
            }
        }

        // api/shop/id_nsx (trả về các sản phẩm với id của nsx)
        public List<SANPHAM> GetSanPhamByBrand(int id)
        {
            using (DB_ShopMobileEntities dbContext = new DB_ShopMobileEntities())
            {
                return dbContext.SANPHAMs.Where(e => e.MaNSX == id).ToList();
            }
        }
    }
}