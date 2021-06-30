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
    public partial class fBookRoom : Form
    {
        RentalController RentalController = new RentalController();

        public fBookRoom()
        {
            InitializeComponent();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            PHIEUTHUE pt = new PHIEUTHUE()
            {
                MAPHONG = 1,
                NGAYBDTHUE = dtpDayRecieve.Value,
            };

            CHITIETPHIEUTHUE ctpt = new CHITIETPHIEUTHUE()
            {
                MAKHACHHANG = 1
            };

            RentalController.addRental(pt, ctpt);
        }
    }
}
