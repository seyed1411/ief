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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnNewLang = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblAdditionalExisted = new System.Windows.Forms.Label();
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
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(25, 402);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(188, 32);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(219, 402);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(188, 32);
            this.btnInsert.TabIndex = 34;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnNewLang
            // 
            this.btnNewLang.Location = new System.Drawing.Point(219, 362);
            this.btnNewLang.Name = "btnNewLang";
            this.btnNewLang.Size = new System.Drawing.Size(188, 32);
            this.btnNewLang.TabIndex = 33;
            this.btnNewLang.Text = "New Language";
            this.btnNewLang.UseVisualStyleBackColor = true;
            this.btnNewLang.Click += new System.EventHandler(this.btnNewLang_Click);
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(20, 397);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(388, 2);
            this.label7.TabIndex = 32;
            // 
            // lblAdditionalExisted
            // 
            this.lblAdditionalExisted.AutoSize = true;
            this.lblAdditionalExisted.Location = new System.Drawing.Point(22, 372);
            this.lblAdditionalExisted.Name = "lblAdditionalExisted";
            this.lblAdditionalExisted.Size = new System.Drawing.Size(191, 13);
            this.lblAdditionalExisted.TabIndex = 31;
            this.lblAdditionalExisted.Text = "No Additional Language Data Inserted.";
            this.lblAdditionalExisted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(20, 358);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(388, 2);
            this.label6.TabIndex = 30;
            // 
            // lstGenres
            // 
            this.lstGenres.FormattingEnabled = true;
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
            this.lstGenres.Location = new System.Drawing.Point(76, 160);
            this.lstGenres.Name = "lstGenres";
            this.lstGenres.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstGenres.Size = new System.Drawing.Size(331, 186);
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
            this.cmbAge.Location = new System.Drawing.Point(76, 127);
            this.cmbAge.Name = "cmbAge";
            this.cmbAge.Size = new System.Drawing.Size(331, 21);
            this.cmbAge.TabIndex = 28;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(76, 70);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(331, 20);
            this.txtYear.TabIndex = 27;
            // 
            // btnBrowseCov
            // 
            this.btnBrowseCov.Location = new System.Drawing.Point(332, 41);
            this.btnBrowseCov.Name = "btnBrowseCov";
            this.btnBrowseCov.Size = new System.Drawing.Size(75, 21);
            this.btnBrowseCov.TabIndex = 26;
            this.btnBrowseCov.Text = "Browse";
            this.btnBrowseCov.UseVisualStyleBackColor = true;
            this.btnBrowseCov.Click += new System.EventHandler(this.btnBrowseCov_Click);
            // 
            // txtCover
            // 
            this.txtCover.Location = new System.Drawing.Point(76, 41);
            this.txtCover.Name = "txtCover";
            this.txtCover.ReadOnly = true;
            this.txtCover.Size = new System.Drawing.Size(250, 20);
            this.txtCover.TabIndex = 25;
            // 
            // btnBrowseDir
            // 
            this.btnBrowseDir.Location = new System.Drawing.Point(332, 14);
            this.btnBrowseDir.Name = "btnBrowseDir";
            this.btnBrowseDir.Size = new System.Drawing.Size(75, 21);
            this.btnBrowseDir.TabIndex = 24;
            this.btnBrowseDir.Text = "Browse";
            this.btnBrowseDir.UseVisualStyleBackColor = true;
            this.btnBrowseDir.Click += new System.EventHandler(this.btnBrowseDir_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(76, 14);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(250, 20);
            this.txtFile.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Genres:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Age:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Year:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Cover:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "File:";
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbLanguage.Items.AddRange(new object[] {
            ""});
            this.cmbLanguage.Location = new System.Drawing.Point(76, 98);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(331, 21);
            this.cmbLanguage.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Language:";
            // 
            // frmAddArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 446);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnNewLang);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblAdditionalExisted);
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
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(435, 485);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(435, 485);
            this.Name = "frmAddArticle";
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
        private System.Windows.Forms.Label lblAdditionalExisted;
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
    }
}