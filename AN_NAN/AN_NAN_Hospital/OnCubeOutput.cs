using System.Text;

namespace OnCube_Switch
{
    internal class OnCubeOutput
    {
        


        static DateTime now = DateTime.Now;
        static string dateString = now.ToString(("yyyy-MM-dd"));


        private static string _outputPath = $@"{Settings.OutputPath}/測試TXT檔{dateString}.txt";
        public static void PrintFormat(List<Person_OC> datas)
        {
            var encoding = CodePagesEncodingProvider.Instance.GetEncoding("big5")!;
            using var writer = new StreamWriter(_outputPath, false, encoding);
            StringBuilder sb = new StringBuilder();
            foreach (var v in datas)
            {
                sb.Append(v.Patient_Name);
                sb.Append(v.Patient_ID);
                sb.Append(v.Patient_Location);
                sb.Append(v.Doctor_Name);
                sb.Append(v.BUT);
                sb.Append(v.Quantity);
                sb.Append(v.Drug_Code);
                sb.Append(v.Medicine_Name);
                sb.Append(v.Admin_Time);
                sb.Append(v.Start_Date);
                sb.Append(v.Stop_Date);
                sb.Append(v.Note);
                sb.Append(v.Admin_Time_description);
                sb.Append(v.Prescription_Number);
                sb.Append(v.English_Patient_Name);
                sb.Append(v.BirthDay);
                sb.Append(v.Sex);
                sb.Append(v.Room_Number);
                sb.Append(v.Bed_Number);
                sb.Append(v.UnitDose_State);
                sb.Append(v.Hospital_Name);
                sb.Append(v.Random_1);
                sb.Append(v.Random_2);
                sb.Append(v.Random_3);
                sb.Append(v.Random_4);
                sb.Append(v.Random_5);
                sb.Append(v.Random_6);
                sb.Append(v.Random_7);
                sb.Append(v.Random_8);
                sb.Append(v.Random_9);
                sb.Append(v.Random_10);                    
                sb.Append(v.Random_11);
                sb.Append(v.Random_12);
                sb.Append(v.Random_13);
                sb.Append(v.Random_14);
                sb.Append(v.Random_15);
                sb.AppendLine(v.Dose_Type);
            }
            writer.Write(sb.ToString());


            MessageBox.Show("轉檔成功");
            //string format;
            //format = $"{Patient_Name}{Patient_ID}{Patient_Location}{Doctor_Name}{BUT}{Quantity}{Drug_Code}{Medicine_Name}{Admin_Time}{Start_Date}{Stop_Date}{Note}{Admin_Time_description}{Prescription_Number}{English_Patient_Name}{BirthDay}{Sex}{Room_Number}{Bed_Number}{UnitDose_State}{Hospital_Name}{Random_1}{Random_2}{Random_3}{Random_4}{Random_5}{Random_6}{Random_7}{Random_8}{Random_9}{Random_10}{Random_11}{Random_12}{Random_13}{Random_14}{Random_15}{Dose_Type}";
        }




        //這個是用字節去數個數

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


         
        public static string ECD(string chine, int Length)  //處理中文
        {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding big5 = Encoding.GetEncoding(950);

            string data = chine.PadRight(Length,' ');
            byte[] Temp = big5.GetBytes(data);
            return big5.GetString(Temp, 0, Length);
        }


        public static string covertToBig5(string str, int len)       //轉成big5
        {
            byte[] strBytes = Encoding.GetEncoding("950").GetBytes(str);
            string big5Str = Encoding.GetEncoding("950").GetString(strBytes, 0, len);
            return big5Str;
        }


    }
}
