using CsvHelper;
using OnCube_Switch.Properties;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using OnCube_Switch.Models;
using OnCube_Switch.Converters;
using System.Text.RegularExpressions;

namespace OnCube_Switch
{
    internal class CSVProcess
    {
        /*
         * 主要"安南醫院"讀取和寫入邏輯在這裡      
         */
        private CancellationTokenSource? _cts;
        public void Start()
        {
            _cts = new CancellationTokenSource();
            Task.Run(async () =>
            {
                while (!_cts.IsCancellationRequested)
                {
                    await Task.Delay(500);
                    ProcessFile();                    
                }
                _cts = null;              
            });
        }
        public void Stop()
        {
          _cts?.Cancel();
        }
        private  void ProcessFile()   
        {
            DateTime now = DateTime.Now;
            string DateString = now.ToString("yyyyMMdd");
            string BU_folderPath = $"{Settings.BackupPath}\\{DateString}";  //輸出備份資料夾位置(當天時間)         
            string[] Folder_file = GetFiles();     //檔案位置陣列           
                if (!Directory.Exists(BU_folderPath))
            {
                // 沒有備份創建新的資料夾
                Directory.CreateDirectory(BU_folderPath);
            }
            foreach (var file in Folder_file)   //
            {
                var encoding = CodePagesEncodingProvider.Instance.GetEncoding("big5")!;
                //這裡要用{}包起來  不然移動檔案時會卡到process的使用
                using (StreamReader sr = new StreamReader(file, encoding))
                {
                    try
                    {
                        using var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
                        var records = csv.GetRecords<CSVColumn>();    //用CsvHelper
                        List<OCS_Person> persons = new List<OCS_Person>();   //創一個Oncube 成員類別串列 
                        foreach (var record in records)  //把一個文件中，每一行(即成員)依序個別拿出
                        {
                            //過濾不設定的條件
                            if (record.Qmedicine == "科學中藥" || !record.Qusage.EndsWith('#') || (record.Qway != "口服" && record.Qway != "PO"))
                            {
                                continue;
                            }
                            try
                            {
                                float qty = 0;

                                qty = Convert.ToSingle(Regex.Replace(record.Qusage, @"\#", ""));  //正規表示式 (替換用)
                                string adminCode = Regex.Replace(record.Qmedfreq, @"[\/]", "");   ////正規表示式  (替換用)
                                OCS_Person preson = new OCS_Person()
                                {
                                    Patient_Name = record.Name,
                                    Patient_ID = record.PatientID.Replace(" ", ""),
                                    Patient_Location = "一般",
                                    Quantity = qty,
                                    Drug_Code = record.DrugID,
                                    Medicine_Name = record.Qmedicine,
                                    Admin_Time = "QD",           //adminCode,(因為有些沒定義，先用QD代替，之後需要再OnCube定義)
                                    StartDate = DateTimeConverter.ToDateTime(record.Qstartdate, "yyyy/M/d"),
                                    StopDate = DateTimeConverter.ToDateTime(record.Qenddate, "yyyy/M/d"),
                                    BirthDate = new DateTime(2000, 1, 1),
                                    Hospital_Name = "安南醫院",
                                    Dose_Type = "M"
                                };
                                persons.Add(preson);  //加到people類別串列之中  (OnCube) 





                            }
                            catch (Exception ex)
                            {                              
                                Debug.WriteLine(file);
                                Debug.WriteLine(ex.ToString());
                            }
                        }
                        FileOutput.An_nan_print(persons, Path.GetFileNameWithoutExtension(file));//全部用完，用輸出的涵式去輸出  
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(file);                     
                        Debug.WriteLine("讀檔block");
                        Debug.WriteLine(ex);
                        
                    }


                }
         
                string destinationFilePath = Path.Combine(BU_folderPath, Path.GetFileName(file));
                
                try
                {
                    File.Move(file, destinationFilePath);
                }
                catch (Exception ex)
                {

                    File.Move(file, destinationFilePath);
                    Debug.WriteLine("迴圈中斷: " + ex.Message);
                }

                Debug.WriteLine($"每個檔案路徑{destinationFilePath}");
                
            }
            CK_fail();  //最後看所有Input資料夾之中有沒有檔案
        }

        private string[] GetFiles()     //取得資料夾內CSV的檔案，存成字串陣列回傳
        {
            string inPath = Settings.InputPath;      
            string[] files = Directory.GetFiles(inPath,"*.csv");   
            return files;
        }

        private void  CK_fail() //取得資料夾內所有類型檔案，並移動到失敗資料夾
        {           
            string Fail_folderepath = $"{Settings.BackupPath}/fail";      
            if (!Directory.Exists(Fail_folderepath))
            {
                // 創建新的資料夾
                Directory.CreateDirectory(Fail_folderepath);
            }          
            string sourepath = Settings.InputPath;
            string[] Failfile = Directory.GetFiles(sourepath);
            int i = Failfile.Length;
            if (i != 0)
            {
                MessageBox.Show($"目前共有{i}個檔案失敗，已轉移至失敗資料夾");
                foreach (var f in Failfile)
                {
                    string FailfileName = Path.GetFileName(f);
                    string destinationFilePath = Path.Combine(Fail_folderepath, FailfileName);
                    File.Move(f, destinationFilePath);
                }
            }
        }

    }
}
