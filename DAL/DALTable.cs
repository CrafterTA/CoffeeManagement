using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALTable
    {
        private static DALTable instance;
        public static DALTable Instance
        {
            get
            {
                if (instance == null)
                    instance = new DALTable();
                return instance;
            }
            private set => instance = value;
        }
        public List<CF_Table> GetAllTables()
        {
            return CafeEntities.Instance.CF_Table.ToList();
        }
        public CF_Table GetTableByID(string tableID)
        {
            return CafeEntities.Instance.CF_Table.Find(tableID);
        }
        public bool AddTable(string tableID, string tableName, string areaID)
        {
            try
            {
                var obj = new CF_Table();
                obj.TableID = tableID;
                obj.TableName = tableName;
                obj.AreaID = areaID;

                CafeEntities.Instance.CF_Table.Add(obj);
                CafeEntities.Instance.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                return false;
            }
        }
        public bool UpdateTable(CF_Table tables)
        {
            try
            {
                var obj = GetTableByID(tables.TableID);
                if (obj != null)
                {
                    obj.TableName = tables.TableName;
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
        public bool DeleteTable(string tableID)
        {
            try
            {
                var obj = GetTableByID(tableID);
                if (obj != null)
                {
                    CafeEntities.Instance.CF_Table.Remove(obj);
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
        public List<CF_Table> SearchTable(string keyword)
        {
            keyword = keyword.ToLower().Trim();
            return CafeEntities.Instance.CF_Table.Where(x => x.TableID.Contains(keyword) || x.TableName.Contains(keyword)).ToList();
        }
    }
}
