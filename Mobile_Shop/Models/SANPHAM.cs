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
    
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            this.BINHLUANs = new HashSet<BINHLUAN>();
            this.CHITIETDONDATHANGs = new HashSet<CHITIETDONDATHANG>();
            this.CHITIETPHIEUNHAPs = new HashSet<CHITIETPHIEUNHAP>();
            this.CHITIETSANPHAMs = new HashSet<CHITIETSANPHAM>();
            this.KHUYENMAIs = new HashSet<KHUYENMAI>();
        }
    
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
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BINHLUAN> BINHLUANs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONDATHANG> CHITIETDONDATHANGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUNHAP> CHITIETPHIEUNHAPs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETSANPHAM> CHITIETSANPHAMs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHUYENMAI> KHUYENMAIs { get; set; }
        public virtual LOAISANPHAM LOAISANPHAM { get; set; }
        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
        public virtual NHASANXUAT NHASANXUAT { get; set; }
    }
}
