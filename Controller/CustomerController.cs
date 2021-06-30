using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management.Controller
{
    class CustomerController
    {
        KHACHSANEntities entities = new KHACHSANEntities();

        public dynamic getAll()
        {
            var data = entities.KHACHHANGs;
            return data.ToList();
        }
        public void updateCustomer(LOAIKHACH lk, KHACHHANG kh)
        {
            KHACHHANG k = entities.KHACHHANGs.Find(kh.MAKHACHHANG);
            LOAIKHACH l = entities.LOAIKHACHes.Where(x => x.MALOAIKHACH == kh.MALOAIKHACH).SingleOrDefault();
            k.TENKHACHHANG = kh.TENKHACHHANG;
            k.MAKHACHHANG = kh.MAKHACHHANG;
            k.QUOCTICH = kh.QUOCTICH;
            k.SODIENTHOAI = kh.SODIENTHOAI;
            k.CMND = kh.CMND;
            k.DIACHI = kh.DIACHI; 
            //MessageBox.Show("Here");
            entities.SaveChanges();
        }
        public void deleteCustomer(int ID)
        {
            KHACHHANG kh = entities.KHACHHANGs.Find(ID);
            if (kh != null)
            {
                LOAIKHACH lk = entities.LOAIKHACHes.Where(x => x.MALOAIKHACH == ID).SingleOrDefault();
                entities.LOAIKHACHes.Remove(lk);
                entities.KHACHHANGs.Remove(kh);
                entities.SaveChanges();
            }
        }
    }
}
