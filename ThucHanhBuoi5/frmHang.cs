using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThucHanhBuoi5
{
    public partial class frmHang : Form
    {
        DataBaseProcess dt = new DataBaseProcess();
        public frmHang(string user)
        {
            InitializeComponent();
            lblUser.Text = "Xin chào: " + user;
        }

        private void frmHang_Load(object sender, EventArgs e)
        {
            // Ẩn nút sửa, xóa
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            // Ẩn grbChiTiet
            //grbChiTiet.Enabled = false;

            // Load dữ liệu từ database lên dgv
            dgvKetQua.DataSource = dt.DataReader("Select * from tblHang");
            // Load chất liệu lên cboChatLieu
            List<string> list = new List<string>() { "Vàng", "Bông", "Mây", "Tre", "Tổng hợp"};
            foreach (string s in list)
                cboChatLieu.Items.Add(s);
        }

        private void NhapSo(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                ptbAnh.Image = ofd.FileName;
            }    
        }
    }
}
