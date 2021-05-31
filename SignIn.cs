using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void txbUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormScreenLogin_Load(object sender, EventArgs e)
        {
            txbPassword.Focus();
            txbUsername.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Login()
        {
            if (txbUsername.Text.Length == 0 && txbPassword.Text.Length == 0)
                MessageBox.Show("Bạn chưa nhập tài khoản và mật khẩu.");
            else
                if (txbPassword.Text.Length == 0)
                MessageBox.Show("Bạn chưa nhập tài khoản.");
            else
                if (txbUsername.Text.Length == 0)
                MessageBox.Show("Bạn chưa nhập mật khẩu.");
            else
                if (txbUsername.Text == "lethuydung" && txbPassword.Text == "123456789")
                MessageBox.Show("Bạn đã đăng nhập thành công.");
            else MessageBox.Show("Bạn đã nhập sai tài khoản hoặc mật khẩu.");
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txbUsername.Text == "lethuydung" && txbPassword.Text == "123456789")
            {

            }
            Login();
        }

        private void labelUsername_Click(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txbPassword.PasswordChar == '*')
            {
                btnHide.BringToFront();
                txbPassword.PasswordChar = '\0';
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (txbPassword.PasswordChar == '\0')
            {
                btnShow.BringToFront();
                txbPassword.PasswordChar = '*';
            }
        }


    }

}
