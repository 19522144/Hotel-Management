using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management.Controller
{
    class CustomerTypeController
    {
        KHACHSANEntities entities = new KHACHSANEntities();
        public dynamic getAll()
        {
            var data = from c in entities.LOAIKHACHes
                       select new { 
                       ID = c.MALOAIKHACH,
                       Name = c.TENLOAIKHACH
                       };

            return data.ToList();
        }
        public void insertCustomerType(LOAIKHACH lk, KHACHHANG kh)
        {
            entities.LOAIKHACHes.Add(lk);
            entities.SaveChanges();
            kh.MALOAIKHACH = lk.MALOAIKHACH;
            entities.KHACHHANGs.Add(kh);
            entities.SaveChanges();
        }
        public void updateCustomerType(LOAIKHACH lk, KHACHHANG kh)
        {
            LOAIKHACH l = entities.LOAIKHACHes.Find(lk.MALOAIKHACH);
            KHACHHANG k = entities.KHACHHANGs.Where(x => x.MALOAIKHACH == lk.MALOAIKHACH).SingleOrDefault();
            l.TENLOAIKHACH = lk.TENLOAIKHACH;
            k.MALOAIKHACH = kh.MALOAIKHACH;
            entities.SaveChanges();
        }
        public void deleteCustomer(int ID)
        {
            LOAIKHACH lk = entities.LOAIKHACHes.Find(ID);
            if (lk != null)
            {
                entities.LOAIKHACHes.Remove(lk);
                entities.SaveChanges();
            }
        }
    }
}
