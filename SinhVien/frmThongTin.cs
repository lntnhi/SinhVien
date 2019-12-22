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
using System.Windows.Forms;

namespace SinhVien
{
    public partial class frmThongTin : Form
    {        
        public frmThongTin()
        {
            InitializeComponent();
            List<Khoa> listKhoa = SinhVienService.getKhoa();
            foreach (var item in listKhoa)
            {
                // Add tab khoa
                TabPage tabPage = new TabPage(item.TenKhoa);
                tabPage.Name = item.IDKhoa;
                tabKhoa.TabPages.Add(tabPage);

                //Add môn học
                FlowLayoutPanel pnlMon = new FlowLayoutPanel();
                pnlMon.Name = item.IDKhoa;
                pnlMon.AutoScroll = true;
                pnlMon.Size = new Size(250, 100);
                List<Mon> listMon = SinhVienService.getMonByKhoa(item.IDKhoa);
                foreach (var mon in listMon)
                {
                    Label lable = new Label();
                    lable.Text = mon.TenMon;
                    pnlMon.Controls.Add(lable);
                    TextBox textBox = new TextBox();
                    textBox.Name = mon.IDMon;
                    pnlMon.Controls.Add(textBox);
                }
                tabPage.Controls.Add(pnlMon);
            }
            updateData();
        }
        private void updateData(string search = null)
        {
            lstSinhVien.Items.Clear();
            List<Model.SinhVien> listSV = SinhVienService.getSV(search);
            if (listSV == null)
            {
                throw new Exception("Không tồn tại mảng");
            }
            else
            {
                lstSinhVien.DisplayMember="DisplayTen";
                foreach (var item in listSV)
                {
                    lstSinhVien.Items.Add(item);
                }
            }
        }

        private void lstSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.SinhVien sv = (Model.SinhVien)lstSinhVien.SelectedItem;
            txtTen.Text = sv.HoTen;
            dtpNgaySinh.Value = sv.NgaySinh;
            chkGioiTinh.Checked = sv.GioiTinh == GENDER.Male;
            tabKhoa.SelectTab(sv.IDKhoa);
            List<Mon> listMon = SinhVienService.getMonByKhoa(sv.IDKhoa);
            lblDiem.Text = SinhVienService.diemTrungBinh(sv.IDSinhVien).ToString();
            foreach (Control c in tabKhoa.TabPages) //load tab page
            {
                c.Enabled = false;
                if (c.Name.Equals(sv.IDKhoa))
                {
                    c.Enabled = true;
                    var pnlMon = c.Controls[0]; //flow panel, vì trong page có mỗi một control là panel hoi
                    foreach (Control control in pnlMon.Controls) //load textbox
                    {
                        foreach (var mon in listMon)
                        {
                            if (control.Name.Equals(mon.IDMon))
                            {
                                String diemSo = "";
                                Diem diem = SinhVienService.getDiem(mon.IDMon, sv.IDSinhVien);
                                if (diem != null) diemSo = diem.DiemSo.ToString();
                                control.Text = diemSo;
                            }
                        }                            
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            updateData(txtSearch.Text);
        }

        private void btnBoSung_Click(object sender, EventArgs e)
        {
            var f = new frmThemSV();
            if (f.ShowDialog() == DialogResult.OK)
            {
                updateData();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            Model.SinhVien sv = (Model.SinhVien)lstSinhVien.SelectedItem;
            sv.HoTen = txtTen.Text;
            sv.NgaySinh = dtpNgaySinh.Value;
            if (chkGioiTinh.Checked == true) sv.GioiTinh = GENDER.Male;
            else sv.GioiTinh = GENDER.Female;
            List<Mon> listMon = SinhVienService.getMonByKhoa(sv.IDKhoa);
            SinhVienService.delDiemSV(sv.IDSinhVien);
            foreach (Control c in tabKhoa.TabPages) //load tab page
            {
                if (c.Name.Equals(sv.IDKhoa))
                {
                    var pnlMon = c.Controls[0]; //flow panel, vì trong page có mỗi một control là panel hoi
                    foreach (Control control in pnlMon.Controls) //load textbox
                    {
                        foreach (var mon in listMon)
                        {
                            if (control.Name.Equals(mon.IDMon))
                            {
                                string diemSo = "";
                                if (control.Text != "")
                                {
                                    diemSo = control.Text;
                                    Diem diem = new Diem();
                                    diem.IDSinhVien = sv.IDSinhVien;
                                    diem.IDMon = mon.IDMon;
                                    diem.DiemSo = float.Parse(diemSo);
                                    SinhVienService.addDiemSV(diem);
                                }
                            }
                        }
                    }
                }
            }
            SinhVienService.editSV(sv);
            updateData();
            MessageBox.Show("Đã cập nhật thành công");
            DialogResult = DialogResult.OK; // đóng form
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Chắc chắn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                foreach (Model.SinhVien item in lstSinhVien.CheckedItems)
                {
                    SinhVienService.delSV(item.IDSinhVien);
                }
                updateData();
                MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
