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
            cbLoaiPhong.DataSource = roomController.All();
            cbLoaiPhong.DisplayMember = "TENLOAIPHONG";
            cbLoaiPhong.ValueMember = "MALOAIPHONG";

            cbTimLoaiPhong.DataSource = roomController.All();
            cbTimLoaiPhong.DisplayMember = "TENLOAIPHONG";
            cbTimLoaiPhong.ValueMember = "MALOAIPHONG";
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

        private void btnXoaPhong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                roomController.DeleteRoom(Int32.Parse(txbMaPhong.Text));
                LoadData();
            }

        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            PHONG p = new PHONG()
            {
                TENPHONG = txbTenPhong.Text,
                MAPHONG = Int32.Parse(txbMaPhong.Text),
                MALOAIPHONG=(int)cbLoaiPhong.SelectedValue,
                TINHTRANG = cbTrangThai.Text,
                GHICHU = txbGhiChu.Text,
            };
            roomController.AddRoom(p);
            LoadData();
        }

      
        
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txbTimTenPhong.Text;
            dgvDanhSachPhong.DataSource = roomController.Search(keyword);
            //LoadData();


        }

        private void btnCapNhatPhong_Click(object sender, EventArgs e)
        {
            PHONG p = new PHONG()
            {
                MAPHONG=Int32.Parse(txbMaPhong.Text),
                TENPHONG = txbTenPhong.Text,
                MALOAIPHONG = (int)cbLoaiPhong.SelectedValue,
                TINHTRANG = cbTrangThai.Text,
                GHICHU = txbGhiChu.Text,
            };
           
            roomController.UpdateRoom(p);
            LoadData();
        }
    }
}
