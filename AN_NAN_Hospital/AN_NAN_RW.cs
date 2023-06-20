using CsvHelper;
using OnCube_Switch.Properties;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using static OnCube_Switch.AN_NAN_CSV_People;

namespace OnCube_Switch
{
    internal class AN_NAN_RW
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

        public string sourceFilePath = "";
        public void RW_file()   //讀取每個檔案資料  
        {
            DateTime now = DateTime.Now;

            string DateTimeString = now.ToString(("yyyy-MM-dd HHmmss"));

            string DateString = now.ToString("yyyyMMdd");

            string folderPath = $"{Settings.OutputPath}/{DateString}";  //輸出資料夾位置

            Operation_Folder ttttt = new Operation_Folder();

            string[] Folder_file = ttttt.Read_Folder();       //######################檔案位置陣列

            if (!Directory.Exists(folderPath))
            {
                // 創建新的資料夾
                Directory.CreateDirectory(folderPath);
            }

            string destinationFolderPath = $"{folderPath}";

            foreach (var v in Folder_file)   //##############################"依序"拿出一個檔案
            {

                sourceFilePath = $"{v}";

                List<Person_OC> people = new List<Person_OC>();   //創一個Oncube 成員類別串列 

                var encoding = CodePagesEncodingProvider.Instance.GetEncoding("big5")!;

                using var reader = new StreamReader(v, encoding);
                {
                    using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                    {
                        {
                            var records = csv.GetRecords<Entity>();    //#######這裡是用CsvHelper讀取後，放"安南"成員的地方  !!!!!!!!!



                            foreach (var An_nan in records)  //把一個文件中，每一行(即成員)依序個別拿出
                            {

                                /*

                                //過濾不設定的條件
                                if (An_nan.Qmedicine == "科學中藥" || !An_nan.Qusage.EndsWith('#') || (An_nan.Qway != "口服" && An_nan.Qway != "PO"))
                                {
                                    continue;
                                }

                                */


                                Person_OC preson = new Person_OC()    //創一個OnCube成員，並依序對應
                                {

                                    Patient_Name = An_nan.Name,

                                    Patient_ID = An_nan.PatientID.Replace(" ", ""),

                                    Patient_Location = An_nan.HospNo,

                                    Quantity = "1",

                                    Drug_Code = An_nan.DrugID,

                                    Medicine_Name = An_nan.Qmedicine,

                                    Admin_Time = "QD",

                                    Start_Date = "240605",             //An_nan.Qstartdate,

                                    Stop_Date = "240607",              //An_nan.Qenddate,

                                    BirthDay = "2023-06-05",

                                    Sex = "男",

                                    UnitDose_State = "0",

                                    Hospital_Name = "安南醫院",

                                    Dose_Type = "M"
                                };

                                //創建OnCube的一個類別
                                //把安南對應到OnCube的格子屬性區
                                people.Add(preson);  //加到people類別串列之中  (OnCube) 

                            }

                            Thread.Sleep(1000);  //暫停一下  不然每個txt檔案名稱都會一樣 因為我用時間來去定義名稱
                        }
                        PrintFormat_Output.An_nan_print(people);  //全部用完，用輸出的涵式去輸出
                    }

                }


                string destinationFilePath = Path.Combine(destinationFolderPath, Path.GetFileName(sourceFilePath));

                File.Move(sourceFilePath, destinationFilePath);
            }
        }
    }
}



