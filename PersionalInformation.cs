using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Hotel_Management.Controller;
using System.Security.Cryptography;

namespace Hotel_Management
{
    public partial class PersionalInformation : Form
    {
        UserController userController = new UserController();
        
        public PersionalInformation(int ID)
        {
            InitializeComponent();
            AddBinding();
        }
        void AddBinding()
        {

            txbUserCode.DataBindings.Clear();
            txbUserName.DataBindings.Clear();
            txbYourName.DataBindings.Clear();
            
            txbUserCode.DataBindings.Add("Text", userController.All(), "MANGUOIDUNG");
            txbUserName.DataBindings.Add("Text", userController.All(), "TENDANGNHAP");
            txbYourName.DataBindings.Add("Text", userController.All(), "TENNGUOIDUNG");
        }
        private void PersionalInformation_Load(object sender, EventArgs e)
        {
            txbConfirmNewPass.Focus();
            txbNewPass.Focus();
            txbUserCode.Focus();
            txbUserName.Focus();
            txbYourName.Focus();
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

        private void btnShowNewPass_Click(object sender, EventArgs e)
        {
            if (txbNewPass.PasswordChar == '*')
            {
                btnHideNewPass.BringToFront();
                txbNewPass.PasswordChar = '\0';
            }
        }

        private void btnHideNewPass_Click(object sender, EventArgs e)
        {
            if (txbNewPass.PasswordChar == '\0')
            {
                btnShowNewPass.BringToFront();
                txbNewPass.PasswordChar = '*';
            }
        }

        private void btnHideConfirmNewPass_Click(object sender, EventArgs e)
        {
            if (txbConfirmNewPass.PasswordChar == '\0')
            {
                btnHideConfirmNewPass.BringToFront();
                txbConfirmNewPass.PasswordChar = '*';
            }
        }

        private void btnShowConfirmNewPass_Click(object sender, EventArgs e)
        {
            if (txbConfirmNewPass.PasswordChar == '*')
            {
                btnHideConfirmNewPass.BringToFront();
                txbConfirmNewPass.PasswordChar = '\0';
            }
        }

        private void btnSaveAI_Click(object sender, EventArgs e)
        {
            NGUOIDUNG ng = new NGUOIDUNG()
            {
                MANGUOIDUNG = Int32.Parse(txbUserCode.Text),
                TENDANGNHAP = txbUserName.Text,
                TENNGUOIDUNG = txbYourName.Text,
            };
            userController.UpdateUser(ng);
            MessageBox.Show("Lưu thay đổi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnSaveSecurity_Click(object sender, EventArgs e)
        {
            if (txbNewPass.Text != txbConfirmNewPass.Text)
            {
                MessageBox.Show("Xác nhận mật khẩu mới không đúng, vui lòng xác nhận lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbConfirmNewPass.Focus();
            }
            else if (GetMD5(txbCurrentPass.Text) != "21232F297A57A5A743894A0E4A801FC3")
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbCurrentPass.Focus();
            }else
            {
                NGUOIDUNG nd = new NGUOIDUNG()
                {
                    MATKHAU = GetMD5(txbNewPass.Text)
                };
                userController.UpdatePassword(nd);
                MessageBox.Show("Lưu thay đổi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
                

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
