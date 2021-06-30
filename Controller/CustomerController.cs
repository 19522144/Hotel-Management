using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebSockets;
using System.Windows.Controls;

namespace Hotel_Management.Controller
{
    class CustomerController
    {
        KHACHSANEntities entities = new KHACHSANEntities();

        public dynamic getAll()
        {
            var data = from c in entities.KHACHHANGs
                       select new 
                       { ID = c.MAKHACHHANG, 
                           Name = c.TENKHACHHANG,
                           Phone = c.SODIENTHOAI,
                           Nation = c.QUOCTICH,
                           CMND = c.CMND,
                           Address = c.DIACHI,
                           Type = c.LOAIKHACH.TENLOAIKHACH
                       };

            return data.ToList();
        }

        public void updateData(KHACHHANG khachhang)
        {
            KHACHHANG kh = entities.KHACHHANGs.Find(khachhang.MAKHACHHANG);
            kh = khachhang;
            entities.SaveChanges();
        }
    }
}
