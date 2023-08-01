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

        /// <summary>
        /// 開始
        /// </summary>
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

        /// <summary>
        /// 停止程序
        /// </summary>
        public void Stop()
        {
          _cts?.Cancel();
        }

        /// <summary>
        /// 處理CSV檔案
        /// </summary>
        private  void ProcessFile()   
        {
            string[] Folder_file = GetFiles();     //檔案位置陣列                      
            foreach (var file in Folder_file)   
            {
                try
                {
                    var encoding = CodePagesEncodingProvider.Instance.GetEncoding("big5")!;
                    //這裡要用{}包起來  不然移動檔案時會卡到process的使用
                    using (StreamReader sr = new StreamReader(file, encoding))
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
                                        Admin_Time = adminCode,           //adminCode,(因為有些沒定義，先用QD代替，之後需要再OnCube定義)
                                        StartDate = DateTimeConverter.ToDateTime(record.Qstartdate, "yyyy/M/d"),
                                        StopDate = DateTimeConverter.ToDateTime(record.Qenddate, "yyyy/M/d"),
                                        BirthDate = new DateTime(2000, 1, 1),
                                        Hospital_Name = "安南醫院",
                                        Dose_Type = "M"
                                 };
                                 persons.Add(preson);  //加到people類別串列之中  (OnCube)                          
                            }
                            FileOutput.An_nan_print(persons, Path.GetFileNameWithoutExtension(file));//全部用完，用輸出的涵式去輸出                                                                              
                    }
                    MoveSuccessFile(file);
                }
                catch(Exception ex)
                {
                    Debug.WriteLine("讀檔失敗: " + ex.Message);
                    MoveFailFile(file);
                }                                                        
            }
            CK_fail();  //最後看所有Input資料夾之中有沒有檔案
        }


        /// <summary>
        /// 取得資料夾內CSV的檔案，存成字串陣列回傳
        /// </summary>
        /// <returns></returns>
        private string[] GetFiles()     
        {
            string inPath = Settings.InputPath;      
            string[] files = Directory.GetFiles(inPath,"*.csv");   
            return files;
        }

        /// <summary>
        /// 取得資料夾內所有類型檔案，並移動到失敗資料夾
        /// </summary>
        private void  CK_fail()
        {
            string sourepath = Settings.InputPath;
            string[] Failfile = Directory.GetFiles(sourepath);
            int i = Failfile.Length;
            if (i != 0)
            {
                MessageBox.Show($"目前共有{i}個檔案失敗，已轉移至失敗資料夾");
                foreach (var f in Failfile)
                {
                    MoveFailFile(f);
                }
            }
        }

        /// <summary>
        /// 成功檔案移動，引數Csv資料位址
        /// </summary>
        /// <param name="filepath"></param>
        private void MoveSuccessFile(string filepath) 
        {
            DateTime now = DateTime.Now;
            string DateString = now.ToString("yyyyMMdd");
            string BU_folderPath = $"{Settings.BackupPath}\\{DateString}";
            if (!Directory.Exists(BU_folderPath))
            {
                // 沒有備份創建新的資料夾
                Directory.CreateDirectory(BU_folderPath);
            }
            string destinationFilePath = Path.Combine(BU_folderPath, Path.GetFileName(filepath));
            File.Move(filepath, destinationFilePath);
        }

        /// <summary>
        /// 失敗檔案移動，引數Csv資料位址
        /// </summary>
        /// <param name="filepath"></param>
        private void MoveFailFile(string filepath) 
        {
            DateTime now = DateTime.Now;
            string DateString = now.ToString("yyyyMMdd");
            string Fail_folderepath = $"{Settings.BackupPath}/fail/{DateString}";
            if (!Directory.Exists(Fail_folderepath))
            {
                // 創建新的資料夾
                Directory.CreateDirectory(Fail_folderepath);
            }

            string FailfileName = Path.GetFileName(filepath);
            string destinationFilePath = Path.Combine(Fail_folderepath, FailfileName);
            File.Move(filepath, destinationFilePath);
        }

    }
}
