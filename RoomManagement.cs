using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel_Management.Controller;

namespace Hotel_Management
{
    public partial class RoomManagement : Form
    {

        RoomController roomController = new RoomController();
        public RoomManagement()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            dgvDanhSachPhong.DataSource = roomController.getAll();
            addBlinding();
        }
        void addBlinding()
        {
            txbMaPhong.DataBindings.Clear();
            txbMaPhong.DataBindings.Add("Text", dgvDanhSachPhong.DataSource, "ID", true, DataSourceUpdateMode.Never);
            txbTenPhong.DataBindings.Clear();
            txbTenPhong.DataBindings.Add("Text", dgvDanhSachPhong.DataSource, "Name", true, DataSourceUpdateMode.Never);
            cbLoaiPhong.DataBindings.Clear();
            cbLoaiPhong.DataBindings.Add("Text", dgvDanhSachPhong.DataSource, "RoomType", true, DataSourceUpdateMode.Never);
            cbTrangThai.DataBindings.Clear();
            cbTrangThai.DataBindings.Add("Text", dgvDanhSachPhong.DataSource, "Status", true, DataSourceUpdateMode.Never);
            txbGhiChu.DataBindings.Clear();
            txbGhiChu.DataBindings.Add("Text", dgvDanhSachPhong.DataSource, "Note", true, DataSourceUpdateMode.Never);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
