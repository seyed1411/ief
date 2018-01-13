namespace IFEContentManagement
{
    partial class frmAddArticle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddArticle));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnNewLang = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lstGenres = new System.Windows.Forms.ListBox();
            this.cmbAge = new System.Windows.Forms.ComboBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.btnBrowseCov = new System.Windows.Forms.Button();
            this.txtCover = new System.Windows.Forms.TextBox();
            this.btnBrowseDir = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panelLangs = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(16, 698);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(248, 39);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(292, 698);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(251, 39);
            this.btnInsert.TabIndex = 34;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnNewLang
            // 
            this.btnNewLang.Location = new System.Drawing.Point(16, 649);
            this.btnNewLang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNewLang.Name = "btnNewLang";
            this.btnNewLang.Size = new System.Drawing.Size(527, 39);
            this.btnNewLang.TabIndex = 33;
            this.btnNewLang.Text = "New Language";
            this.btnNewLang.UseVisualStyleBackColor = true;
            this.btnNewLang.Click += new System.EventHandler(this.btnNewLang_Click);
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(19, 692);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(523, 2);
            this.label7.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(27, 385);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(517, 2);
            this.label6.TabIndex = 30;
            // 
            // lstGenres
            // 
            this.lstGenres.FormattingEnabled = true;
            this.lstGenres.ItemHeight = 16;
            this.lstGenres.Items.AddRange(new object[] {
            "Comedy",
            "Drama",
            "Epic",
            "Erotic",
            "Nonsense",
            "Lyric",
            "Mythopoeia",
            "Romance",
            "Satire",
            "Tragedy",
            "Tragicomedy"});
            this.lstGenres.Location = new System.Drawing.Point(101, 197);
            this.lstGenres.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstGenres.Name = "lstGenres";
            this.lstGenres.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstGenres.Size = new System.Drawing.Size(440, 180);
            this.lstGenres.TabIndex = 29;
            // 
            // cmbAge
            // 
            this.cmbAge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbAge.Items.AddRange(new object[] {
            "Under 13",
            "Between 13 and 17",
            "Above 18"});
            this.cmbAge.Location = new System.Drawing.Point(101, 156);
            this.cmbAge.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbAge.Name = "cmbAge";
            this.cmbAge.Size = new System.Drawing.Size(440, 25);
            this.cmbAge.TabIndex = 28;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(101, 86);
            this.txtYear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(440, 22);
            this.txtYear.TabIndex = 27;
            // 
            // btnBrowseCov
            // 
            this.btnBrowseCov.Location = new System.Drawing.Point(439, 48);
            this.btnBrowseCov.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrowseCov.Name = "btnBrowseCov";
            this.btnBrowseCov.Size = new System.Drawing.Size(100, 26);
            this.btnBrowseCov.TabIndex = 26;
            this.btnBrowseCov.Text = "Browse";
            this.btnBrowseCov.UseVisualStyleBackColor = true;
            this.btnBrowseCov.Click += new System.EventHandler(this.btnBrowseCov_Click);
            // 
            // txtCover
            // 
            this.txtCover.Location = new System.Drawing.Point(101, 50);
            this.txtCover.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCover.Name = "txtCover";
            this.txtCover.ReadOnly = true;
            this.txtCover.Size = new System.Drawing.Size(332, 22);
            this.txtCover.TabIndex = 25;
            // 
            // btnBrowseDir
            // 
            this.btnBrowseDir.Location = new System.Drawing.Point(439, 15);
            this.btnBrowseDir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrowseDir.Name = "btnBrowseDir";
            this.btnBrowseDir.Size = new System.Drawing.Size(100, 26);
            this.btnBrowseDir.TabIndex = 24;
            this.btnBrowseDir.Text = "Browse";
            this.btnBrowseDir.UseVisualStyleBackColor = true;
            this.btnBrowseDir.Click += new System.EventHandler(this.btnBrowseDir_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(101, 17);
            this.txtFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(332, 22);
            this.txtFile.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 198);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "Genres:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 161);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Age:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Year:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Cover:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "File:";
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbLanguage.Items.AddRange(new object[] {
            ""});
            this.cmbLanguage.Location = new System.Drawing.Point(101, 121);
            this.cmbLanguage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(440, 25);
            this.cmbLanguage.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 126);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 17);
            this.label8.TabIndex = 36;
            this.label8.Text = "Language:";
            // 
            // panelLangs
            // 
            this.panelLangs.AutoScroll = true;
            this.panelLangs.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelLangs.Location = new System.Drawing.Point(101, 394);
            this.panelLangs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelLangs.Name = "panelLangs";
            this.panelLangs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelLangs.Size = new System.Drawing.Size(440, 244);
            this.panelLangs.TabIndex = 38;
            this.panelLangs.WrapContents = false;
            // 
            // frmAddArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 748);
            this.Controls.Add(this.panelLangs);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnNewLang);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lstGenres);
            this.Controls.Add(this.cmbAge);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.btnBrowseCov);
            this.Controls.Add(this.txtCover);
            this.Controls.Add(this.btnBrowseDir);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(570, 795);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(570, 795);
            this.Name = "frmAddArticle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Article";
            this.Load += new System.EventHandler(this.frmAddArticle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnNewLang;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstGenres;
        private System.Windows.Forms.ComboBox cmbAge;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Button btnBrowseCov;
        private System.Windows.Forms.TextBox txtCover;
        private System.Windows.Forms.Button btnBrowseDir;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FlowLayoutPanel panelLangs;
    }
}