using Hotel_Management.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management
{
    public partial class SignIn : Form
    {
        UserController userController = new UserController();
        fMainMenu menu;

        public SignIn()
        {
            InitializeComponent();
        }       

        private void FormScreenLogin_Load(object sender, EventArgs e)
        {
            txbPassword.Focus();
            txbUsername.Focus();
        }

        private bool CheckEmpty()
        {           
            if (txbUsername.Text.Length == 0 && txbPassword.Text.Length == 0)
                MessageBox.Show("Vui lòng điền đầy đủ tên đăng nhập và mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                if (txbPassword.Text.Length == 0)
                MessageBox.Show("Vui lòng điền tên đăng nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                if (txbUsername.Text.Length == 0)
                MessageBox.Show("Vui lòng điền mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return false;
            //else
            //    if (txbUsername.Text == "lethuydung" && txbPassword.Text == "123456789")
            //    MessageBox.Show("Bạn đã đăng nhập thành công.");
            //else MessageBox.Show("Bạn đã nhập sai tài khoản hoặc mật khẩu.");

        }

        public string GetMD5(string chuoi)
        {
            string str_md5 = "";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(chuoi);

            MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
            mang = my_md5.ComputeHash(mang);

            foreach (byte b in mang)
            {
                str_md5 += b.ToString("X2");
            }

            return str_md5;
        }
       
        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (userController.login(txbUsername.Text, GetMD5(txbPassword.Text)) == true)
            {

                MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);

                if (menu == null || menu.IsDisposed)
                {                    
                    menu = new fMainMenu();
                }

                menu.Show();
            }

            else
                MessageBox.Show("Đăng nhập thất bại. Vui lòng thử lại sau!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ckbShow_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbShow.Checked == false)
                txbPassword.UseSystemPasswordChar = true;
            else
                txbPassword.UseSystemPasswordChar = false;
        }
    }

}
