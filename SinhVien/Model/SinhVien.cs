using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinhVien.Model
{
    public class SinhVien
    {
        [Key]
        public string IDSinhVien { get; set; }
        public string HoTen { get; set; }
        public GENDER GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string IDKhoa { get; set; }
        [ForeignKey("IDKhoa")] //nhớ khóa ngoại lè
        public Khoa Khoa { get; set; } //1 SV chỉ thuộc về 1 khoa
        public ICollection<Diem> ListDiem { get; set; }

        public string DisplayTen
        {
            get
            {
                return GioiTinh == 0 ? "Anh " + HoTen : "Chị " + HoTen;
            }
        }
    }
    public enum GENDER
    {
        Male, Female, Other
    }
    
}
