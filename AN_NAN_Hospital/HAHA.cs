using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnCube_Switch
{


    /// <summary>
    /// 單純用來讀取藥品名稱測試用的(目前不用)
    /// </summary>
    internal class HAHA
    {
        static bool y = false;
        static List<string> code = new List<string>();
        static List<string> name = new List<string>();
        /// <summary>
        /// 讀取檔案路徑
        /// </summary>
        private void add()
        {
            string filepath = Settings.CP_Path;
            ReadFile(filepath);
        }
        /// <summary>
        /// 接收一個字串來比較
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string Compare(string data) 
        {                                
            if (code==null||name == null||y==false) 
            {
                add();          
                y=true;
            }
            for(int i=0;i<=name.Count;i++)
            {
                if (name[i].Contains(data) || name.Contains(name[i]))
                {
                    return code[i];
                }                               
            }
            return "失敗";  //待修正
        }
        /// <summary>
        /// 讀取檔案中資料，(預設是CSV的TXT檔)(格式是,來分隔)
        /// </summary>
        /// <param name="filepath"></param>
        private void ReadFile(string filepath)
        {
            using (var reader = new StreamReader(filepath))
            {
             
                while (!reader.EndOfStream) //是不是在最後一列
                {
                    string line = reader.ReadLine();
                    string[] split = line.Split(',');
                    code.Add(split[0]);
                    name.Add(split[1]);
                                                       
                }
               
            }
        }


        /// <summary>
        /// 測試資料是否正確讀取
        /// </summary>
        public void text()
        {
            add();

            for (int i = 0; i < name.Count;i++)
            {

                Debug.WriteLine($"{code[i]}");
                Debug.WriteLine($"{name[i]}");

            }
            
        }
    }


}