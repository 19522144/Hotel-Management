using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel_Management.Controller
{
    class ParameterController
    {
        KHACHSANEntities entities = new KHACHSANEntities();

        public dynamic getAll()
        {
            return entities.THAMSOes.ToList();
        }

        public void updateParameter(THAMSO thamso)
        {
            THAMSO ts = entities.THAMSOes.FirstOrDefault();
            //MessageBox.Show("" + ts.HESOKHNUOCNGOAI);
            //entities.Entry(ts).CurrentValues.SetValues(thamso);
            //ts.SOKHTOIDA1PHONG = 5;
            entities.THAMSOes.Remove(ts);
            entities.SaveChanges();
            entities.THAMSOes.Add(thamso);
            entities.SaveChanges();          
        }
    }
}
