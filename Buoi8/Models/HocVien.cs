using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi8.Models
{
    public class HocVien
    {
        [DisplayName("Mã học viên")]
        public int MaSo { get;set; }
        [DisplayName("Tên học viên")]
        public string TenHocVien { get;set; }
        [DisplayName("Số điện thoại")]
        public int SDT { get;set; }
        [DisplayName("Điểm trung bình")]
        public double DiemTB { get;set; }
        [DisplayName("Giới tính")]
        public bool Gioitinh { get; set; }
    }
}
