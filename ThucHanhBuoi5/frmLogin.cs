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
    public partial class frmLogin : Form
    {
        public string user { get; set; }
        string pass { get; set; }
        public bool IsLogined { get; set; }
        DataBaseProcess dt = new DataBaseProcess();

        public frmLogin()
        {
            InitializeComponent();
            IsLogined = false;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Bạn phải nhập tên đăng nhập");
                txtUserName.Focus();
                return;
            }
            if (txtPassWord.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu");
                txtPassWord.Focus();
                return;
            }

            user = txtUserName.Text.Trim();
            pass = txtPassWord.Text.Trim();
            DataTable dataTable = dt.DataReader("Select * from tblUser Where userName = N'"+user+"' and passWord = N'"+pass+"'");
            if(dataTable.Rows.Count > 0)
            {
                IsLogined=true;
                this.Close();
            }   
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
                txtUserName.Clear();
                txtPassWord.Clear();
            }   
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn muốn thoát không?","Thoát?",MessageBoxButtons.YesNo)==DialogResult.Yes)
                Application.Exit();
        }
    }
}
