using System.Text;
using static OnCube_Switch.Check_Content;

namespace OnCube_Switch
{
    /*
     * 創建一個txt檔案
     * 讀取存在OnCube暫存欄位的資料,依序依照邏輯輸出
     * 
     * 
     *      
     */

    internal class PrintFormat_Output
    {
        


        


        //打印格式涵式: 拿這個LIST之中所有類別出來
        public static void An_nan_print(List<Person_OC> datas)   
        {


            DateTime now = DateTime.Now;
             string dateString = now.ToString(("yyyy-MM-dd HHmmss"));
         string _outputPath = $@"{Settings.OutputPath}/測試TXT檔{dateString}.txt";






           var encoding = CodePagesEncodingProvider.Instance.GetEncoding("big5")!;
            using var writer = new StreamWriter(_outputPath, false, encoding);
            StringBuilder sb = new StringBuilder();
            foreach (var v in datas)
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
                sb.Append(v.Start_Date.PadRight(OnCubeFormatLength.Start_Date));
                //藥品結束日期
                sb.Append(v.Stop_Date.PadRight(OnCubeFormatLength.Stop_Date));

                sb.Append(v.Note.PadRight(OnCubeFormatLength.Note));

                sb.Append(v.Admin_Time_description.PadRight(OnCubeFormatLength.Admin_Time_description));

                sb.Append(v.Prescription_Number.PadRight(OnCubeFormatLength.Prescription_Number));
                //英文病人名稱
                sb.Append(v.English_Patient_Name.PadRight(OnCubeFormatLength.English_Patient_Name));
                //病人生日
                sb.Append(v.BirthDay.PadRight(OnCubeFormatLength.BirthDay));
                //病人性別
                sb.Append(ECD(v.Sex, OnCubeFormatLength.Sex));

                sb.Append(v.Room_Number.PadRight(OnCubeFormatLength.Room_Number));
                sb.Append(v.Bed_Number.PadRight(OnCubeFormatLength.Bed_Number));
                sb.Append(v.UnitDose_State);
                //醫院名稱
                sb.Append(ECD(v.Hospital_Name,OnCubeFormatLength.Hospital_Name));


                //每行30ch
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


            //MessageBox.Show("轉檔成功");
           
        }


         
        public static string ECD(string chine, int Length)  //處理中文
        {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding big5 = Encoding.GetEncoding(950);

            string data = chine.PadRight(Length,' ');
            byte[] Temp = big5.GetBytes(data);
            return big5.GetString(Temp, 0, Length);
        }












        /*


         public static string covertToBig5(string str, int len)       //轉成big5
        {
            byte[] strBytes = Encoding.GetEncoding("950").GetBytes(str);
            string big5Str = Encoding.GetEncoding("950").GetString(strBytes, 0, len);
            return big5Str;
        }











        //這個是用字節去數個數，補字符(Byte)用的
        public  static string PadRightToByteLength(string input, int byteLength)
        {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding big5 = Encoding.GetEncoding(950);


            // 將字串轉換為字節數組
            byte[] inputBytes = big5.GetBytes(input);

            // 檢查字節長度是否達到目標值
            if (inputBytes.Length >= byteLength)
            {
                // 字節長度已達到或超過目標值，直接返回原始字串
                return input;
            }

            // 計算需要填充的字節數量
            int paddingBytesCount = byteLength - inputBytes.Length;

            // 創建填充字節數組
            byte[] paddingBytes = new byte[paddingBytesCount];
            for (int i = 0; i < paddingBytesCount; i++)
            {
                paddingBytes[i] = 0;
            }

            // 合併原始字節數組和填充字節數組
            byte[] resultBytes = new byte[byteLength];
            Buffer.BlockCopy(inputBytes, 0, resultBytes, 0, inputBytes.Length);
            Buffer.BlockCopy(paddingBytes, 0, resultBytes, inputBytes.Length, paddingBytes.Length);

            // 將結果字節數組轉換回字串
            string result = big5.GetString(resultBytes);

            return result;
        }

        */

    }
}
