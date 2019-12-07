using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinhVien.Model
{
    public class Diem
    {
        [Key, Column(Order =0)]
        public string IDSinhVien { get; set; }
        [Key, Column(Order = 1)]
        public string IDMon { get; set; }
        public float DiemSo { get; set; }
        public SinhVien SinhVien { get; set; }
        public Mon Mon { get; set; }
    }
}
