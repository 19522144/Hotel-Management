using Microsoft.Reporting.WebForms;
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
    public partial class fMainMenu : Form
    {
        fBillManagement billManagement;
        public static fBookRoom bookRoom;
        fCustomerManagement customerManagement;
        fManageStaff manageStaff;
        fQuanLyPhieuThue quanLyPhieuThue;
        fParameterUpdate parameterUpdate;
        fReport report;
        DangKi dangKi;
        InHoaDon inHoaDon;
        ManageCustomerType manageCustomerType;
        ManageRoomType manageRoomType;
        PersionalInformation persionalInformation;
        RoomManagement roomManagement;
        public static fMainMenu MainInstance;

        public fMainMenu()
        {
            InitializeComponent();
            if (MainInstance == null)
                MainInstance = this;
        }
        
        private void gotoPersonnalInformation(object sender, EventArgs e)
        {
            if (persionalInformation == null || persionalInformation.IsDisposed)
            {
                persionalInformation = new PersionalInformation(1); //
            }
            persionalInformation.Show();
        }

        private void exit(object sender, EventArgs e)
        {
            Close();
        }

        private void gotoBookRoom(object sender, EventArgs e)
        {
            if (bookRoom == null || bookRoom.IsDisposed)
            {
                bookRoom = new fBookRoom();
            }
            bookRoom.Show();
        }

        private void gotoRoomManage(object sender, EventArgs e)
        {
            if (roomManagement == null || roomManagement.IsDisposed)
            {
                roomManagement = new RoomManagement();
            }
            roomManagement.Show();
        }

        private void gotoRentalManage(object sender, EventArgs e)
        {
            if (quanLyPhieuThue == null || quanLyPhieuThue.IsDisposed)
            {
                quanLyPhieuThue = new fQuanLyPhieuThue();
            }
            quanLyPhieuThue.Show();
        }

        private void gotoCustomerManage(object sender, EventArgs e)
        {
            if (customerManagement == null || customerManagement.IsDisposed)
            {
                customerManagement = new fCustomerManagement();
            }
            customerManagement.Show();
        }

        private void gotoBillManage(object sender, EventArgs e)
        {
            if (billManagement == null || billManagement.IsDisposed)
            {
                billManagement = new fBillManagement();
            }
            billManagement.Show();
        }

        private void gotoReport(object sender, EventArgs e)
        {
            if (report == null || report.IsDisposed)
            {
                report = new fReport();
            }
            report.Show();
        }

        private void gotoCustomerType(object sender, EventArgs e)
        {
            if (manageCustomerType == null || manageCustomerType.IsDisposed)
            {
                manageCustomerType = new ManageCustomerType();
            }
            manageCustomerType.Show();
        }

        private void gotoRoomtype(object sender, EventArgs e)
        {
            if (manageRoomType == null || manageRoomType.IsDisposed)
            {
                manageRoomType = new ManageRoomType();
            }
            manageRoomType.Show();
        }

        private void gotoStaffManage(object sender, EventArgs e)
        {
            if (manageStaff == null || manageStaff.IsDisposed)
            {
                manageStaff = new fManageStaff();
            }
            manageStaff.Show();
        }

        private void gotoParameterUpdate(object sender, EventArgs e)
        {
            if (parameterUpdate == null || parameterUpdate.IsDisposed)
            {
                parameterUpdate = new fParameterUpdate();
            }
            parameterUpdate.Show();
        }

        private void fMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát ứng dung", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

    }
}
