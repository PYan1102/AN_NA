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

            SwitchButtonEnabelState(false);

        }
        private void Select_CSV_Folder_Click(object sender, EventArgs e)     //�I�����CSV�ɸ�Ƨ�
        {
            if (Folder_BrowserDialog.ShowDialog() == DialogResult.OK)  //����ܤF
            {


                TB_CSV.Text = Folder_BrowserDialog.SelectedPath;    //���ܸ��|��Text.box



                bool check = Directory.Exists(TB_CSV.Text);         //�T�{�O�_���ĸ��|

                if (!check)
                {
                    MessageBox.Show("�ЦA���T�{���|�O�_���T");
                    return;
                }
                else
                {
                    Settings.InputPath = TB_CSV.Text = Folder_BrowserDialog.SelectedPath;

                    Settings.Save();
                }


            }
        }

        private void Select_TXT_Folder_Click(object sender, EventArgs e)           //�I�����TXT�ɸ�Ƨ�
        {
            if (Folder_BrowserDialog.ShowDialog() == DialogResult.OK)  //����ܤF
            {

                TB_TXT.Text = Folder_BrowserDialog.SelectedPath;    //���ܸ��|��Text.box
                bool check = Directory.Exists(TB_TXT.Text);         //�T�{�O�_���ĸ��|
                if (!check)
                {
                    MessageBox.Show("�ЦA���T�{���|�O�_���T");
                    return;
                }
                else
                {
                    Settings.OutputPath = TB_TXT.Text = Folder_BrowserDialog.SelectedPath;


                    Settings.Save();
                }


            }
        }

        private void Select_Backup_Folder_Click(object sender, EventArgs e)
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


            STAR_Btn.Enabled = false;
            STAR_Btn.Text = "���bŪ��....";


            STAR_Btn.Enabled = true;
            STAR_Btn.Text = "�}�l";
        }

        public void ClearTB_CSV()
        {
            TB_CSV.Text = string.Empty;
        }

        private void SwitchButtonEnabelState(bool start)
        {
            STAR_Btn.Enabled = !start;
            STOP_Btn.Enabled = start;
        }

        private void STOP_Btn_Click(object sender, EventArgs e)
        {
            _csvProcess.Stop();
            SwitchButtonEnabelState(false);
        }
    }







}