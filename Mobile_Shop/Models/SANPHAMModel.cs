using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mobile_Shop.Models
{
    public class SANPHAMModel
    {
        public int MaSP { get; set; }
        public Nullable<int> MaNCC { get; set; }
        public Nullable<int> MaNSX { get; set; }
        public Nullable<int> MaLSP { get; set; }
        public string TenSP { get; set; }
        public Nullable<decimal> DonGia { get; set; }
        public Nullable<System.DateTime> NgayCapNhat { get; set; }
        public string MoTa { get; set; }
        public string HinhChinh { get; set; }
        public string Hinh1 { get; set; }
        public string Hinh2 { get; set; }
        public string Hinh3 { get; set; }
        public Nullable<int> SoLuongBan { get; set; }
        public Nullable<int> SoLuongTon { get; set; }
        public Nullable<int> LuotXem { get; set; }
        public Nullable<int> LuotBinhChon { get; set; }
        public string LuotBinhLuan { get; set; }
        public Nullable<int> Moi { get; set; }
        public Nullable<bool> DaXoa { get; set; }
    }
}