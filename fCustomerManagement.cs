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
    public partial class fCustomerManagement : Form
    {
        CustomerController controller = new CustomerController();
        public fCustomerManagement()
        {
            InitializeComponent();
            dgvData.DataSource = controller.getAll();
        }
    }
}
