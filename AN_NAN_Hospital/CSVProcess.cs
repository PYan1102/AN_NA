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
         * 
         * 
         * １.拿取檔案資料夾讀好的陣列
         * ２.從陣列之中，用foreach依序拿走檔案位址
         * ３.設定輸出地點，由預設暫存內取得指定OutputPath                     Note:之後可能要設定多個命名方式，以防止覆蓋
         * ４.新增一個StreamReader，用來讀取檔案，並給予路徑
         * ５.新增一個CsvReader，用來分析StreamReader讀取的內容，且可以用來分析類別
         * ６.新增一個StreamWriter，用來寫入檔案，並給予路徑，且用Encoding.GetEncoding("ISO-8859-1")寫入成ANSI碼
         * ７.宣告一個records類別的"串列"，使用CsvReader讀取資料，並依序給資料至類別CSV_People之中的Entity
         * ８.宣告一個People_OC的類別"串列"，依序放置每一個個別讀取的類別
         * ９.在records串列之中，依序把每個類別拿出
         * １０.過濾需要過濾的條件，並跳過目前的類別，繼續執行串列之中下一個類別
         * １１.若不需要過濾，則新增一個OnCube_People類別，名稱為preson
         * １２.依序設定安南醫院需要對應至OnCube的資料，並加入至People_OC的類別串列內 
         * １３.從類別串列之中拿取每一個OnCube_People成員
         * １４.宣告一個string，用於放置這次使用的類別內的功能.PrintFormat()，回傳OnCube所需字串
         * １５.使用剛剛'６'宣告的寫入串流，把剛剛拿到的字串新增進去寫入一行
         * 
         * csv.GetRecords<Entity>();
         * 
         * 
         * 讀CSV之後，設定給CSV_People的屬性
         * 然後在新增一個CsvReader，用於讀取 CSV 檔案的資料行，
         * 

         */

        private CancellationTokenSource? _cts;

        public void Start()
        {
            _cts = new CancellationTokenSource();
            Task.Run(async () =>
            {
                while (!_cts.IsCancellationRequested)
                {
                    await Task.Delay(1000);

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

            try
            {
                Debug.WriteLine($"csv的數量:{Folder_file.Length}");
            }
            catch(Exception ex)
            {
                MessageBox.Show("問題是" + ex.Message);
            }

                if (!Directory.Exists(BU_folderPath))
            {
                // 沒有備份創建新的資料夾
                Directory.CreateDirectory(BU_folderPath);
            }
            foreach (var file in Folder_file)   //
            {

                var encoding = CodePagesEncodingProvider.Instance.GetEncoding("big5")!;

                try
                {
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
                            try
                            {
                                qty = Convert.ToSingle(Regex.Replace(record.Qusage, @"\#", ""));
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine("迴圈中斷: " + ex.Message);
                            }

                            string adminCode = Regex.Replace(record.Qmedfreq, @"[\/]", "");

                            OCS_Person preson = new OCS_Person()    //創一個OnCube成員，並依序對應
                            {
                                Patient_Name = record.Name,
                                Patient_ID = record.PatientID.Replace(" ", ""),
                                Patient_Location = "一般",
                                Quantity = qty,   //可能  Qty = qty,
                                Drug_Code = record.DrugID,
                                Medicine_Name = record.Qmedicine,
                                Admin_Time = "QD",           //adminCode,
                                StartDate = DateTimeConverter.ToDateTime(record.Qstartdate, "yyyy/M/d"),             //An_nan.Qstartdate,
                                StopDate = DateTimeConverter.ToDateTime(record.Qenddate, "yyyy/M/d"),               //An_nan.Qenddate,
                                BirthDate = new DateTime(2000, 1, 1),
                                Hospital_Name = "安南醫院",
                                Dose_Type = "M"
                            };

                            persons.Add(preson);  //加到people類別串列之中  (OnCube) 
                        }

                        try
                        {
                            FileOutput.An_nan_print(persons, Path.GetFileNameWithoutExtension(file));//全部用完，用輸出的涵式去輸出  
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("迴圈中斷: " + ex.Message);
                        }



                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("迴圈中斷: " + ex.Message);
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

            CK_fail();
        }

        private string[] GetFiles()     
        {
            string inPath = Settings.InputPath;      
            string[] files = Directory.GetFiles(inPath,"*.csv");   
            return files;
        }

        private void  CK_fail()
        {           
            string Fail_folderepath = $"{Settings.BackupPath}/fail";
            Debug.WriteLine($"fail資料夾路徑{Fail_folderepath}");
            Debug.WriteLine($"有沒有創建路徑{Directory.Exists(Fail_folderepath)}");
            if (!Directory.Exists(Fail_folderepath))
            {
                // 創建新的資料夾
                Directory.CreateDirectory(Fail_folderepath);
            }          
            string sourepath = Settings.InputPath;
            Debug.WriteLine($"{sourepath}");
            string[] Failfile = Directory.GetFiles(sourepath);
            int i = Failfile.Length;
            if (i != 0)
            {
                MessageBox.Show($"目前共有{i}個檔案失敗，已轉移至失敗資料夾");
                Debug.WriteLine($"陣列個數{i}");
                foreach (var f in Failfile)
                {
                    Debug.WriteLine($"每個檔案路徑{f}");
                    string FailfileName = Path.GetFileName(f);
                    string destinationFilePath = Path.Combine(Fail_folderepath, FailfileName);
                    Debug.WriteLine($"失敗存放位址{destinationFilePath}");
                    File.Move(f, destinationFilePath);
                }

            }
           
           
            
        }


    }

}
