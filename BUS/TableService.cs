using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TableService
    {
        private static TableService _instance;
        public static TableService Instance
        {
            get
            {
                if (_instance == null) _instance = new TableService();
                return _instance;
            }
            set => _instance = value;
        }
        public List<CF_Table> GetAllTables()
        {
            return DALTable.Instance.GetAllTables();
        }
        public CF_Table GetTableByID(string tableID)
        {
            return DALTable.Instance.GetTableByID(tableID);
        }
        public bool AddTable(string tableID, string tableName, string areaID)
        {
            return DALTable.Instance.AddTable(tableID, tableName, areaID);
        }
        public bool UpdateTable(CF_Table tables)
        {
            return DALTable.Instance.UpdateTable(tables);
        }
        public bool DeleteTable(string tableID)
        {
            return DALTable.Instance.DeleteTable(tableID);
        }
        public List<CF_Table> SearchTable(string keyword)
        {
            return DALTable.Instance.SearchTable(keyword);
        }
    }
}
