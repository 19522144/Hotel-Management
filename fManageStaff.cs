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
    public partial class fManageStaff : Form
    {
        DangKi dangKi;
        UserController userControlller = new UserController();
        int ID;

        public fManageStaff()
        {
            InitializeComponent();
            LoadData();
            cmbAccessRights.Items.Add("Quản lý");
            cmbAccessRights.Items.Add("Nhân viên");
            cmbAccessRights.SelectedIndex = 0;
        }

        void LoadData()
        {
            dgvData.DataSource = userControlller.getAll();
            int index = (int)dgvData.Rows[0].Cells["Avatar"].Value;
            ID = (int) dgvData.Rows[0].Cells["ID"].Value;
            setAvatar(index);
            addBinding();
        }

        private void addBinding()
        {
            cmbAccessRights.DataBindings.Clear();
            lbName.DataBindings.Clear();

            cmbAccessRights.DataBindings.Add("Text", dgvData.DataSource, "Rights", false, DataSourceUpdateMode.Never); ;
            lbName.DataBindings.Add("Text", dgvData.DataSource, "Name", false, DataSourceUpdateMode.Never); ;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dangKi == null || dangKi.IsDisposed)
            {
                dangKi = new DangKi();
            }

            dangKi.Show();
        }

        void setAvatar(int index)
        {
            if (index > 5)
                return;

            Bitmap bitmap = new Bitmap(Properties.Resources.avatar);
            int HEIGHT = bitmap.Height / 3;
            int WIDTH = bitmap.Width / 3;

            int row = index / 3;
            int column = index % 3;
            Bitmap avatar = new Bitmap(WIDTH, HEIGHT);

            for (int i = row * HEIGHT; i < (row + 1) * HEIGHT; i++)
            {
                for (int j = column * WIDTH; j < (column + 1) * WIDTH; j++)
                {
                    avatar.SetPixel(j - column * WIDTH, i - row * HEIGHT, bitmap.GetPixel(j, i));
                }
            }

            picAvatar.Image = avatar;
        }


        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            int index = (int)dgvData.Rows[e.RowIndex].Cells["Avatar"].Value;
            setAvatar(index);
            ID = (int)dgvData.Rows[e.RowIndex].Cells["ID"].Value;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            NGUOIDUNG nguoiDung = new NGUOIDUNG()
            {
                MANGUOIDUNG = ID,
                QUYENTRUYCAP = cmbAccessRights.Text
            };

            userControlller.updateRights(nguoiDung);
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
