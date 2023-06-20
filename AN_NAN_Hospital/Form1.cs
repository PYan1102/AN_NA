using System.Diagnostics;

namespace OnCube_Switch
{
    public partial class Form1 : Form  //�D�{����
    {

        AN_NAN_RW Text_Csv = new AN_NAN_RW();  //�Э�Ū���Ϊ�

        public Form1()
        {

            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {


            TB_CSV.Text = Settings.InputPath;                    //�@�}�l�n�]�w�����|
            TB_TXT.Text = Settings.OutputPath;
            this.TopMost = true;

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

        private void STAR_Btn_Click(object sender, EventArgs e)       //�}�l
        {


            STAR_Btn.Enabled = false;

            try
            {
                Text_Csv.RW_file();

            }

            catch (IOException ex)
            {
                Debug.WriteLine(ex.ToString());
              //  MessageBox.Show("�нT�{�ɮ׬O�_���b�Q�}�ҡA�t�εL�k�s��");
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            STOP_Btn.Enabled = true;





        }



        private void STOP_Btn_Click(object sender, EventArgs e)      //����
        {

            STAR_Btn.Enabled = true;


            STOP_Btn.Enabled = false;






        }





        public void ClearTB_CSV()
        {
            TB_CSV.Text = string.Empty;
        }

    }







}