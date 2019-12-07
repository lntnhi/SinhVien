using SinhVien.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinhVien.Controller
{
    public class SinhVienService
    {
        public static List<Model.SinhVien> GetSV ()
        {
            var db = new SinhVienContext();
            return db.SinhVienDbset.
                OrderBy(e => e.HoTen).
                ToList();
        }
        
    }
}
