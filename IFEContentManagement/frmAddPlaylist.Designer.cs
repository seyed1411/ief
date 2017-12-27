namespace IFEContentManagement
{
    partial class frmAddPlaylist
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.btnBrowseDir = new System.Windows.Forms.Button();
            this.btnBrowseCov = new System.Windows.Forms.Button();
            this.txtCover = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.cmbAge = new System.Windows.Forms.ComboBox();
            this.lstGenres = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAdditionalExisted = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnNewLang = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Directory:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cover:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Year:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Age:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Genres:";
            // 
            // txtDirectory
            // 
            this.txtDirectory.Location = new System.Drawing.Point(70, 15);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.ReadOnly = true;
            this.txtDirectory.Size = new System.Drawing.Size(246, 20);
            this.txtDirectory.TabIndex = 5;
            // 
            // btnBrowseDir
            // 
            this.btnBrowseDir.Location = new System.Drawing.Point(322, 15);
            this.btnBrowseDir.Name = "btnBrowseDir";
            this.btnBrowseDir.Size = new System.Drawing.Size(75, 21);
            this.btnBrowseDir.TabIndex = 6;
            this.btnBrowseDir.Text = "Browse";
            this.btnBrowseDir.UseVisualStyleBackColor = true;
            this.btnBrowseDir.Click += new System.EventHandler(this.btnBrowseDir_Click);
            // 
            // btnBrowseCov
            // 
            this.btnBrowseCov.Location = new System.Drawing.Point(322, 42);
            this.btnBrowseCov.Name = "btnBrowseCov";
            this.btnBrowseCov.Size = new System.Drawing.Size(75, 21);
            this.btnBrowseCov.TabIndex = 8;
            this.btnBrowseCov.Text = "Browse";
            this.btnBrowseCov.UseVisualStyleBackColor = true;
            this.btnBrowseCov.Click += new System.EventHandler(this.btnBrowseCov_Click);
            // 
            // txtCover
            // 
            this.txtCover.Location = new System.Drawing.Point(70, 42);
            this.txtCover.Name = "txtCover";
            this.txtCover.ReadOnly = true;
            this.txtCover.Size = new System.Drawing.Size(246, 20);
            this.txtCover.TabIndex = 7;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(70, 71);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(327, 20);
            this.txtYear.TabIndex = 9;
            // 
            // cmbAge
            // 
            this.cmbAge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbAge.Items.AddRange(new object[] {
            "Under 13",
            "Between 13 and 17",
            "Above 18"});
            this.cmbAge.Location = new System.Drawing.Point(70, 100);
            this.cmbAge.Name = "cmbAge";
            this.cmbAge.Size = new System.Drawing.Size(327, 21);
            this.cmbAge.TabIndex = 10;
            // 
            // lstGenres
            // 
            this.lstGenres.FormattingEnabled = true;
            this.lstGenres.Items.AddRange(new object[] {
            "Country",
            "Pop",
            "Classic",
            "R & B",
            "Blues",
            "Relaxing",
            "Electral",
            "Jazz",
            "Comedy",
            "Rock",
            "Folk",
            "Hip-Hop"});
            this.lstGenres.Location = new System.Drawing.Point(70, 133);
            this.lstGenres.Name = "lstGenres";
            this.lstGenres.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstGenres.Size = new System.Drawing.Size(327, 173);
            this.lstGenres.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(10, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(388, 2);
            this.label6.TabIndex = 12;
            // 
            // lblAdditionalExisted
            // 
            this.lblAdditionalExisted.AutoSize = true;
            this.lblAdditionalExisted.Location = new System.Drawing.Point(12, 338);
            this.lblAdditionalExisted.Name = "lblAdditionalExisted";
            this.lblAdditionalExisted.Size = new System.Drawing.Size(191, 13);
            this.lblAdditionalExisted.TabIndex = 13;
            this.lblAdditionalExisted.Text = "No Additional Language Data Inserted.";
            this.lblAdditionalExisted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(10, 363);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(388, 2);
            this.label7.TabIndex = 14;
            // 
            // btnNewLang
            // 
            this.btnNewLang.Location = new System.Drawing.Point(209, 328);
            this.btnNewLang.Name = "btnNewLang";
            this.btnNewLang.Size = new System.Drawing.Size(188, 32);
            this.btnNewLang.TabIndex = 15;
            this.btnNewLang.Text = "New Language";
            this.btnNewLang.UseVisualStyleBackColor = true;
            this.btnNewLang.Click += new System.EventHandler(this.btnNewLang_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(209, 375);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(188, 32);
            this.btnInsert.TabIndex = 16;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(15, 375);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(188, 32);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAddPlaylist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 416);
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
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(425, 455);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(425, 455);
            this.Name = "frmAddPlaylist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Playlist";
            this.Load += new System.EventHandler(this.frmAddPlaylist_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Button btnBrowseDir;
        private System.Windows.Forms.Button btnBrowseCov;
        private System.Windows.Forms.TextBox txtCover;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.ComboBox cmbAge;
        private System.Windows.Forms.ListBox lstGenres;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAdditionalExisted;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnNewLang;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnCancel;
    }
}