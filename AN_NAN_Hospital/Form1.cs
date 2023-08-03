using System.Diagnostics;

namespace OnCube_Switch
{

    /// <summary>
    /// Window視窗
    /// </summary>
    public partial class Form1 : Form  //主程式區
    {
        /// <summary>
        /// 讀取類別
        /// </summary>
        CSVProcess _csvProcess = new CSVProcess();

        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 視窗啟動初始值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {

            TB_CSV.Text = Settings.InputPath;
            TB_TXT.Text = Settings.OutputPath;
            TB_BackupPath.Text = Settings.BackupPath;
            // this.TopMost = true;
            SwitchButtonEnabelState(false);        //按鈕切換
        }

        /// <summary>
        /// CSV檔案所在資料夾是否有選擇判定(按鈕)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Select_CSV_Folder_Click(object sender, EventArgs e)
        {
            if (Folder_BrowserDialog.ShowDialog() == DialogResult.OK)  //有選擇了
            {
                TB_CSV.Text = Folder_BrowserDialog.SelectedPath;    //把選擇路徑給Text.box
                Settings.InputPath = TB_CSV.Text = Folder_BrowserDialog.SelectedPath;
                Settings.Save();
            }
        }
        /// <summary>
        /// 指定TXT檔按所在資料夾是否有選擇判定(按鈕)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Select_TXT_Folder_Click(object sender, EventArgs e)
        {
            if (Folder_BrowserDialog.ShowDialog() == DialogResult.OK)  //有選擇了
            {
                TB_TXT.Text = Folder_BrowserDialog.SelectedPath;    //把選擇路徑給Text.box
                Settings.OutputPath = TB_TXT.Text = Folder_BrowserDialog.SelectedPath;
                Settings.Save();
            }
        }
        /// <summary>
        /// CSV檔讀取後指定位置備份資料夾是否有選擇判定(按鈕)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Select_Backup_Folder_Click(object sender, EventArgs e)         //點擊選擇csv檔備份資料夾
        {
            if (Folder_BrowserDialog.ShowDialog() == DialogResult.OK)  //有選擇了
            {
                TB_BackupPath.Text = Folder_BrowserDialog.SelectedPath;    //把選擇路徑給Text.box
                Settings.BackupPath = TB_BackupPath.Text = Folder_BrowserDialog.SelectedPath;
                Settings.Save();
            }
        }

        /// <summary>
        /// ###開始讀取按鈕###，主要讀取進入點("開始")
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void STAR_Btn_Click(object sender, EventArgs e)       //開始
        {
            try
            {
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

        /// <summary>
        /// 終止讀取按紐("終止")
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void STOP_Btn_Click(object sender, EventArgs e)
        {
            _csvProcess.Stop();
            SwitchButtonEnabelState(false);
        }
        /// <summary>
        /// 按鈕切換功能判別值
        /// </summary>
        /// <param name="start"></param>
        private void SwitchButtonEnabelState(bool start) //按鈕切換
        {
            STAR_Btn.Enabled = !start;
            STOP_Btn.Enabled = start;
        }

        /// <summary>
        /// 確認是否有選擇備份路徑，並跳出提示
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
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
        
        /// <summary>
        /// 測試用(待修改)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Compare_txt.Text = openFileDialog.FileName;
                Settings.CP_Path = Compare_txt.Text = openFileDialog.FileName;
                Settings.Save();
            }
        }
    }







}