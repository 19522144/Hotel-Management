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
        public int insertCustomer(KHACHHANG kh)
        {
            entities.KHACHHANGs.Add(kh);
            entities.SaveChanges();
            return kh.MAKHACHHANG;
        }
        public void updateCustomer(KHACHHANG kh)
        {
            KHACHHANG k = entities.KHACHHANGs.Find(kh.MAKHACHHANG);
            k.TENKHACHHANG = kh.TENKHACHHANG;
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

        public dynamic findKhachHangByCMND(String CMND)
        {
            var kh = from c in entities.KHACHHANGs
                     where c.CMND.Contains(CMND)
                     select new
                     {
                         ID = c.MAKHACHHANG,
                         Name = c.TENKHACHHANG,
                         CMND = c.CMND,
                         Nationality = c.QUOCTICH,
                         Phone = c.SODIENTHOAI,
                         Type = c.LOAIKHACH.TENLOAIKHACH,
                         Address = c.DIACHI
                     };
            return kh.ToList().FirstOrDefault();
        }

        public KHACHHANG findKhachHangByID(int ID)
        {
            return entities.KHACHHANGs.Find(ID);
        }
    }
}
