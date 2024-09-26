using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mobile_Shop.Models.Metdata
{
    [MetadataType(typeof(THANHVIENMETADATA))]
    public partial class THANHVIEN
    {
        internal sealed class THANHVIENMETADATA
        {

            public int MaTV { get; set; }
            public Nullable<int> MaLTV { get; set; }

            [Required(ErrorMessage = "{0} Không được để trống")]
            [StringLength(10, ErrorMessage = "Tài khoản không quá 10 ký tự")]
            public string TaiKhoan { get; set; }

            public string MatKhau { get; set; }
            public string HoTen { get; set; }
            public string DiaChi { get; set; }



            [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "{0} Email không hợp lẹ")]
            public string Email { get; set; }

            [StringLength(10, ErrorMessage = "Số điện thoại không quá 10 ký tự")]
            public string SoDienThoai { get; set; }
            public string CauHoi { get; set; }
            public string CauTraLoi { get; set; }


        }
    }
}