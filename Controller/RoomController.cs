using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management.Controller
{
    class RoomController
    {
        KHACHSANEntities entities = new KHACHSANEntities();
        public dynamic getAll()
        {
            var data = from c in entities.PHONGs
                       select new
                       {
                           ID = c.MAPHONG,
                           Name = c.TENPHONG,
                           RoomType = c.LOAIPHONG.TENLOAIPHONG,
                           Status = c.TINHTRANG,
                           Note = c.GHICHU,
                       };
            return data.ToList();
        }
        public dynamic All()
        {
            var data = entities.LOAIPHONGs;
            return data.ToList();
        }
        public void AddRoom(PHONG p, LOAIPHONG lp)
        {
            entities.LOAIPHONGs.Add(lp);
            entities.SaveChanges();
            entities.PHONGs.Add(p);
            entities.SaveChanges();
        }
        public void DeleteRoom(int ID)
        {
            PHONG p = entities.PHONGs.Find(ID);
            if (p != null)
            {
                LOAIPHONG lp = entities.LOAIPHONGs.Where(x => x.MALOAIPHONG == ID).SingleOrDefault();
                //entities.LOAIPHONGs.Remove(lp);
                entities.PHONGs.Remove(p);
                entities.SaveChanges();
            }
        }
        public void UpdateRoom(PHONG p, LOAIPHONG lp)
        {
            PHONG ph = entities.PHONGs.Find(p.MAPHONG);
            LOAIPHONG l = entities.LOAIPHONGs.Where(x => x.MALOAIPHONG == p.MALOAIPHONG).SingleOrDefault();
            //l.TENLOAIPHONG = lp.TENLOAIPHONG;
            ph.MAPHONG = p.MAPHONG;
            ph.TENPHONG = p.TENPHONG;
            ph.GHICHU = p.GHICHU;
            ph.TINHTRANG = p.TINHTRANG;
            entities.SaveChanges();
        }
    }
}
