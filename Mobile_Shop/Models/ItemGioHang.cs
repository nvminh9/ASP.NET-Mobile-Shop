using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mobile_Shop.Models
{
    public class ItemGioHang
    {
        public string TenSP { get; set; }
        public int MaSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        public string HinhAnh { get; set; }

        public ItemGioHang(int pMaSP)
        {
            using (DB_ShopMobileEntities db = new DB_ShopMobileEntities())
            {
                this.MaSP = pMaSP;
                SANPHAM sp = db.SANPHAMs.Single(n => n.MaSP == pMaSP);
                this.TenSP = sp.TenSP;
                this.HinhAnh = sp.HinhChinh;
                this.SoLuong = 1;
                this.DonGia = sp.DonGia.Value;
                this.ThanhTien = SoLuong * DonGia;
            }
        }

        public ItemGioHang(int pMaSP, int pSoLuong)
        {
            using (DB_ShopMobileEntities db = new DB_ShopMobileEntities())
            {
                this.MaSP = pMaSP;
                SANPHAM sp = db.SANPHAMs.Single(n => n.MaSP == pMaSP);
                this.TenSP = sp.TenSP;
                this.HinhAnh = sp.HinhChinh;
                this.DonGia = sp.DonGia.Value;
                this.SoLuong = pSoLuong;
                this.ThanhTien = SoLuong * DonGia;
            }
        }

    }
}