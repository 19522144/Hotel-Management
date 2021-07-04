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
    }
}
