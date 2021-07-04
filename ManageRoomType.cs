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
    public partial class ManageRoomType : Form
    {
        RoomTypeController roomTypeController = new RoomTypeController();
        public ManageRoomType()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            dvgData.DataSource = roomTypeController.getAll();
            addBlinding();
        }
        void addBlinding()
        {
            txtID.DataBindings.Clear();
            txtID.DataBindings.Add("Text", dvgData.DataSource, "ID", true, DataSourceUpdateMode.Never);
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add("Text", dvgData.DataSource, "Name", true, DataSourceUpdateMode.Never);
            txtPrice.DataBindings.Clear();
            txtPrice.DataBindings.Add("Text", dvgData.DataSource, "Price", true, DataSourceUpdateMode.Never);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LOAIPHONG lp = new LOAIPHONG()
            {
                TENLOAIPHONG = txtName.Text,
                DONGIA = Decimal.Parse(txtPrice.Text)
            };
            roomTypeController.AddRoomType(lp);
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                roomTypeController.DeleteRoomType(Int32.Parse(txtID.Text));
                LoadData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            LOAIPHONG lp = new LOAIPHONG()
            {
                MALOAIPHONG = Int32.Parse(txtID.Text),
                TENLOAIPHONG = txtName.Text,
                DONGIA = Decimal.Parse(txtPrice.Text)
            };
            roomTypeController.UpdateRoomType(lp);
            LoadData();
        }
    }
}
