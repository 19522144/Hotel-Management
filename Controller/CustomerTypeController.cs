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
                       select new
                       {
                           ID = c.MALOAIKHACH,
                           Name = c.TENLOAIKHACH
                       };

            return data.ToList();
        }
    }
}
