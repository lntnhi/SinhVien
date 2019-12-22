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
        public static List<Model.SinhVien> getSV (string search = null)
        {
            var db = new SinhVienContext();
            if (search == null) search = "";
            return db.SinhVienDbset.
                Where(e=> e.HoTen.Contains(search) || e.IDSinhVien.Contains(search) || e.IDKhoa.Contains(search)).
                OrderBy(e => e.HoTen).
                ToList();
        }

        public static List<Mon> getMonByKhoa (string ID)
        {
            return new SinhVienContext().MonDbset.Where(e => e.IDKhoa == ID).ToList();
        }

        public static List<Khoa> getKhoa()
        {
            return new SinhVienContext().KhoaDbset.ToList(); ;
        }

        public static Diem getDiem(string IDMon, string IDSinhVien)
        {
            return new SinhVienContext().DiemDbset.Where(e => e.IDMon == IDMon && e.IDSinhVien == IDSinhVien).FirstOrDefault();
        }

        public static float diemTrungBinh (string IDSinhVien)
        {
            float dtb = 0;
            List<Diem> lstDiem = new SinhVienContext().DiemDbset.Where(e => e.IDSinhVien == IDSinhVien).ToList();
            foreach (var item in lstDiem)
            {
                dtb += item.DiemSo;
            }
            return dtb/lstDiem.Count;
        }

        public static void delDiemSV (string IDSinhVien)
        {
            var db = new SinhVienContext();
            List<Diem> lsDiem = db.DiemDbset.Where(e => e.IDSinhVien == IDSinhVien).ToList();
            foreach(var item in lsDiem)
            {
                if (item != null)
                    db.DiemDbset.Remove(item);
            }
            db.SaveChanges();
        }

        public static void addDiemSV(Diem diem)
        {
            var db = new SinhVienContext();
            db.DiemDbset.Add(diem);
            db.SaveChanges();
        }

        public static void addSV(Model.SinhVien sv)
        {
            var db = new SinhVienContext();
            db.SinhVienDbset.Add(sv);
            db.SaveChanges();
        }

        public static void editSV (Model.SinhVien sv)
        {
            var db = new SinhVienContext();
            var svien = db.SinhVienDbset.Find(sv.IDSinhVien);
            svien.HoTen = sv.HoTen;
            svien.GioiTinh = sv.GioiTinh;
            svien.NgaySinh = sv.NgaySinh;
            db.SaveChanges();
        }

        public static void delSV (string IDSinhVien)
        {
            var db = new SinhVienContext();
            var sv = db.SinhVienDbset.Where(e => e.IDSinhVien == IDSinhVien).FirstOrDefault();
            if (sv != null)
                db.SinhVienDbset.Remove(sv);
            db.SaveChanges();
        }
    }
}
