using SinhVien.Controller;
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
            updateData();
        }
        private void updateData()
        {
            List<Model.SinhVien> listSV = SinhVienService.GetSV();
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
            Model.SinhVien curItem = (Model.SinhVien)lstSinhVien.SelectedItem;

        }
    }
}
