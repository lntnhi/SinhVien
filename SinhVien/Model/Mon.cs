using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinhVien.Model
{
    public class Mon
    {
        [Key]
        public string IDMon { get; set; }
        public string TenMon { get; set; }
        public string IDKhoa { get; set; }
        [ForeignKey("IDKhoa")] //nhớ khóa ngoại lè
        public Khoa Khoa { get; set; }
        public ICollection<Diem> ListDiem { get; set; }
    }
}
