namespace SinhVien.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SinhVien.Model.SinhVienContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SinhVien.Model.SinhVienContext context)
        {
            context.KhoaDbset.AddOrUpdate(
                new Model.Khoa
                {
                    IDKhoa = "Van",
                    TenKhoa = "Văn"
                },
                new Model.Khoa
                {
                    IDKhoa = "VL",
                    TenKhoa = "Vật lý"
                },
                new Model.Khoa
                {
                    IDKhoa = "CNTT",
                    TenKhoa = "CNTT"
                });
            context.SaveChanges();
            context.MonDbset.AddOrUpdate(
                new Model.Mon
                {
                    IDMon = "VHCD",
                    TenMon = "Văn học CĐ",
                    IDKhoa = "Van"
                },
                new Model.Mon
                {
                    IDMon = "VHHD",
                    TenMon = "Văn học HĐ",
                    IDKhoa = "Van"
                },
                new Model.Mon
                {
                    IDMon = "VLCH",
                    TenMon = "Vật lý cơ học",
                    IDKhoa = "VL"
                },
                new Model.Mon
                {
                    IDMon = "VLQH",
                    TenMon = "Vật lý quang học",
                    IDKhoa = "VL"
                },
                new Model.Mon
                {
                    IDMon = "VLDH",
                    TenMon = "Vật lý điện học",
                    IDKhoa = "VL"
                },
                new Model.Mon
                {
                    IDMon = "KTMT",
                    TenMon = "Kiến trúc máy tính",
                    IDKhoa = "CNTT"
                },
                new Model.Mon
                {
                    IDMon = "NET",
                    TenMon = "Xây dựng .NET Framework",
                    IDKhoa = "CNTT"
                },
                new Model.Mon
                {
                    IDMon = "SQL",
                    TenMon = "Các hệ quản trị CSDL",
                    IDKhoa = "CNTT"
                });
            context.SaveChanges();
            context.SinhVienDbset.AddOrUpdate(
                new Model.SinhVien
                {
                    IDSinhVien = "16T1",
                    HoTen = "Nguyễn Thị Mon",
                    GioiTinh = Model.GENDER.Female,
                    NgaySinh = new DateTime(2018, 2, 2),
                    IDKhoa = "Van"
                },
                new Model.SinhVien
                {
                    IDSinhVien = "16T2",
                    HoTen = "Nguyễn Văn Miu",
                    GioiTinh = Model.GENDER.Male,
                    NgaySinh = new DateTime(2018, 4, 2),
                    IDKhoa = "Van"
                },
                new Model.SinhVien
                {
                    IDSinhVien = "16T3",
                    HoTen = "Nguyễn Thị Mập",
                    GioiTinh = Model.GENDER.Female,
                    NgaySinh = new DateTime(2018, 2, 6),
                    IDKhoa = "VL"
                },
                new Model.SinhVien
                {
                    IDSinhVien = "16T4",
                    HoTen = "Nguyễn Thị Mèo",
                    GioiTinh = Model.GENDER.Female,
                    NgaySinh = new DateTime(2018, 11, 2),
                    IDKhoa = "VL"
                },
                new Model.SinhVien
                {
                    IDSinhVien = "16T5",
                    HoTen = "Nguyễn Văn Ỉn",
                    GioiTinh = Model.GENDER.Male,
                    NgaySinh = new DateTime(2018, 2, 12),
                    IDKhoa = "CNTT"
                },
                new Model.SinhVien
                {
                    IDSinhVien = "16T6",
                    HoTen = "Nguyễn Văn Heo",
                    GioiTinh = Model.GENDER.Male,
                    NgaySinh = new DateTime(2018, 12, 12),
                    IDKhoa = "CNTT"
                },
                new Model.SinhVien
                {
                    IDSinhVien = "16T7",
                    HoTen = "Mạc Thị Bưởi",
                    GioiTinh = Model.GENDER.Female,
                    NgaySinh = new DateTime(2018, 2, 15),
                    IDKhoa = "CNTT"
                });
            context.SaveChanges();
            context.DiemDbset.AddOrUpdate(
                new Model.Diem
                {
                    IDSinhVien = "16T1",
                    IDMon = "VHCD",
                    DiemSo = 6
                },
                new Model.Diem
                {
                    IDSinhVien = "16T1",
                    IDMon = "VHHD",
                    DiemSo = 7
                },
                new Model.Diem
                {
                    IDSinhVien = "16T2",
                    IDMon = "VHCD",
                    DiemSo = 7
                },
                new Model.Diem
                {
                    IDSinhVien = "16T2",
                    IDMon = "VHHD",
                    DiemSo = 7
                },
                new Model.Diem
                {
                    IDSinhVien = "16T3",
                    IDMon = "VLCH",
                    DiemSo = 6
                },
                new Model.Diem
                {
                    IDSinhVien = "16T3",
                    IDMon = "VLQH",
                    DiemSo = 7
                },
                new Model.Diem
                {
                    IDSinhVien = "16T3",
                    IDMon = "VLDH",
                    DiemSo = 7
                },
                new Model.Diem
                {
                    IDSinhVien = "16T4",
                    IDMon = "VLCH",
                    DiemSo = 6
                },
                new Model.Diem
                {
                    IDSinhVien = "16T4",
                    IDMon = "VLQH",
                    DiemSo = 7
                },
                new Model.Diem
                {
                    IDSinhVien = "16T4",
                    IDMon = "VLDH",
                    DiemSo = 7
                },
                new Model.Diem
                {
                    IDSinhVien = "16T5",
                    IDMon = "KTMT",
                    DiemSo = 6
                },
                new Model.Diem
                {
                    IDSinhVien = "16T5",
                    IDMon = "SQL",
                    DiemSo = 7
                },
                new Model.Diem
                {
                    IDSinhVien = "16T5",
                    IDMon = "NET",
                    DiemSo = 7
                },
                 new Model.Diem
                 {
                     IDSinhVien = "16T6",
                     IDMon = "KTMT",
                     DiemSo = 6
                 },
                new Model.Diem
                {
                    IDSinhVien = "16T6",
                    IDMon = "SQL",
                    DiemSo = 7
                },
                new Model.Diem
                {
                    IDSinhVien = "16T6",
                    IDMon = "NET",
                    DiemSo = 7
                },
                 new Model.Diem
                 {
                     IDSinhVien = "16T7",
                     IDMon = "KTMT",
                     DiemSo = 6
                 },
                new Model.Diem
                {
                    IDSinhVien = "16T7",
                    IDMon = "SQL",
                    DiemSo = 7
                },
                new Model.Diem
                {
                    IDSinhVien = "16T7",
                    IDMon = "NET",
                    DiemSo = 7
                });
            context.SaveChanges();
        }
    }
}
