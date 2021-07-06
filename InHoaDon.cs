using Hotel_Management.Controller;
using Microsoft.Office.Interop.Excel;
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
    public partial class InHoaDon : Form
    {
        BillController controller = new BillController();
        CHITIETHOADON cthoadon = new CHITIETHOADON();
        public InHoaDon(int billID)
        {
            InitializeComponent();
            cthoadon = controller.getBillByID(billID);

            txtMaKh.Text = cthoadon.HOADON.MAKHACHHANG.ToString();
            txtMaHoaDon.Text = cthoadon.HOADON.MAHOADON.ToString();
            dtpDay.Value = cthoadon.HOADON.NGAYTHANHTOAN;
            txtPrice.Text = cthoadon.HOADON.TRIGIA.ToString();

            txtMaCT.Text = cthoadon.MACHITIETHOADON.ToString();
            txtRoomName.Text = cthoadon.PHONG.TENPHONG;
            txtNumberDay.Text = cthoadon.SONGAYTHUE.ToString();
            txtUnitPrice.Text = cthoadon.DONGIA.ToString();
            txtMoney.Text = cthoadon.THANHTIEN.ToString();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
