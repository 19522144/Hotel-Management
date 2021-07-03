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
        public void AddRoom(PHONG p)
        {
            entities.PHONGs.Add(p);
            entities.SaveChanges();
        }
        public void DeleteRoom(int ID)
        {
            PHONG p = entities.PHONGs.Find(ID);
            if (p != null)
            {
                entities.PHONGs.Remove(p);
                entities.SaveChanges();
            }
        }
        public void UpdateRoom(PHONG p)
        {
            PHONG ph= entities.PHONGs.Find(p.MAPHONG);
            entities.Entry(p).State = System.Data.Entity.EntityState.Modified;
            //LOAIPHONG l = entities.LOAIPHONGs.Where(x => x.MALOAIPHONG == p.MALOAIPHONG).SingleOrDefault();
            //l.TENLOAIPHONG = lp.TENLOAIPHONG;
            //ph.MAPHONG = p.MAPHONG;
            //ph.TENPHONG = p.TENPHONG;
            //l.TENLOAIPHONG = lp.TENLOAIPHONG;
            //ph.GHICHU = p.GHICHU;
            //ph.TINHTRANG = p.TINHTRANG;
            entities.SaveChanges();
        }
        public dynamic Search(string keyword)
        {
            var data = entities.PHONGs.Where(x => x.TENPHONG.Contains(keyword)).Select(y => new
            {
                ID = y.MAPHONG,
                Name = y.TENPHONG,
                RoomType = y.LOAIPHONG.TENLOAIPHONG,
                Status = y.TINHTRANG,
                Note = y.GHICHU,
            });
            return data.ToList();
        }
    }
}
