namespace SinhVien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diems",
                c => new
                    {
                        IDSinhVien = c.String(nullable: false, maxLength: 128),
                        IDMon = c.String(nullable: false, maxLength: 128),
                        DiemSo = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.IDSinhVien, t.IDMon })
                .ForeignKey("dbo.SinhViens", t => t.IDSinhVien, cascadeDelete: true)
                .ForeignKey("dbo.Mons", t => t.IDMon, cascadeDelete: true)
                .Index(t => t.IDSinhVien)
                .Index(t => t.IDMon);
            
            CreateTable(
                "dbo.Mons",
                c => new
                    {
                        IDMon = c.String(nullable: false, maxLength: 128),
                        TenMon = c.String(),
                        IDKhoa = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IDMon)
                .ForeignKey("dbo.Khoas", t => t.IDKhoa)
                .Index(t => t.IDKhoa);
            
            CreateTable(
                "dbo.Khoas",
                c => new
                    {
                        IDKhoa = c.String(nullable: false, maxLength: 128),
                        TenKhoa = c.String(),
                    })
                .PrimaryKey(t => t.IDKhoa);
            
            CreateTable(
                "dbo.SinhViens",
                c => new
                    {
                        IDSinhVien = c.String(nullable: false, maxLength: 128),
                        HoTen = c.String(),
                        GioiTinh = c.Int(nullable: false),
                        NgaySinh = c.DateTime(nullable: false),
                        IDKhoa = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IDSinhVien)
                .ForeignKey("dbo.Khoas", t => t.IDKhoa)
                .Index(t => t.IDKhoa);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Diems", "IDMon", "dbo.Mons");
            DropForeignKey("dbo.Diems", "IDSinhVien", "dbo.SinhViens");
            DropForeignKey("dbo.SinhViens", "IDKhoa", "dbo.Khoas");
            DropForeignKey("dbo.Mons", "IDKhoa", "dbo.Khoas");
            DropIndex("dbo.SinhViens", new[] { "IDKhoa" });
            DropIndex("dbo.Mons", new[] { "IDKhoa" });
            DropIndex("dbo.Diems", new[] { "IDMon" });
            DropIndex("dbo.Diems", new[] { "IDSinhVien" });
            DropTable("dbo.SinhViens");
            DropTable("dbo.Khoas");
            DropTable("dbo.Mons");
            DropTable("dbo.Diems");
        }
    }
}
