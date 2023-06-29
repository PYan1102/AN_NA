using System.Text;
using OnCube_Switch.Models;

namespace OnCube_Switch
{
    /*
     * 創建一個txt檔案
     * 讀取存在OnCube暫存欄位的資料,依序依照邏輯輸出
     */
    internal class FileOutput
    {        
        //打印格式涵式: 拿這個LIST之中所有類別出來
        public static void An_nan_print(List<OCS_Person> datas,string fileName)   //接收一個類別串列型別 ， 在此名為data
        {
            var encoding = CodePagesEncodingProvider.Instance.GetEncoding("big5")!;
            string outputPath = $@"{Settings.OutputPath}/{fileName}_{DateTime.Now:ssfff}.txt";          //"文字檔案"名稱
            using var writer = new StreamWriter(outputPath, false, encoding);
            StringBuilder sb = new StringBuilder();
            foreach (var v in datas)   //依序把串列中每個類別一個個拿出來
            {
                //病患名子
                sb.Append(ECD(v.Patient_Name,OnCubeFormatLength.Patient_Name));
                //病患ID
                sb.Append(v.Patient_ID.PadRight(OnCubeFormatLength.Patient_ID));
                //看診位置
                sb.Append(v.Patient_Location.PadRight(OnCubeFormatLength.Patient_Location));
                sb.Append(v.Doctor_Name.PadRight(OnCubeFormatLength.Doctor_Name));
                sb.Append(v.BUT.PadRight(OnCubeFormatLength.BUT));
                sb.Append(v.Quantity.PadRight(OnCubeFormatLength.Quantity));
                //藥品代碼
                sb.Append(v.Drug_Code.PadRight(OnCubeFormatLength.Drug_Code));
                //藥品通用名
                sb.Append(ECD(v.Medicine_Name,OnCubeFormatLength.Medicine_Name));
                sb.Append(v.Admin_Time.PadRight(OnCubeFormatLength.Admin_Time));
                //藥品開始日期
                sb.Append(v.StartDate.ToString("yyMMdd"));
                //藥品結束日期
                sb.Append(v.StopDate.ToString("yyMMdd"));
                sb.Append(v.Note.PadRight(OnCubeFormatLength.Note));
                sb.Append(v.Admin_Time_description.PadRight(OnCubeFormatLength.Admin_Time_description));
                sb.Append(v.Prescription_Number.PadRight(OnCubeFormatLength.Prescription_Number));
                //英文病人名稱
                sb.Append(v.English_Patient_Name.PadRight(OnCubeFormatLength.English_Patient_Name));
                //病人生日
                sb.Append(v.BirthDate.ToString("yyyy-MM-dd"));
                //病人性別
                sb.Append(ECD(v.Sex, OnCubeFormatLength.Sex));
                sb.Append(v.Room_Number.PadRight(OnCubeFormatLength.Room_Number));
                sb.Append(v.Bed_Number.PadRight(OnCubeFormatLength.Bed_Number));
                sb.Append(v.UnitDose_State);
                //醫院名稱
                sb.Append(ECD(v.Hospital_Name,OnCubeFormatLength.Hospital_Name));
                //每行30ch  以下共450byte
                sb.Append(v.Random_1.PadRight(OnCubeFormatLength.Random_1));
                sb.Append(v.Random_2.PadRight(OnCubeFormatLength.Random_2));
                sb.Append(v.Random_3.PadRight(OnCubeFormatLength.Random_3));
                sb.Append(v.Random_4.PadRight(OnCubeFormatLength.Random_4));
                sb.Append(v.Random_5.PadRight(OnCubeFormatLength.Random_5));
                sb.Append(v.Random_6.PadRight(OnCubeFormatLength.Random_6));
                sb.Append(v.Random_7.PadRight(OnCubeFormatLength.Random_7));
                sb.Append(v.Random_8.PadRight(OnCubeFormatLength.Random_8));
                sb.Append(v.Random_9.PadRight(OnCubeFormatLength.Random_9));
                sb.Append(v.Random_10.PadRight(OnCubeFormatLength.Random_10));                    
                sb.Append(v.Random_11.PadRight(OnCubeFormatLength.Random_11));
                sb.Append(v.Random_12.PadRight(OnCubeFormatLength.Random_12));
                sb.Append(v.Random_13.PadRight(OnCubeFormatLength.Random_13));
                sb.Append(v.Random_14.PadRight(OnCubeFormatLength.Random_14));
                sb.Append(v.Random_15.PadRight(OnCubeFormatLength.Random_15));
                sb.AppendLine(v.Dose_Type.PadRight(OnCubeFormatLength.Dose_Type));
            }
            writer.Write(sb.ToString());
        }        
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
