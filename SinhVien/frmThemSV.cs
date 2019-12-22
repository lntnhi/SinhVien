using SinhVien.Controller;
using SinhVien.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace SinhVien
{
    public partial class frmThemSV : Form
    {
        public frmThemSV()
        {
            InitializeComponent();
            List<Khoa> lsKhoa = SinhVienService.getKhoa();
            foreach (var khoa in lsKhoa)
            {                
                cbbKhoa.Items.Add(khoa);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Model.SinhVien sv = new Model.SinhVien();
            sv.IDSinhVien = txtID.Text;
            sv.HoTen = txtTen.Text;
            if (chkGioiTinh.Checked == true) sv.GioiTinh = GENDER.Male;
            else sv.GioiTinh = GENDER.Female;
            sv.NgaySinh = dtpNgaySinh.Value;
            Khoa khoa = (Khoa) cbbKhoa.SelectedItem;
            sv.IDKhoa = khoa.IDKhoa;
            SinhVienService.addSV(sv);
            MessageBox.Show("Đã cập nhật thành công");
            DialogResult = DialogResult.OK; // đóng form
        }
    }
}
