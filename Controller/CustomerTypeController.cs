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
            var data = entities.LOAIKHACHes;
            return data.ToList();
        }
        public void updateCustomerType(LOAIKHACH lk)
        {
            LOAIKHACH k = entities.LOAIKHACHes.Find(lk.MALOAIKHACH);
            k.MALOAIKHACH = lk.MALOAIKHACH;
            k.TENLOAIKHACH = lk.TENLOAIKHACH; 
            //MessageBox.Show("Here");
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
}
