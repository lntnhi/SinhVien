using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinhVien.Model
{
    public class SinhVienContext : DbContext
    {
        public SinhVienContext() : base ("Data Source =.; Initial Catalog = SinhVien; Persist Security Info=True;User ID = sa; Password=123")
        {
        }
        public DbSet<Khoa> KhoaDbset { get; set; }
        public DbSet<SinhVien> SinhVienDbset { get; set; }
        public DbSet<Mon> MonDbset { get; set; }
        public DbSet<Diem> DiemDbset { get; set; }
    }
}
