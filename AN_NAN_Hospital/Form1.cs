using System.Diagnostics;

namespace OnCube_Switch
{
    public partial class Form1 : Form  //�D�{����
    {

        CSVProcess _csvProcess = new CSVProcess();  //�Э�Ū���Ϊ�

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            TB_CSV.Text = Settings.InputPath;                    //�@�}�l�n�]�w�����|
            TB_TXT.Text = Settings.OutputPath;
            TB_BackupPath.Text = Settings.BackupPath;
            this.TopMost = true;
            SwitchButtonEnabelState(false);        //���s����
        }
        private void Select_CSV_Folder_Click(object sender, EventArgs e)     //�I�����CSV�ɸ�Ƨ�
        {
            if (Folder_BrowserDialog.ShowDialog() == DialogResult.OK)  //����ܤF
            {
                TB_CSV.Text = Folder_BrowserDialog.SelectedPath;    //���ܸ��|��Text.box
                Settings.InputPath = TB_CSV.Text = Folder_BrowserDialog.SelectedPath;
                Settings.Save();
            }
        }

        private void Select_TXT_Folder_Click(object sender, EventArgs e)           //�I�����TXT�ɸ�Ƨ�
        {
            if (Folder_BrowserDialog.ShowDialog() == DialogResult.OK)  //����ܤF
            {
                TB_TXT.Text = Folder_BrowserDialog.SelectedPath;    //���ܸ��|��Text.box
                Settings.OutputPath = TB_TXT.Text = Folder_BrowserDialog.SelectedPath;
                Settings.Save();
            }
        }

        private void Select_Backup_Folder_Click(object sender, EventArgs e)         //�I�����csv�ɳƥ���Ƨ�
        {
            if (Folder_BrowserDialog.ShowDialog() == DialogResult.OK)  //����ܤF
            {
                TB_BackupPath.Text = Folder_BrowserDialog.SelectedPath;    //���ܸ��|��Text.box
                Settings.BackupPath = TB_BackupPath.Text = Folder_BrowserDialog.SelectedPath;
                Settings.Save();
            }
        }


        private void STAR_Btn_Click(object sender, EventArgs e)       //�}�l
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
        private void STOP_Btn_Click(object sender, EventArgs e)
        {
            _csvProcess.Stop();
            SwitchButtonEnabelState(false);
        }



        private void SwitchButtonEnabelState(bool start) //���s����
        {
            STAR_Btn.Enabled = !start;
            STOP_Btn.Enabled = start;
        }


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


    }







}