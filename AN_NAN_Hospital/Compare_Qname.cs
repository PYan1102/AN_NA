using OnCube_Switch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnCube_Switch
{
    internal class Compare_Qname
    {
        ItemService itemSer = new ItemService();

        public static Dictionary<string, string> data = new Dictionary<string, string>();




        /// <summary>
        /// 讀取SQL資料
        /// </summary>
        public void Read_txtDB()
        {
            data.Clear();
            data = itemSer.GetSqldata();
        }




        /// <summary>
        /// 創建SQL資料
        /// </summary>
        /// <param name="Newname"></param>
        /// <param name="data"></param>

        private void CreatDB_txt(string Newname)
        {
            string inputString = itemSer.GetlastMnemonicCode();
            string numberPattern = @"\d+";
            int match;
            MatchCollection numberMatches = Regex.Matches(inputString, numberPattern);


            Match match1 = numberMatches[0];
            match = Int32.Parse(match1.Value) + 1;

            string new_code = $"AC{match.ToString().PadLeft(5, '0')}";
            itemSer.Insert_drug(new_code, Newname);





        }

        /// <summary>
        /// 比較SQL資料
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
