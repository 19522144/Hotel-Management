using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel_Management.Controller
{
    class RentalController
    {
        KHACHSANEntities entities = new KHACHSANEntities();

        public dynamic getAll()
        {
            var data = from c in entities.CHITIETPHIEUTHUEs
                       select new
                       {
                           ID = c.MAPHIEUTHUE,
                           Room = c.PHIEUTHUE.PHONG.TENPHONG,
                           CustomerID = c.KHACHHANG.MAKHACHHANG,
                           CustomerName = c.KHACHHANG.TENKHACHHANG,
                           CMND = c.KHACHHANG.CMND,
                           DayStart = c.PHIEUTHUE.NGAYBDTHUE,
                           Address = c.KHACHHANG.DIACHI
                       };

            return data.ToList();
        }

        public void addRental(PHIEUTHUE pt, CHITIETPHIEUTHUE ctpt)
        {
            entities.PHIEUTHUEs.Add(pt);
            entities.SaveChanges();
            ctpt.MAPHIEUTHUE = pt.MAPHIEUTHUE;
            entities.CHITIETPHIEUTHUEs.Add(ctpt);
            entities.SaveChanges();
        }

        public void updateRental(PHIEUTHUE pt, CHITIETPHIEUTHUE ctpt)
        {
            PHIEUTHUE p = entities.PHIEUTHUEs.Find(pt.MAPHIEUTHUE);
            CHITIETPHIEUTHUE c = entities.CHITIETPHIEUTHUEs.Where(x => x.MAPHIEUTHUE == pt.MAPHIEUTHUE).SingleOrDefault();
            p.NGAYBDTHUE = pt.NGAYBDTHUE;
            p.MAPHONG = pt.MAPHONG;
            c.MAKHACHHANG = ctpt.MAKHACHHANG;           
            entities.SaveChanges();
        }

        public void deleteRental(int ID)
        {
            //MessageBox.Show("" + ID);
            PHIEUTHUE pt = entities.PHIEUTHUEs.Find(ID);
            if (pt != null)
            {
                CHITIETPHIEUTHUE ct = entities.CHITIETPHIEUTHUEs.Where(p => p.MAPHIEUTHUE == ID).SingleOrDefault();
                entities.CHITIETPHIEUTHUEs.Remove(ct);
                entities.PHIEUTHUEs.Remove(pt);
                entities.SaveChanges();
            }
        }
    }
}
