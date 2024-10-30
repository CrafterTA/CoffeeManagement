using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALArea
    {
        private static DALArea _instance;
        public static DALArea Instance
        {
            get
            {
                if (_instance == null) _instance = new DALArea();
                return _instance;
            }
            set => _instance = value;
        }

        public List<Area> GetAllAreas()
        {
            return CafeEntities.Instance.Areas.ToList();
        }
        public Area GetAreaByID(string areaID)
        {
            return CafeEntities.Instance.Areas.Find(areaID);
        }
        public bool AddArea(string areaID, string areaName)
        {
            try
            {
                var obj = new Area();
                obj.AreaID = areaID;
                obj.AreaName = areaName;
                CafeEntities.Instance.Areas.Add(obj);
                CafeEntities.Instance.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                return false;
            }
        }
        public bool UpdateArea(Area areas)
        {
            try
            {
                var obj = GetAreaByID(areas.AreaID);
                if (obj != null)
                {
                    obj.AreaName = areas.AreaName;
                    CafeEntities.Instance.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                return false;
            }
        }
        public bool DeleteArea(string areaID) {
            try
            {
                var obj = GetAreaByID(areaID);
                if (obj != null)
                {
                    CafeEntities.Instance.Areas.Remove(obj);
                    CafeEntities.Instance.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                return false;
            }
        }
        public List<Area> SearchArea(string keyword)
        {
            keyword = keyword.ToLower().Trim();
            return CafeEntities.Instance.Areas
                .Where(c => c.AreaID.ToLower().Contains(keyword)
                         || c.AreaName.ToLower().Contains(keyword))
                .ToList();
        }
    }
}
