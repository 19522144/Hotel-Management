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
namespace Hotel_Management
{
    public partial class ManageCustomerType : Form
    {
        SqlConnection connection;
        SqlCommand command = new SqlCommand();
        string str = @"Data Source=LAPTOP-E5L2D2PG\SQLEXPRESS;Initial Catalog=QUANLIKHACHSAN;Integrated Security=True";
        SqlDataAdapter DAdapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from LOAIKHACH";
            DAdapter.SelectCommand = command;
            table.Clear();
            DAdapter.Fill(table);
            dgv.DataSource = table;

        }
        public ManageCustomerType()
        {
            InitializeComponent();
        }

        private void ManageCustomerType_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into LOAIKHACH values(N'" + txtTenLoaiKhach.Text + "')";
            command.ExecuteNonQuery();
            loadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from LOAIKHACH where MALOAIKHACH = '" + txtMaLoaiKhach.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update LOAIKHACH set TENLOAIKHACH = N'" + txtTenLoaiKhach.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult f = MessageBox.Show(" Bạn có thực sự muốn thoát không. ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (f == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                int i;
                i = dgv.CurrentRow.Index;
                txtMaLoaiKhach.Text = dgv.Rows[i].Cells[0].Value.ToString();
                txtTenLoaiKhach.Text = dgv.Rows[i].Cells[1].Value.ToString();
        }
    }
}
