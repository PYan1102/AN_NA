using CsvHelper.Configuration.Attributes;

namespace OnCube_Switch.Models
{


    /// <summary>
    /// 放安南醫院給的CSV檔案欄位
    /// 主要給Text_conbine 用的Entity
    /// 串流讀一讀，用CsvHelper去分類這樣
    /// 用index去分別要存在哪一個成員
    /// </summary>
    internal class CSVColumn
    {
        

        private string patient_id = "";
        [Index(0)]
        public string PatientID        //"A"
        {
            get { return patient_id; }
            set { patient_id = value.Trim(); }
        }                                        

        private string name = "";
        [Index(1)]
        public string Name             //"B"
        {
            get { return name; }
            set { name = value.Trim(); }
        }

        private string hospnodisplay = "";
        [Index(2)]
        public string HospNoDisplay    //"C" 
        {
            get { return hospnodisplay; }
            set { hospnodisplay = value.Trim(); }
        }

        private string hospno = "";
        [Index(3)]
        public string HospNo          //"D"
        {
            get { return hospno; }
            set { hospno = value.Trim(); }
        }

        private string date = "";
        [Index(4)]
        public string Date            //"E"
        {
            get { return date; }           set { date = value.Trim(); }
        }

        private string drugid = "";
        [Index(5)]
        public string DrugID          //"F"
        {
            get { return drugid; }          set { drugid = value.Trim(); }
        }

        private string qmedicine = "";
        [Index(6)]
        public string Qmedicine       //"G"
        {
            get { return qmedicine; }
            set { qmedicine = value.Trim(); }
        }

        private string qsource = "";
        [Index(7)]
        public string Qsource         //"H"
        {
            get { return qsource; }
            set { qsource = value.Trim(); }
        }

        private string qeffect = "";
        [Index(8)]
        public string Qeffect         //"I"
        {
            get { return qeffect; }
            set { qeffect = value.Trim(); }
        }

        private string qusage = "";
        [Index(9)]
        public string Qusage          //"J"
        {
            get { return qusage; }
            set { qusage = value.Trim(); }
        }

        private string qdose = "";
        [Index(10)]
        public string Qdose          //"K"
        {
            get { return qdose; }
            set { qdose = value.Trim(); }
        }

        private string qdoseq = "";
        [Index(11)]
        public string Qdoseq         //"L"
        {
            get { return qdoseq; }
            set { qdoseq = value.Trim(); }
        }

        private string qway = "";
        [Index(12)]
        public string Qway            //"M"
        {
            get { return qway; }
            set { qway = value.Trim(); }
        }

        private string qmedtime = "";
        [Index(13)]
        public string Qmedtime        //"N"
        {
            get { return qmedtime; }
            set { qmedtime = value.Trim(); }
        }

        private string qmedday = "";
        [Index(14)]
        public string Qmedday         //"O"
        {
            get { return qmedday; }
            set { qmedday = value.Trim(); }
        }

        private string qfreq = "";
        [Index(15)]
        public string Qfreq           //"P"
        {
            get { return qfreq; }
            set { qfreq = value.Trim(); }
        }

        private string qmedfreq = "";
        [Index(16)]
        public string Qmedfreq        //"Q"
        {
            get { return qmedfreq; }
            set { qmedfreq = value.Trim(); }
        }

        private string qstardate = "";
        [Index(17)]
        public string Qstartdate      //"R"
        {
            get { return qstardate; }
            set { qstardate = value.Trim(); }
        }

        private string qenddate = "";
        [Index(18)]
        public string Qenddate        //"S"
        {
            get { return qenddate; }
            set { qenddate = value.Trim(); }        //藥品結束日期用/換成-
        }

        private string qtype = "";
        [Index(19)]
        public string Qtype           //"T"
        {
            get { return qtype; }
            set { qtype = value.Trim(); }
        }
        private string qtypea = "";
        [Index(20)]
        public string Qtypea          //"U"
        {
            get { return qtypea; }
            set { qtypea = value.Trim(); }
        }
        private string order = "";
        [Index(21)]
        public string Order           //"V"
        {
            get { return order; }
            set { order = value.Trim(); }
        }
        private string qfiller = "";
        [Index(22)]                                                //第23行
        public string Qfiller         //"W"
        {
            get { return qfiller; }
            set { qfiller = value.Trim(); }
        }
    }
}
