using System.Diagnostics;

namespace OnCube_Switch
{
    public partial class Form1 : Form  //主程式區
    {

        CSVProcess _csvProcess = new CSVProcess();  //創個讀取用的

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            TB_CSV.Text = Settings.InputPath;                    //一開始要設定的路徑
            TB_TXT.Text = Settings.OutputPath;
            TB_BackupPath.Text = Settings.BackupPath;
            this.TopMost = true;
            SwitchButtonEnabelState(false);        //按鈕切換
        }
        private void Select_CSV_Folder_Click(object sender, EventArgs e)     //點擊選擇CSV檔資料夾
        {
            if (Folder_BrowserDialog.ShowDialog() == DialogResult.OK)  //有選擇了
            {
                TB_CSV.Text = Folder_BrowserDialog.SelectedPath;    //把選擇路徑給Text.box
                Settings.InputPath = TB_CSV.Text = Folder_BrowserDialog.SelectedPath;
                Settings.Save();
            }
        }

        private void Select_TXT_Folder_Click(object sender, EventArgs e)           //點擊選擇TXT檔資料夾
        {
            if (Folder_BrowserDialog.ShowDialog() == DialogResult.OK)  //有選擇了
            {
                TB_TXT.Text = Folder_BrowserDialog.SelectedPath;    //把選擇路徑給Text.box
                Settings.OutputPath = TB_TXT.Text = Folder_BrowserDialog.SelectedPath;
                Settings.Save();
            }
        }

        private void Select_Backup_Folder_Click(object sender, EventArgs e)         //點擊選擇csv檔備份資料夾
        {
            if (Folder_BrowserDialog.ShowDialog() == DialogResult.OK)  //有選擇了
            {
                TB_BackupPath.Text = Folder_BrowserDialog.SelectedPath;    //把選擇路徑給Text.box
                Settings.BackupPath = TB_BackupPath.Text = Folder_BrowserDialog.SelectedPath;
                Settings.Save();
            }
        }


        private void STAR_Btn_Click(object sender, EventArgs e)       //開始
        {
            try
            {
                Console.WriteLine("HAHAHAHAHA");
                Debug.WriteLine("HAHA");
                CheckBackupFolderExists();
                _csvProcess.Start();
                SwitchButtonEnabelState(true);
            }
            catch (IOException ex)
            {
                Debug.WriteLine(ex.ToString());
                MessageBox.Show("請確認檔案是否正在被開啟，系統無法存取");
                STOP_Btn_Click(new object(), new EventArgs());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                STOP_Btn_Click(new object(), new EventArgs());
            }
        }
        private void STOP_Btn_Click(object sender, EventArgs e)
        {
            _csvProcess.Stop();
            SwitchButtonEnabelState(false);
        }



        private void SwitchButtonEnabelState(bool start) //按鈕切換
        {
            STAR_Btn.Enabled = !start;
            STOP_Btn.Enabled = start;
        }


        private void CheckBackupFolderExists()
        {
            if (TB_BackupPath.Text.Length == 0)
            {
                throw new ArgumentNullException("備份路徑不可為空");
            }
            if (!Directory.Exists(TB_BackupPath.Text))
            {
                Directory.CreateDirectory(TB_BackupPath.Text);
            }
        }


    }







}