using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnCube_Switch
{

    /// <summary>
    /// 這是把CSV那個藥品輸出成TXT資料庫的  (更改方案，故"目前不用")
    /// </summary>
    internal class CP_txt
    {
        static Dictionary<string, string> data = new Dictionary<string, string>();
        static bool Ifdo = false;
        /// <summary>
        /// 讀取txt檔案，存到一個字典串列中，使其成為一個資料庫
        /// </summary>
        private void Read_txtDB()
        {
            string Txtfile = Settings.CP_Path;
            using (var Txtreader = new StreamReader(Txtfile))
            {
                while (!Txtreader.EndOfStream) //是不是在最後一列
                {
                    string line = Txtreader.ReadLine();
                    string[] split = line.Split(',');
                    data.Add(split[1], split[0]);
                }
            }
        }

        /// <summary>
        /// 創建(更新)一個txt檔，使他變成資料庫
        /// </summary>
        /// <param name="Newname"></param>
        private void CreatDB_txt(string Newname)
        {
            string Directory_txt = Settings.CP_Path;
            DateTime now = DateTime.Now;
            string DateString = now.ToString("yyyyMMdd");
            string froldpath = $"{Path.GetDirectoryName(Directory_txt)}";
            string New_TxtPath = $"{froldpath}{DateString}";
            using (var Txtwrite = new StreamWriter(New_TxtPath))
            {
                StringBuilder sb = new StringBuilder();
                string new_code = (data.Count + 1).ToString().PadLeft(3, '0');
                foreach (var (code, name) in data)
                {
                    sb.Append(code);
                    sb.Append(',');
                    sb.AppendLine(name);
                }
                sb.Append($"AC{new_code}");
                sb.Append(",");
                sb.AppendLine(Newname);
                Txtwrite.Write(sb.ToString());
            }
            File.Move(Directory_txt, New_TxtPath);
        }

        /// <summary>
        /// 接收一個字串，來比較資料庫是否有對應資料
        /// </summary>
        /// <param name="old_name"></param>
        /// <returns></returns>
        public string Compare(string old_name)
        {
            bool Scan = false;

            if (data == null || Ifdo == false)
            {
                Read_txtDB();
                Ifdo = true;
            }
            do
            {
                if (data.ContainsKey(old_name))
                {
                    Scan = true;
                    return data[old_name];
                }
                else
                {
                    CreatDB_txt(old_name);
                }
            } while (Scan);
            return "失敗";  //待修正
        }
    }

}
