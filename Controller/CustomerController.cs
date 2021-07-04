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
<<<<<<< HEAD
        public void insertCustomer(KHACHHANG kh, HOADON hd, CHITIETPHIEUTHUE ctpt)
        {
            entities.KHACHHANGs.Add(kh);
            entities.SaveChanges();
            hd.MAKHACHHANG = kh.MAKHACHHANG;
            entities.HOADONs.Add(hd);
            entities.SaveChanges();
            ctpt.MAKHACHHANG = kh.MAKHACHHANG;
            entities.CHITIETPHIEUTHUEs.Add(ctpt);
            entities.SaveChanges();
        }
        public void updateCustomer(KHACHHANG kh, HOADON hd, CHITIETPHIEUTHUE ctpt)
        {
            KHACHHANG k = entities.KHACHHANGs.Find(kh.MAKHACHHANG);
            HOADON h = entities.HOADONs.Where(x => x.MAKHACHHANG == kh.MAKHACHHANG ).SingleOrDefault();
            CHITIETPHIEUTHUE c = entities.CHITIETPHIEUTHUEs.Where(x => x.MAKHACHHANG == kh.MAKHACHHANG).SingleOrDefault();
            k.TENKHACHHANG = kh.TENKHACHHANG;
=======
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
>>>>>>> 22e77bb8718c3b49e2149b8fc792567894460c7f
            k.SODIENTHOAI = kh.SODIENTHOAI;
            k.QUOCTICH = kh.QUOCTICH;
            k.CMND = kh.CMND;
            k.DIACHI = kh.DIACHI;
            h.MAKHACHHANG = hd.MAKHACHHANG;
            c.MAKHACHHANG = ctpt.MAKHACHHANG;
            //MessageBox.Show("Here");
            entities.SaveChanges();
        }
        public void deleteCustomer(int ID)
        {
            KHACHHANG kh = entities.KHACHHANGs.Find(ID);
            if (kh != null)
            {
                HOADON h = entities.HOADONs.Where(x => x.MAKHACHHANG == kh.MAKHACHHANG).SingleOrDefault();
                CHITIETPHIEUTHUE c = entities.CHITIETPHIEUTHUEs.Where(x => x.MAKHACHHANG == kh.MAKHACHHANG).SingleOrDefault();
                entities.HOADONs.Remove(h);
                entities.CHITIETPHIEUTHUEs.Remove(c);
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
