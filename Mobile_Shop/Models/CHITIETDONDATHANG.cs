//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mobile_Shop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHITIETDONDATHANG
    {
        public int MaCTDDH { get; set; }
        public Nullable<int> MaDDH { get; set; }
        public Nullable<int> MaSP { get; set; }
        public string TenSP { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<decimal> DonGia { get; set; }
    
        public virtual DONDATHANG DONDATHANG { get; set; }
        public virtual SANPHAM SANPHAM { get; set; }
    }
}
