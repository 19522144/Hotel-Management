using Hotel_Management.Controller;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management
{
    public partial class fQuanLyPhieuThue : Form
    {
        RentalController rentalController = new RentalController();
        RoomController roomController = new RoomController();
        CustomerController customerController = new CustomerController();
        BillController billController = new BillController();

        DateTime dateStart = new DateTime();

        public fQuanLyPhieuThue()
        {
            InitializeComponent();
            LoadData();
            cmbTenPhong.DataSource = roomController.getAll();
            cmbTenPhong.DisplayMember = "Name";
            cmbTenPhong.ValueMember = "ID";
            dtpkNgayBatDauThue.Value = (DateTime) dgvDanhSachPhieuThue.Rows[0].Cells["DayStart"].Value;
            dateStart = dtpkNgayBatDauThue.Value;
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
            txtMaKhachHang.DataBindings.Clear();

            txtMaPhieuThue.DataBindings.Add("Text", dgvDanhSachPhieuThue.DataSource, "ID", true, DataSourceUpdateMode.Never);
            txtTenKhachHang.DataBindings.Add("Text", dgvDanhSachPhieuThue.DataSource, "CustomerName", true, DataSourceUpdateMode.Never);
            txtCMND.DataBindings.Add("Text", dgvDanhSachPhieuThue.DataSource, "CMND", true, DataSourceUpdateMode.Never);
            txtDiaChi.DataBindings.Add("Text", dgvDanhSachPhieuThue.DataSource, "Address", true, DataSourceUpdateMode.Never);
            txtMaKhachHang.DataBindings.Add("Text", dgvDanhSachPhieuThue.DataSource, "CustomerID", true, DataSourceUpdateMode.Never);
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
                MAPHONG = (int) cmbTenPhong.SelectedValue,
                MAPHIEUTHUE = Int32.Parse(txtMaPhieuThue.Text),
                NGAYBDTHUE = dtpkNgayBatDauThue.Value
            };

            CHITIETPHIEUTHUE ct = new CHITIETPHIEUTHUE()
            {
                MAKHACHHANG = Convert.ToInt32(txtMaKhachHang.Text)
            };

            KHACHHANG kh = customerController.findKhachHangByID(Convert.ToInt32(txtMaKhachHang.Text));
            kh.TENKHACHHANG = txtTenKhachHang.Text;
            kh.CMND = txtCMND.Text;
            kh.DIACHI = txtDiaChi.Text;
            rentalController.updateRental(pt, ct);
            customerController.updateCustomer(kh);

            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //PHIEUTHUE phieuthue = new PHIEUTHUE()
            //{
            //    MAPHONG = (int)cmbTenPhong.SelectedValue,
            //    NGAYBDTHUE = dtpkNgayBatDauThue.Value,
            //};
            //CHITIETPHIEUTHUE ct = new CHITIETPHIEUTHUE()
            //{
            //    MAKHACHHANG = Convert.ToInt32(txtMaKhachHang.Text),
            //};
            //rentalController.addRental(phieuthue, ct);
            //LoadData();
            if (fMainMenu.bookRoom == null || fMainMenu.bookRoom.IsDisposed)
                fMainMenu.bookRoom = new fBookRoom();
            fMainMenu.bookRoom.Show();
        }

        private void dgvDanhSachPhieuThue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            string RoomName = (string)dgvDanhSachPhieuThue.Rows[row].Cells["RoomName"].Value;
            dateStart = (DateTime) dgvDanhSachPhieuThue.Rows[row].Cells["DayStart"].Value;

            dtpkNgayBatDauThue.Value = dateStart;
            foreach (dynamic item in cmbTenPhong.Items)
            {
                if (item.Name == RoomName)
                {
                    cmbTenPhong.SelectedItem = item;
                    break;
                }
            }
            //cmbTenPhong.SelectedIndex = cmbTenPhong.Items.IndexOf(roomController.findRoom(RoomName));
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int ID = -1;
            if (txtTimMaPhieuThue.Text != "")
            {
                ID = Convert.ToInt32(txtTimMaPhieuThue.Text);
            }
            dgvDanhSachPhieuThue.DataSource = rentalController
                .findRental(ID, txtTimTenKH.Text, txtTimTenPhong.Text);
        }

        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void btnXuatFileExcel_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "*.xls|.xls";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // creating Excel Application  
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // creating new WorkBook within Excel application  
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                // creating new Excelsheet in workbook  
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                // see the excel sheet behind the program  
                app.Visible = true;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                // changing the name of active sheet  
                worksheet.Name = "Exported from gridview";
                // storing header part in Excel  
                for (int i = 1; i < dgvDanhSachPhieuThue.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dgvDanhSachPhieuThue.Columns[i - 1].HeaderText;
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < dgvDanhSachPhieuThue.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvDanhSachPhieuThue.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dgvDanhSachPhieuThue.Rows[i].Cells[j].Value.ToString();
                    }
                }
                
                // save the application  
                workbook.SaveAs(dialog.InitialDirectory + dialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                // Exit from the application  
                app.Quit();
            }
            
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có muốn xuất hóa đơn cho phiếu thuê này không ?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }
            TimeSpan timeSpan = DateTime.Now - dateStart;
            int soNgay = timeSpan.Days;
            dynamic a = cmbTenPhong.SelectedItem;
            Decimal TriGia = a.Price * soNgay;

            //MessageBox.Show("" + TriGia);
            HOADON hoadon = new HOADON()
            {
                MAKHACHHANG = Convert.ToInt32(txtMaKhachHang.Text),
                NGAYTHANHTOAN = DateTime.Now,
                TRIGIA = 0
            };

            CHITIETHOADON chitiet = new CHITIETHOADON()
            {
                DONGIA = a.Price,
                MAPHONG = (int)cmbTenPhong.SelectedValue,
                SONGAYTHUE = soNgay,
                THANHTIEN = TriGia
            };
            billController.addBill(hoadon, chitiet);
            rentalController.deleteRental(Convert.ToInt32(txtMaPhieuThue.Text));
            LoadData();
            InHoaDon inHoaDon = new InHoaDon();//Ve sau se truyen ma hoa don vao day
            inHoaDon.Show();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
