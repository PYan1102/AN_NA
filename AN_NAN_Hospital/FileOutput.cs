using System.Text;
using OnCube_Switch.Models;

namespace OnCube_Switch
{
    /// <summary>
    /// 創建一個txt檔案
    /// 讀取存在OnCube類別成員串列暫存欄位的資料,依序依照邏輯輸出txt
    /// </summary>
    internal class FileOutput
    {
        /// <summary>
        /// 接收一個類別串列型別data和檔案字串位置
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="fileName"></param>
        public static void An_nan_print(List<OCS_Person> datas,string fileName)   
        {
            var encoding = CodePagesEncodingProvider.Instance.GetEncoding("big5")!;
            string outputPath = $@"{Settings.OutputPath}/{fileName}_{DateTime.Now:ssfff}.txt";          //"文字檔案"名稱(用毫秒就不會重複了)
            using var writer = new StreamWriter(outputPath, false, encoding);
            StringBuilder sb = new StringBuilder();
            foreach (var v in datas)   //依序把串列中每個類別一個個拿出來
            {
                //病患名子
                sb.Append(ECD(v.Patient_Name,OnCubeFormatLength.Patient_Name));
                //病患ID
                sb.Append(v.Patient_ID.PadRight(OnCubeFormatLength.Patient_ID));
                //看診位置
                sb.Append(ECD(v.Patient_Location,OnCubeFormatLength.Patient_Location));
                sb.Append("".PadRight(OnCubeFormatLength.Doctor_Name));
                sb.Append("".PadRight(OnCubeFormatLength.BUT));
                sb.Append(v.Quantity.ToString().PadRight(OnCubeFormatLength.Quantity));
                //藥品代碼
                sb.Append(v.Drug_Code.PadRight(OnCubeFormatLength.Drug_Code));
                //藥品通用名
                sb.Append(ECD(v.Medicine_Name,OnCubeFormatLength.Medicine_Name));
                sb.Append(v.Admin_Time.PadRight(OnCubeFormatLength.Admin_Time));
                //藥品開始日期
                sb.Append(v.StartDate.ToString("yyMMdd"));
                //藥品結束日期
                sb.Append(v.StopDate.ToString("yyMMdd"));
                sb.Append("".PadRight(OnCubeFormatLength.Note));
                sb.Append("".PadRight(OnCubeFormatLength.Admin_Time_description));
                sb.Append("".PadRight(OnCubeFormatLength.Prescription_Number));
                //英文病人名稱
                sb.Append("".PadRight(OnCubeFormatLength.English_Patient_Name));
                //病人生日
                sb.Append(v.BirthDate.ToString("yyyy-MM-dd"));
                //病人性別
                sb.Append("".PadRight(OnCubeFormatLength.Sex));
                sb.Append("".PadRight(OnCubeFormatLength.Room_Number));
                sb.Append("".PadRight(OnCubeFormatLength.Bed_Number));
                sb.Append("".PadRight(OnCubeFormatLength.UnitDose_State));
                //醫院名稱
                sb.Append(ECD(v.Hospital_Name,OnCubeFormatLength.Hospital_Name));
                /*
                *每行30ch  以下共450byte
                *sb.Append(v.Random_1.PadRight(OnCubeFormatLength.Random_1~Random_15));    
                */
                sb.Append("".PadRight(450));               
                sb.AppendLine(v.Dose_Type.PadRight(OnCubeFormatLength.Dose_Type)); //最後換行
            }
            writer.Write(sb.ToString()); //用寫入流把串接的字串寫到新增的txt
        }        

        /// <summary>
        /// 接收中文字，需要補齊的長度
        /// </summary>
        /// <param name="chine"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string ECD(string chine, int Length)  //處理中文
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding big5 = Encoding.GetEncoding(950);
            string data = chine.PadRight(Length,' ');
            byte[] Temp = big5.GetBytes(data);
            return big5.GetString(Temp, 0, Length);
        }
    }
}
