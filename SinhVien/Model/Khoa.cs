using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinhVien.Model
{
    public class Khoa
    {
        [Key]
        public string IDKhoa { get; set; }
        public string TenKhoa { get; set; }
        public ICollection<SinhVien> ListSV { get; set; } //1 khoa có 1 hoặc nhiều SV
        public ICollection<Mon> ListMon { get; set; }
    }
}
