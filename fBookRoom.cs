using Hotel_Management.Controller;
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
    public partial class fBookRoom : Form
    {
        RentalController RentalController = new RentalController();
        RoomController roomController = new RoomController();
        CustomerController customerController = new CustomerController();
        CustomerTypeController customerTypeController = new CustomerTypeController();
        ParameterController parameterController = new ParameterController();

        public fBookRoom()
        {
            InitializeComponent();

            cmbRoom.DataSource = roomController.getAll();
            cmbRoom.DisplayMember = "Name";
            cmbRoom.ValueMember = "ID";

            nudPeople.Maximum = parameterController.SOKHTOIDA1PHONG();
            nudPeople.Minimum = 1;

            cmbCustomerType.DataSource = customerTypeController.getAll();
            cmbCustomerType.DisplayMember = "Name";
            cmbCustomerType.ValueMember = "ID";

            monthCalendar.MaxSelectionCount = 1;
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if (!checkEmpty())
            {
                MessageBox.Show("Vui lòng điền đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Xác nhận đặt phòng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int MaKhachHang;
                if (txtMaKhachHang.Text != "")
                {
                    MaKhachHang = Convert.ToInt32(txtMaKhachHang.Text);
                }
                else
                {
                    KHACHHANG kh = new KHACHHANG()
                    {
                        TENKHACHHANG = txtName.Text,
                        MALOAIKHACH = (int)cmbCustomerType.SelectedValue,
                        QUOCTICH = txtNationality.Text,
                        SODIENTHOAI = txtSDT.Text,
                        CMND = txtCMND.Text,
                        DIACHI = txtAddress.Text
                    };
                    MaKhachHang = customerController.insertCustomer(kh);
                }

                CHITIETPHIEUTHUE ctpt = new CHITIETPHIEUTHUE()
                {
                    MAKHACHHANG = MaKhachHang,
                };

                PHIEUTHUE pt = new PHIEUTHUE()
                {
                    MAPHONG = (int)cmbRoom.SelectedValue,
                    NGAYBDTHUE = dtpDayRecieve.Value,
                };

                RentalController.addRental(pt, ctpt);
            }
        }

        private bool checkEmpty()
        {
            foreach (Control item in groupBoxCustomer.Controls)
            {
                if (item is TextBox && item.Text == "")
                {
                    return false;
                }
            }

            return true;
        }

        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            dynamic a = cmbRoom.SelectedItem;
            txtRoomTpye.Text = a.RoomType;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            dynamic value = customerController.findKhachHangByCMND(txtCMND.Text);
            if (value != null)
            {
                txtCMND.Text = value.CMND;
                txtMaKhachHang.Text = value.ID.ToString();
                txtName.Text = value.Name;
                txtNationality.Text = value.Nationality;
                txtSDT.Text = value.Phone;
                txtAddress.Text = value.Address;
                cmbCustomerType.Text = value.Type;
                //foreach (dynamic item in cmbCustomerType.Items)
                //{
                //    //MessageBox.Show(item.Name + " " + value.Type);
                //    if (item.Name == value.Type)
                //    {
                //        cmbCustomerType.SelectedItem = item;
                //        //MessageBox.Show("TRUE");
                //        break;
                //    }
                //}
            }
            else MessageBox.Show("Không tìm thấy, vui lòng kiểm tra lại thông tin",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            dtpDayRecieve.Value = monthCalendar.SelectionRange.Start;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (Control item in groupBoxCustomer.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
