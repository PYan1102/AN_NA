using System.Diagnostics;

namespace OnCube_Switch
{

    /// <summary>
    /// Window����
    /// </summary>
    public partial class Form1 : Form  //�D�{����
    {
        /// <summary>
        /// Ū�����O
        /// </summary>
        CSVProcess _csvProcess = new CSVProcess();

        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// �����Ұʪ�l��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {

            TB_CSV.Text = Settings.InputPath;
            TB_TXT.Text = Settings.OutputPath;
            TB_BackupPath.Text = Settings.BackupPath;
            // this.TopMost = true;
            SwitchButtonEnabelState(false);        //���s����
        }

        /// <summary>
        /// CSV�ɮשҦb��Ƨ��O�_����ܧP�w(���s)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Select_CSV_Folder_Click(object sender, EventArgs e)
        {
            if (Folder_BrowserDialog.ShowDialog() == DialogResult.OK)  //����ܤF
            {
                TB_CSV.Text = Folder_BrowserDialog.SelectedPath;    //���ܸ��|��Text.box
                Settings.InputPath = TB_CSV.Text = Folder_BrowserDialog.SelectedPath;
                Settings.Save();
            }
        }
        /// <summary>
        /// ���wTXT�ɫ��Ҧb��Ƨ��O�_����ܧP�w(���s)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Select_TXT_Folder_Click(object sender, EventArgs e)
        {
            if (Folder_BrowserDialog.ShowDialog() == DialogResult.OK)  //����ܤF
            {
                TB_TXT.Text = Folder_BrowserDialog.SelectedPath;    //���ܸ��|��Text.box
                Settings.OutputPath = TB_TXT.Text = Folder_BrowserDialog.SelectedPath;
                Settings.Save();
            }
        }
        /// <summary>
        /// CSV��Ū������w��m�ƥ���Ƨ��O�_����ܧP�w(���s)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Select_Backup_Folder_Click(object sender, EventArgs e)         //�I�����csv�ɳƥ���Ƨ�
        {
            if (Folder_BrowserDialog.ShowDialog() == DialogResult.OK)  //����ܤF
            {
                TB_BackupPath.Text = Folder_BrowserDialog.SelectedPath;    //���ܸ��|��Text.box
                Settings.BackupPath = TB_BackupPath.Text = Folder_BrowserDialog.SelectedPath;
                Settings.Save();
            }
        }

        /// <summary>
        /// ###�}�lŪ�����s###�A�D�nŪ���i�J�I("�}�l")
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void STAR_Btn_Click(object sender, EventArgs e)       //�}�l
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
                MessageBox.Show("�нT�{�ɮ׬O�_���b�Q�}�ҡA�t�εL�k�s��");
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
        /// �פ�Ū������("�פ�")
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void STOP_Btn_Click(object sender, EventArgs e)
        {
            _csvProcess.Stop();
            SwitchButtonEnabelState(false);
        }
        /// <summary>
        /// ���s�����\��P�O��
        /// </summary>
        /// <param name="start"></param>
        private void SwitchButtonEnabelState(bool start) //���s����
        {
            STAR_Btn.Enabled = !start;
            STOP_Btn.Enabled = start;
        }

        /// <summary>
        /// �T�{�O�_����ܳƥ����|�A�ø��X����
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private void CheckBackupFolderExists()
        {
            if (TB_BackupPath.Text.Length == 0)
            {
                throw new ArgumentNullException("�ƥ����|���i����");
            }
            if (!Directory.Exists(TB_BackupPath.Text))
            {
                Directory.CreateDirectory(TB_BackupPath.Text);
            }
        }
        
        /// <summary>
        /// ���ե�(�ݭק�)
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