using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
                           RoomName = c.PHIEUTHUE.PHONG.TENPHONG,
                           CustomerID = c.KHACHHANG.MAKHACHHANG,
                           CustomerName = c.KHACHHANG.TENKHACHHANG,
                           CMND = c.KHACHHANG.CMND,
                           DayStart = c.PHIEUTHUE.NGAYBDTHUE,
                           Address = c.KHACHHANG.DIACHI
                       };

            return data.ToList();
        }

        public int addRental(PHIEUTHUE pt)
        {
            entities.PHIEUTHUEs.Add(pt);
            entities.SaveChanges();
            return pt.MAPHIEUTHUE;
        }

        public void addRentalDetail(int MaPhieuThue, CHITIETPHIEUTHUE ctpt)
        {
            ctpt.MAPHIEUTHUE = MaPhieuThue;
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

        public dynamic findRental(int ID, string customerName, string roomName)
        {
            var result = from c in entities.CHITIETPHIEUTHUEs
                         select c;
            if (ID != -1)
                result =  from c in entities.CHITIETPHIEUTHUEs
                         where c.MAPHIEUTHUE == ID
                         select c;
            if (customerName != "")
                result =  from c in result
                     where c.KHACHHANG.TENKHACHHANG.Contains(customerName)
                     select c;
            if (roomName != "")
                result = from c in result
                     where c.PHIEUTHUE.PHONG.TENPHONG.Contains(roomName)
                     select c;

            var data = from c in result
                       select new
                       {
                           ID = c.MAPHIEUTHUE,
                           RoomName = c.PHIEUTHUE.PHONG.TENPHONG,
                           CustomerID = c.KHACHHANG.MAKHACHHANG,
                           CustomerName = c.KHACHHANG.TENKHACHHANG,
                           CMND = c.KHACHHANG.CMND,
                           DayStart = c.PHIEUTHUE.NGAYBDTHUE,
                           Address = c.KHACHHANG.DIACHI
                       };

            return data.ToList();
        }
    }
}
