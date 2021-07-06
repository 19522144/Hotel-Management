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
            txbNewPass.DataBindings.Clear();
            //txbConfirmNewPass.DataBindings.Clear();
            cbBoxAccessRights.DataBindings.Clear();


            NGUOIDUNG nd = new NGUOIDUNG();
            txbUserCode.DataBindings.Add("Text", nd, "MANGUOIDUNG");
            txbUserName.DataBindings.Add("Text", nd, "TENDANGNHAP");
            txbYourName.DataBindings.Add("Text", nd, "TENNGUOIDUNG");
            txbNewPass.DataBindings.Add("Text", nd, "MATKHAU");
            cbBoxAccessRights.DataBindings.Add("Text", nd, "QUYENTRUYCAP");

           
        }
        private void PersionalInformation_Load(object sender, EventArgs e)
        {
            txbConfirmNewPass.Focus();
            txbNewPass.Focus();
            txbUserCode.Focus();
            txbUserName.Focus();
            txbYourName.Focus();
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
                TENDANGNHAP = txbUserName.Text,
                TENNGUOIDUNG=txbYourName.Text,
            };
            userController.UpdateUser(ng);
        }
        private void btnSaveSecurity_Click(object sender, EventArgs e)
        {
            NGUOIDUNG ng = new NGUOIDUNG()
            {
                MATKHAU = txbNewPass.Text,
                QUYENTRUYCAP = cbBoxAccessRights.Text,
            };
            userController.UpdateUser(ng);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
