namespace OnCube_Switch
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TB_CSV = new TextBox();
            Select_CSV_Folder = new Button();
            label1 = new Label();
            label2 = new Label();
            TB_TXT = new TextBox();
            Select_TXT_Folder = new Button();
            STAR_Btn = new Button();
            Folder_BrowserDialog = new FolderBrowserDialog();
            label3 = new Label();
            label4 = new Label();
            TB_BackupPath = new TextBox();
            Select_Backup_Folder = new Button();
            STOP_Btn = new Button();
            SuspendLayout();
            // 
            // TB_CSV
            // 
            TB_CSV.Location = new Point(270, 87);
            TB_CSV.Margin = new Padding(4);
            TB_CSV.Name = "TB_CSV";
            TB_CSV.Size = new Size(482, 26);
            TB_CSV.TabIndex = 0;
            // 
            // Select_CSV_Folder
            // 
            Select_CSV_Folder.Font = new Font("Microsoft JhengHei UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            Select_CSV_Folder.Location = new Point(762, 48);
            Select_CSV_Folder.Margin = new Padding(4);
            Select_CSV_Folder.Name = "Select_CSV_Folder";
            Select_CSV_Folder.Size = new Size(214, 92);
            Select_CSV_Folder.TabIndex = 1;
            Select_CSV_Folder.Text = "選擇CSV資料夾";
            Select_CSV_Folder.UseVisualStyleBackColor = true;
            Select_CSV_Folder.Click += Select_CSV_Folder_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 66);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(259, 50);
            label1.TabIndex = 2;
            label1.Text = "輸入CSV路徑";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(3, 180);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(251, 50);
            label2.TabIndex = 3;
            label2.Text = "輸出TXT路徑";
            // 
            // TB_TXT
            // 
            TB_TXT.Location = new Point(270, 201);
            TB_TXT.Margin = new Padding(4);
            TB_TXT.Name = "TB_TXT";
            TB_TXT.Size = new Size(482, 26);
            TB_TXT.TabIndex = 4;
            // 
            // Select_TXT_Folder
            // 
            Select_TXT_Folder.Font = new Font("Microsoft JhengHei UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            Select_TXT_Folder.Location = new Point(762, 159);
            Select_TXT_Folder.Margin = new Padding(4);
            Select_TXT_Folder.Name = "Select_TXT_Folder";
            Select_TXT_Folder.Size = new Size(214, 99);
            Select_TXT_Folder.TabIndex = 5;
            Select_TXT_Folder.Text = "選擇TXT資料夾";
            Select_TXT_Folder.UseVisualStyleBackColor = true;
            Select_TXT_Folder.Click += Select_TXT_Folder_Click;
            // 
            // STAR_Btn
            // 
            STAR_Btn.Font = new Font("Microsoft JhengHei UI", 100F, FontStyle.Regular, GraphicsUnit.Point);
            STAR_Btn.Location = new Point(50, 394);
            STAR_Btn.Margin = new Padding(4);
            STAR_Btn.Name = "STAR_Btn";
            STAR_Btn.Size = new Size(451, 206);
            STAR_Btn.TabIndex = 6;
            STAR_Btn.Text = "開始";
            STAR_Btn.UseVisualStyleBackColor = true;
            STAR_Btn.Click += STAR_Btn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(364, 9);
            label3.Name = "label3";
            label3.Size = new Size(339, 35);
            label3.TabIndex = 8;
            label3.Text = "請確認資料夾路徑是否正確";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft JhengHei UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(72, 288);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(182, 50);
            label4.TabIndex = 9;
            label4.Text = "備份路徑";
            // 
            // TB_BackupPath
            // 
            TB_BackupPath.Location = new Point(270, 309);
            TB_BackupPath.Margin = new Padding(4);
            TB_BackupPath.Name = "TB_BackupPath";
            TB_BackupPath.Size = new Size(482, 26);
            TB_BackupPath.TabIndex = 10;
            // 
            // Select_Backup_Folder
            // 
            Select_Backup_Folder.Font = new Font("Microsoft JhengHei UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            Select_Backup_Folder.Location = new Point(762, 267);
            Select_Backup_Folder.Margin = new Padding(4);
            Select_Backup_Folder.Name = "Select_Backup_Folder";
            Select_Backup_Folder.Size = new Size(214, 99);
            Select_Backup_Folder.TabIndex = 11;
            Select_Backup_Folder.Text = "選擇備份資料夾";
            Select_Backup_Folder.UseVisualStyleBackColor = true;
            Select_Backup_Folder.Click += Select_Backup_Folder_Click;
            // 
            // STOP_Btn
            // 
            STOP_Btn.Enabled = false;
            STOP_Btn.Font = new Font("Microsoft JhengHei UI", 100F, FontStyle.Regular, GraphicsUnit.Point);
            STOP_Btn.Location = new Point(552, 394);
            STOP_Btn.Margin = new Padding(4);
            STOP_Btn.Name = "STOP_Btn";
            STOP_Btn.Size = new Size(451, 206);
            STOP_Btn.TabIndex = 12;
            STOP_Btn.Text = "停止";
            STOP_Btn.UseVisualStyleBackColor = true;
            STOP_Btn.Click += STOP_Btn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 626);
            Controls.Add(STOP_Btn);
            Controls.Add(Select_Backup_Folder);
            Controls.Add(TB_BackupPath);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(STAR_Btn);
            Controls.Add(Select_TXT_Folder);
            Controls.Add(TB_TXT);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Select_CSV_Folder);
            Controls.Add(TB_CSV);
            Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "安南醫院OnCube轉檔程式";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TB_CSV;
        private Button Select_CSV_Folder;
        private Label label1;
        private Label label2;
        private TextBox TB_TXT;
        private Button Select_TXT_Folder;
        private Button STAR_Btn;
        private FolderBrowserDialog Folder_BrowserDialog;
        private Label label3;
        private Label label4;
        private TextBox TB_BackupPath;
        private Button Select_Backup_Folder;
        private Button STOP_Btn;
    }
}