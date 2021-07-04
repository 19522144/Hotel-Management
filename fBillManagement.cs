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
    public partial class fBillManagement : Form
    {
        BillController billController = new BillController();
        public fBillManagement()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            dgvBillManagement.DataSource = billController.getAll();
            addBinding();
        }

        void addBinding()
        {
            txtMaHoaDon.DataBindings.Clear();
            txtTriGia.DataBindings.Clear();
            dtpkNgayThanhToan.DataBindings.Clear();
            nudSoNgayThue.DataBindings.Clear();
            txtTenKhachHang.DataBindings.Clear();
            txtTenPhong.DataBindings.Clear();

            txtMaHoaDon.DataBindings.Add("Text", dgvBillManagement, "ID", true, DataSourceUpdateMode.Never);
            txtTriGia.DataBindings.Add("Text", dgvBillManagement, "Value", true, DataSourceUpdateMode.Never);
            dtpkNgayThanhToan.DataBindings.Add("Text", dgvBillManagement, "PaymentDay", true, DataSourceUpdateMode.Never);
            nudSoNgayThue.DataBindings.Add("Text", dgvBillManagement, "RentalDays", true, DataSourceUpdateMode.Never);
            txtTimTenKhachHang.DataBindings.Add("Text", dgvBillManagement, "CustomerName", true, DataSourceUpdateMode.Never);
            txtTimTenPhong.DataBindings.Add("Text", dgvBillManagement, "RoomName", true, DataSourceUpdateMode.Never);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            InHoaDon inHoaDon = new InHoaDon();
            inHoaDon.ShowDialog();
        }
    }
}
