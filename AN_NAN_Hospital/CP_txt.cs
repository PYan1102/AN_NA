using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnCube_Switch
{
    internal class CP_txt
    {
        static Dictionary<string, string> data = new Dictionary<string, string>();
        static bool Ifdo = false;

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
        //(int i = 0; i <= data.Count; i++)











        /*
         if (data == null || data.Count == 0||Ifdo==false)
         {

         }
         */
    }

}
