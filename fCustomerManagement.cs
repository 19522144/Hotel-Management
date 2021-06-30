using Hotel_Management.Controller;
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
    public partial class fCustomerManagement : Form
    {
        CustomerController CustomerController = new CustomerController();
        CustomerTypeController CustomerTypeController = new CustomerTypeController();

        public fCustomerManagement()
        {
            InitializeComponent();
            dgvData.DataSource =  CustomerController.getAll();
            addBinding();

            cbLoai.DataSource = CustomerTypeController.getAll();
            cbLoai.DisplayMember = "Name";
            //cbLoai.Select
        }

        void addBinding()
        {
            txtMaKH.DataBindings.Add("Text", dgvData.DataSource, "ID", true, DataSourceUpdateMode.Never);
            txtCMND.DataBindings.Add("Text", dgvData.DataSource, "CMND", true, DataSourceUpdateMode.Never);
            txtTenKH.DataBindings.Add("Text", dgvData.DataSource, "Name", true, DataSourceUpdateMode.Never);
            txtSDT.DataBindings.Add("Text", dgvData.DataSource, "Phone", true, DataSourceUpdateMode.Never);
            txtDiaChi.DataBindings.Add("Text", dgvData.DataSource, "Address", true, DataSourceUpdateMode.Never);
            cbLoai.DataBindings.Add("SelectedText", dgvData.DataSource, "Type", true, DataSourceUpdateMode.Never);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            KHACHHANG kh = new KHACHHANG();

            kh.MAKHACHHANG = int.Parse(txtMaKH.Text);
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
