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
using System.Data.SqlClient;
//using Hotel_Management.Controller;

namespace Hotel_Management
{ 
    public partial class fCustomerManagement : Form
    {

        SqlConnection connection;
        SqlCommand command = new SqlCommand();
        string str = @"Data Source=LAPTOP-E5L2D2PG\SQLEXPRESS;Initial Catalog=QUANLIKHACHSAN;Integrated Security=True";
        SqlDataAdapter DAdapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from KHACHHANG";
            DAdapter.SelectCommand = command;
            table.Clear();
            DAdapter.Fill(table);
            dgvData.DataSource = table;

        }
        //CustomerController CustomerController = new CustomerController();
        //CustomerTypeController CustomerTypeController = new CustomerTypeController();

        public fCustomerManagement()
        {
            InitializeComponent();
            //dgvData.DataSource =  CustomerController.getAll();

            //addBinding();
            //cbLoai.DataSource = CustomerTypeController.getAll();
            //cbLoai.DisplayMember = "Name";
            //cbLoai.Select
        }

        private void fCustomerManagement_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into KHACHHANG values(N'" + txtTenKH.Text+ "','" + txtSDT.Text+ "', N'" + txtNationality+ "','" + txtCMND.Text+ "', N'" + txtDiaChi.Text+"')";
            command.ExecuteNonQuery();
            loadData();
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update KHACHHANG set TENKHACHHANG = '" + txtTenKH.Text + "', SODIENTHOAI = '" + txtSDT.Text + "', QUOCTICH = '" + txtNationality.Text + "', CMND = '" + txtCMND.Text + "', DIACHI = '" + txtDiaChi.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from KHACHHANG where MAKHACHHANG = '" + txtMaKH.Text + "'";
            command.ExecuteNonQuery();
            loadData();

        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvData.CurrentRow.Index;
            txtMaKH.Text        = dgvData.Rows[i].Cells[0].Value.ToString();
            txtTenKH.Text       = dgvData.Rows[i].Cells[1].Value.ToString();
            txtSDT.Text         = dgvData.Rows[i].Cells[2].Value.ToString();
            txtNationality.Text = dgvData.Rows[i].Cells[3].Value.ToString();
            txtCMND.Text        = dgvData.Rows[i].Cells[4].Value.ToString();
            txtDiaChi.Text      = dgvData.Rows[i].Cells[5].Value.ToString();
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



        //void addBinding()
        //{
        //    txtMaKH.DataBindings.Add("Text", dgvData.DataSource, "ID", true, DataSourceUpdateMode.Never);
        //    txtCMND.DataBindings.Add("Text", dgvData.DataSource, "CMND", true, DataSourceUpdateMode.Never);
        //    txtTenKH.DataBindings.Add("Text", dgvData.DataSource, "Name", true, DataSourceUpdateMode.Never);
        //    //txtSDT.DataBindings.Add("Text", dgvData.DataSource, "Phone", true, DataSourceUpdateMode.Never);
        //    //txtDiaChi.DataBindings.Add("Text", dgvData.DataSource, "Address", true, DataSourceUpdateMode.Never);
        //    //cbLoai.DataBindings.Add("SelectedText", dgvData.DataSource, "Type", true, DataSourceUpdateMode.Never);
        //}

        //private void btnCapNhat_Click(object sender, EventArgs e)
        //{
        //    KHACHHANG kh = new KHACHHANG();

        //    kh.MAKHACHHANG = int.Parse(txtMaKH.Text);
        //}

        //private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true;
        //    }
        //}

        //private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true;
        //    }
        //}
    }
}
