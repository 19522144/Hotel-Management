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
    public partial class fParameterUpdate : Form
    {
        ParameterController controller = new ParameterController();

        public fParameterUpdate()
        {
            InitializeComponent();
            
            THAMSO thamso = new THAMSO() {
                SOKHTOIDA1PHONG = 5, //thay doi theo man hinh
                HESOKHNUOCNGOAI = 2,
                PHUTHU = 1
            };
            controller.updateParameter(thamso);
            dgvDanhSachQuyDinh.DataSource = controller.getAll();
        }
    }
}
