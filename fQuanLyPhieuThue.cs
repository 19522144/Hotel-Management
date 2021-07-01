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
    public partial class fQuanLyPhieuThue : Form
    {
        RentalController rentalController = new RentalController();

        public fQuanLyPhieuThue()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            dgvDanhSachPhieuThue.DataSource = rentalController.getAll();
            addBinding();
        }

        void addBinding()
        {
            txtMaPhieuThue.DataBindings.Clear();
            txtTenKhachHang.DataBindings.Clear();
            txtCMND.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();
            txtTenPhong.DataBindings.Clear();


            txtMaPhieuThue.DataBindings.Add("Text", dgvDanhSachPhieuThue.DataSource, "ID", true, DataSourceUpdateMode.Never);
            txtTenKhachHang.DataBindings.Add("Text", dgvDanhSachPhieuThue.DataSource, "CustomerName", true, DataSourceUpdateMode.Never);
            txtCMND.DataBindings.Add("Text", dgvDanhSachPhieuThue.DataSource, "CMND", true, DataSourceUpdateMode.Never);
            txtDiaChi.DataBindings.Add("Text", dgvDanhSachPhieuThue.DataSource, "Address", true, DataSourceUpdateMode.Never);
            txtTenPhong.DataBindings.Add("Text", dgvDanhSachPhieuThue.DataSource, "RoomName", true, DataSourceUpdateMode.Never);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            rentalController.deleteRental(Int32.Parse(txtMaPhieuThue.Text));
            LoadData();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            PHIEUTHUE pt = new PHIEUTHUE()
            {
                MAPHONG = 1,
                MAPHIEUTHUE = Int32.Parse(txtMaPhieuThue.Text),
                NGAYBDTHUE = dtpkNgayBatDauThue.Value
            };

            CHITIETPHIEUTHUE ct = new CHITIETPHIEUTHUE()
            { 
                MAKHACHHANG = 2
            };

            rentalController.updateRental(pt, ct);

            LoadData();
            //InHoaDon inHoaDon = new InHoaDon();
        }
    }
}
