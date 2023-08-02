using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnCube_Switch.Services
{
    public class ItemService
    {
        /// <summary>
        /// 確認是否有該藥品名稱
        /// </summary>
        /// <param name="drug_name"></param>
        /// <returns></returns>
        public bool Ceck_drug(string drug_name)
        {
            var sql = $"select Mnemonic from Item where CommercialName = N'{drug_name}' and DeletedYN = 0";
            return (int)DBHelper.SelectForScalar(sql) == 1;
        }
        /// <summary>
        /// 取得MnemonicCode最後一筆的代碼
        /// </summary>
        /// <returns></returns>
        public string GetlastMnemonicCode()
        {
            var sql = $@"select  top 1 Mnemonic from item where DeletedYN =0 order by RawID desc";
            var dr = DBHelper.SelectForReader(sql);
            string last_code = "";
            if (dr.Read())
            {
                last_code = dr.GetString(0);
            }
            dr.Close();
            return last_code;
        }
        /// <summary>
        /// 取得目前Item最後一筆"加一"的代碼
        /// </summary>
        /// <returns></returns>
        public int GetlastRowCode()
        {
            var sql = $"select next value for dbo.itemID";
            var dr = DBHelper.SelectForReader(sql);
            int last_RowCode = 0;
            if (dr.Read())
            {
                last_RowCode = dr.GetInt32(0);
            }
            dr.Close();
            return last_RowCode;
        }
        /// <summary>
        /// 加入新的藥品名和新的代碼
        /// </summary>
        /// <param name="new_code"></param>
        /// <param name="newdrug"></param>
        /// <returns></returns>
        public void Insert_drug(string new_code, string newdrug)
        {
            var sql = $@"insert into Item (RawID, Mnemonic, CommercialName, GenericName , LastUpdatedBy) 
                       values({Getrow()}, '{new_code}', N'{newdrug}', N'{newdrug}', 2)"; //Getrow() 0802改
            DBHelper.SelectForScalar(sql);
        }
        /// <summary>
        /// 讀Mnemonic
        /// 以及
        /// 讀取GenericName
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetSqldata()
        {
            var sql = $"select Mnemonic,GenericName from item";
            var dr = DBHelper.SelectForReader(sql);
            Dictionary<string, string> data = new Dictionary<string, string>();
            while (dr.Read())
            {
                data.Add(dr.GetString(0), dr.GetString(1));
            }
            dr.Close();


            return data;

        }
        /// <summary>
        /// 取得列的個數後+1回傳
        /// </summary>
        public int Getrow()
        {
            int rowCount = 0;
            var sql_1 = $"select Mnemonic,GenericName from item ;";
            var sql_2 = $"SELECT @@ROWCOUNT";
            var dr = DBHelper.SelectForReader(sql_1, sql_2);
            if (dr.NextResult())
            {
                if (dr.Read())
                {
                    rowCount = Convert.ToInt32(dr[0]) + 1;
                    Debug.WriteLine($"{rowCount}");
                }
            }
            dr.Close();
            return rowCount;
        }
    }
}
