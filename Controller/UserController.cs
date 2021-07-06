using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management.Controller
{
    class UserController
    {
        
        KHACHSANEntities entities = new KHACHSANEntities();
        public dynamic getAll()
        {
            var data = entities.NGUOIDUNGs;
            return data.ToList();
        }
        public void UpdateUser(NGUOIDUNG nd)
        {
            NGUOIDUNG d = entities.NGUOIDUNGs.Find(nd.MANGUOIDUNG);
            d.TENNGUOIDUNG = nd.TENNGUOIDUNG;
            d.TENDANGNHAP = nd.TENDANGNHAP;
            d.MATKHAU = nd.MATKHAU;
            d.QUYENTRUYCAP = nd.QUYENTRUYCAP;
            d.MATKHAU = nd.MATKHAU;
            //MessageBox.Show("Here");
            entities.SaveChanges();
        }
        public void DeleteUser(int ID)
        {
            NGUOIDUNG nd = new NGUOIDUNG();
            if (nd != null)
            {
                nd = entities.NGUOIDUNGs.Where(x => x.MANGUOIDUNG == ID).SingleOrDefault();
                entities.NGUOIDUNGs.Remove(nd);
                entities.SaveChanges();
            }
        }
    }
}
