namespace IFEContentManagement
{
    partial class frmAddMovie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddMovie));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnNewLang = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lstGenres = new System.Windows.Forms.ListBox();
            this.cmbAge = new System.Windows.Forms.ComboBox();
            this.txtDirector = new System.Windows.Forms.TextBox();
            this.btnBrowseCov = new System.Windows.Forms.Button();
            this.txtCover = new System.Windows.Forms.TextBox();
            this.btnBrowseDir = new System.Windows.Forms.Button();
            this.txtMovieFile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTrailerFie = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panelLangs = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(10, 562);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(193, 32);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(209, 562);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(189, 32);
            this.btnInsert.TabIndex = 34;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnNewLang
            // 
            this.btnNewLang.Location = new System.Drawing.Point(10, 519);
            this.btnNewLang.Name = "btnNewLang";
            this.btnNewLang.Size = new System.Drawing.Size(388, 32);
            this.btnNewLang.TabIndex = 33;
            this.btnNewLang.Text = "New Language";
            this.btnNewLang.UseVisualStyleBackColor = true;
            this.btnNewLang.Click += new System.EventHandler(this.btnNewLang_Click);
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(10, 556);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(388, 2);
            this.label7.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(10, 343);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(388, 2);
            this.label6.TabIndex = 30;
            // 
            // lstGenres
            // 
            this.lstGenres.FormattingEnabled = true;
            this.lstGenres.Items.AddRange(new object[] {
            "Action",
            "Adventure",
            "Animation",
            "Biography",
            "Comedy",
            "Crime\t",
            "Documentary",
            "Drama",
            "Family",
            "Fantasy",
            "Film-Noir\t Game-Show",
            "History",
            "Horror",
            "Music",
            "Musical",
            "Mystery\t",
            "News",
            "Reality-TV",
            "Romance",
            "Sci-Fi\t",
            "Sport",
            "Talk-Show",
            "Thriller",
            "War",
            "Western"});
            this.lstGenres.Location = new System.Drawing.Point(70, 158);
            this.lstGenres.Name = "lstGenres";
            this.lstGenres.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstGenres.Size = new System.Drawing.Size(327, 173);
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
            this.cmbAge.Location = new System.Drawing.Point(70, 125);
            this.cmbAge.Name = "cmbAge";
            this.cmbAge.Size = new System.Drawing.Size(327, 21);
            this.cmbAge.TabIndex = 28;
            // 
            // txtDirector
            // 
            this.txtDirector.Location = new System.Drawing.Point(70, 96);
            this.txtDirector.Name = "txtDirector";
            this.txtDirector.Size = new System.Drawing.Size(327, 20);
            this.txtDirector.TabIndex = 27;
            // 
            // btnBrowseCov
            // 
            this.btnBrowseCov.Location = new System.Drawing.Point(322, 67);
            this.btnBrowseCov.Name = "btnBrowseCov";
            this.btnBrowseCov.Size = new System.Drawing.Size(75, 21);
            this.btnBrowseCov.TabIndex = 26;
            this.btnBrowseCov.Text = "Browse";
            this.btnBrowseCov.UseVisualStyleBackColor = true;
            this.btnBrowseCov.Click += new System.EventHandler(this.btnBrowseCov_Click);
            // 
            // txtCover
            // 
            this.txtCover.Location = new System.Drawing.Point(70, 67);
            this.txtCover.Name = "txtCover";
            this.txtCover.ReadOnly = true;
            this.txtCover.Size = new System.Drawing.Size(246, 20);
            this.txtCover.TabIndex = 25;
            // 
            // btnBrowseDir
            // 
            this.btnBrowseDir.Location = new System.Drawing.Point(322, 15);
            this.btnBrowseDir.Name = "btnBrowseDir";
            this.btnBrowseDir.Size = new System.Drawing.Size(75, 21);
            this.btnBrowseDir.TabIndex = 24;
            this.btnBrowseDir.Text = "Browse";
            this.btnBrowseDir.UseVisualStyleBackColor = true;
            this.btnBrowseDir.Click += new System.EventHandler(this.btnBrowseDir_Click);
            // 
            // txtMovieFile
            // 
            this.txtMovieFile.Location = new System.Drawing.Point(70, 15);
            this.txtMovieFile.Name = "txtMovieFile";
            this.txtMovieFile.ReadOnly = true;
            this.txtMovieFile.Size = new System.Drawing.Size(246, 20);
            this.txtMovieFile.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Genres:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Age:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Director:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
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
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Video File:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(322, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 21);
            this.button1.TabIndex = 38;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtTrailerFie
            // 
            this.txtTrailerFie.Location = new System.Drawing.Point(70, 41);
            this.txtTrailerFie.Name = "txtTrailerFie";
            this.txtTrailerFie.ReadOnly = true;
            this.txtTrailerFie.Size = new System.Drawing.Size(246, 20);
            this.txtTrailerFie.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Trailer:";
            // 
            // panelLangs
            // 
            this.panelLangs.AutoScroll = true;
            this.panelLangs.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelLangs.Location = new System.Drawing.Point(70, 353);
            this.panelLangs.Name = "panelLangs";
            this.panelLangs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelLangs.Size = new System.Drawing.Size(327, 160);
            this.panelLangs.TabIndex = 39;
            this.panelLangs.WrapContents = false;
            // 
            // frmAddMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 606);
            this.Controls.Add(this.panelLangs);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTrailerFie);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnNewLang);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lstGenres);
            this.Controls.Add(this.cmbAge);
            this.Controls.Add(this.txtDirector);
            this.Controls.Add(this.btnBrowseCov);
            this.Controls.Add(this.txtCover);
            this.Controls.Add(this.btnBrowseDir);
            this.Controls.Add(this.txtMovieFile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(425, 645);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(425, 645);
            this.Name = "frmAddMovie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Movie";
            this.Load += new System.EventHandler(this.frmAddMovie_Load);
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
        private System.Windows.Forms.TextBox txtDirector;
        private System.Windows.Forms.Button btnBrowseCov;
        private System.Windows.Forms.TextBox txtCover;
        private System.Windows.Forms.Button btnBrowseDir;
        private System.Windows.Forms.TextBox txtMovieFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtTrailerFie;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FlowLayoutPanel panelLangs;
    }
}