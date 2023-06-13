using static OnCube_Switch.Check_Content;
//using CsvHelper;

namespace OnCube_Switch
{
    internal class Operation_Folder
    {
        /*
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         */

       public string[] Read_Folder()       //讀取資料夾內檔案，並把每個檔案個路徑用array儲存
        {





            string Folder_In = Settings.InputPath;      //把讀取資料料夾給他
            string[] CSV_files = Directory.GetFiles(Folder_In, "*.csv");   //找所有的Csv檔案
            CsvfileCheck(CSV_files);
            return CSV_files;      
        }
    }
}


























    /*
    public void Save_data(List<string> x)
    {
        People_An_nan people_An_Nan = new People_An_nan();
        for (int i=0; i<=x.Count/23;i++)
        {
            switch (i)
            {
                case 0:
                    people_An_Nan.PatientID = data[i];
                    break;
                case 1:
                    people_An_Nan.Name = data[i];
                    break;
                case 2:
                    people_An_Nan.HospNoDisplay = data[i];
                    break;
                case 3:
                    people_An_Nan.HospNo = data[i];
                    break;
                case 4:
                    people_An_Nan.Date = data[i];
                    break;
                case 5:
                    people_An_Nan.DrugID = data[i];
                    break;
                case 6:
                    people_An_Nan.Qmedicine= data[i];
                    break;
                case 7:
                    people_An_Nan.Qsource= data[i];
                    break;
                case 8:
                    people_An_Nan.Qeffect = data[i];    
                    break;
                case 9:
                    people_An_Nan.Qusage= data[i];
                    break;
                case 10:
                    people_An_Nan.Qdose= data[i];
                    break;
                case 11:
                    people_An_Nan.Qdoseq = data[i];
                    break;

                case 12:
                    people_An_Nan.Qway= data[i];
                    break;
                case 13:
                    people_An_Nan.Qmedtime= data[i];
                    break;
                case 14:
                    people_An_Nan.Qmedday= data[i];
                    break;
                case 15:
                    people_An_Nan.Qfreq= data[i];
                    break;
                case 16:
                    people_An_Nan.Qmedfreq= data[i];
                    break;
                case 17:
                    people_An_Nan.Qstartdate= data[i];
                    break;
                case 18:
                    people_An_Nan.Qenddate= data[i];
                    break;
                case 19:
                    people_An_Nan.Qtype= data[i];
                    break;
                case 20:
                    people_An_Nan.Qtypea= data[i];
                    break;
                case 21:
                    people_An_Nan.Order= data[i];
                    break;
                case 22:
                    people_An_Nan.Qfiller= data[i];
                    break;







                    // 可以根據需要添加更多的屬性設定
            }
        }


    }    */



/*
                    for (int i = 0; i <= data.Count ; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                preson.PatientID = data[i];
                                break;
                            case 1:
                                preson.Name = data[i];
                                break;
                            case 2:
                                preson.HospNoDisplay = data[i];
                                break;
                            case 3:
                                preson.HospNo = data[i];
                                break;
                            case 4:
                                preson.Date = data[i];
                                break;
                            case 5:
                                preson.DrugID = data[i];
                                break;
                            case 6:
                                preson.Qmedicine = data[i];
                                break;
                            case 7:
                                preson.Qsource = data[i];
                                break;
                            case 8:
                                preson.Qeffect = data[i];
                                break;
                            case 9:
                                preson.Qusage = data[i];
                                break;
                            case 10:
                                preson.Qdose = data[i];
                                break;
                            case 11:
                                preson.Qdoseq = data[i];
                                break;

                            case 12:
                                preson.Qway = data[i];
                                break;
                            case 13:
                                preson.Qmedtime = data[i];
                                break;
                            case 14:
                                preson.Qmedday = data[i];
                                break;
                            case 15:
                                preson.Qfreq = data[i];
                                break;
                            case 16:
                                preson.Qmedfreq = data[i];
                                break;
                            case 17:
                                preson.Qstartdate = data[i];
                                break;
                            case 18:
                                preson.Qenddate = data[i];
                                break;
                            case 19:
                                preson.Qtype = data[i];
                                break;
                            case 20:
                                preson.Qtypea = data[i];
                                break;
                            case 21:
                                preson.Order = data[i];
                                break;
                            case 22:
                                preson.Qfiller = data[i];
                                break;

                                // 可以根據需要添加更多的屬性設定
                        }*/

