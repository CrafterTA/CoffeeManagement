using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class AreaService
    {
        private static AreaService _instance;
        public static AreaService Instance
        {
            get
            {
                if (_instance == null) _instance = new AreaService();
                return _instance;
            }
            set => _instance = value;
        }
        public List<Area> GetAllAreas()
        {
            return DALArea.Instance.GetAllAreas();
        }
        public Area GetAreaByID(string areaID)
        {
            return DALArea.Instance.GetAreaByID(areaID);
        }
        public bool AddArea(string areaID, string areaName)
        {
            return DALArea.Instance.AddArea(areaID, areaName);
        }
        public bool UpdateArea(Area areas)
        {
            return DALArea.Instance.UpdateArea(areas);
        }
        public bool DeleteArea(string ID)
        {
            return DALArea.Instance.DeleteArea(ID);
        }
        public List<Area> SearchArea(string keyword)
        {
            return DALArea.Instance.SearchArea(keyword);
        }
    }
}
