using OnCube_Switch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnCube_Switch
{

    /// <summary>
    /// 字串比較，呼叫SQL的"item"操作功能，等等都在這
    /// </summary>
    internal class Compare_Qname
    {
        ItemService itemSer = new ItemService();

        public static Dictionary<string, string> data = new Dictionary<string, string>();


        /// <summary>
        /// 清除字典資料，讀取SQL資料給字典
        /// </summary>
        public void Read_txtDB()
        {
            data.Clear();
            data = itemSer.GetSqldata();
        }

        /// <summary>
        /// 創建SQL資料，AC00000
        /// </summary>
        /// <param name="Newname"></param>

        private void CreatDB_txt(string Newname)
        {
            string inputString = itemSer.Getrow().ToString();      //GetlastMnemonicCode();        //之前是以最後的代碼判別，現在是以RawID去新增
            string numberPattern = @"\d+";
            int match;
            MatchCollection numberMatches = Regex.Matches(inputString, numberPattern);


            Match match1 = numberMatches[0];
            match = Int32.Parse(match1.Value); //+1  //原本用row的涵式已經+1了，用AC0000才需要+1

            string new_code = $"AC{match.ToString().PadLeft(5, '0')}";
            itemSer.Insert_drug(new_code, Newname);

        }

        /// <summary>
        /// 匹配藥品名稱，回傳對應藥品代碼(主要匹配功能進入點)
        /// </summary>
        /// <param name="old_name"></param>
        /// <returns></returns>
        public string Compare(string old_name)
        {
            bool Scan = true;  //是否掃過SQL資料
            string restring = "0";  //預設返回字串

            Read_txtDB();
            do
            {
                foreach (var kvp in data)  //一個個拿出字典中資料
                {
                    if (kvp.Value == old_name)
                    {
                        restring = kvp.Key;
                        Scan = false;
                        break;
                    }
                }

                if (restring == "0")   //沒有找到就加入一個資料
                {
                    CreatDB_txt(old_name);
                    Read_txtDB();
                }


            } while (Scan);

            return restring;
            //待修正

        }

    }
}
