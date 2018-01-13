namespace IFEContentManagement
{
    partial class frmExport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExport));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkLstLanguages = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCurrentLoc = new System.Windows.Forms.TextBox();
            this.btnBrowseDir = new System.Windows.Forms.Button();
            this.rdbChangeDir = new System.Windows.Forms.RadioButton();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.rdbUseCurrent = new System.Windows.Forms.RadioButton();
            this.lblSize = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnDeselectAll = new System.Windows.Forms.Button();
            this.btnSelectEn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelectEn);
            this.groupBox1.Controls.Add(this.btnDeselectAll);
            this.groupBox1.Controls.Add(this.btnSelectAll);
            this.groupBox1.Controls.Add(this.chkLstLanguages);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 214);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Languages";
            // 
            // chkLstLanguages
            // 
            this.chkLstLanguages.FormattingEnabled = true;
            this.chkLstLanguages.Location = new System.Drawing.Point(6, 23);
            this.chkLstLanguages.Name = "chkLstLanguages";
            this.chkLstLanguages.Size = new System.Drawing.Size(355, 184);
            this.chkLstLanguages.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCurrentLoc);
            this.groupBox2.Controls.Add(this.btnBrowseDir);
            this.groupBox2.Controls.Add(this.rdbChangeDir);
            this.groupBox2.Controls.Add(this.txtFile);
            this.groupBox2.Controls.Add(this.rdbUseCurrent);
            this.groupBox2.Location = new System.Drawing.Point(13, 234);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 134);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Export Directory";
            // 
            // txtCurrentLoc
            // 
            this.txtCurrentLoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCurrentLoc.Location = new System.Drawing.Point(25, 46);
            this.txtCurrentLoc.Name = "txtCurrentLoc";
            this.txtCurrentLoc.ReadOnly = true;
            this.txtCurrentLoc.Size = new System.Drawing.Size(336, 13);
            this.txtCurrentLoc.TabIndex = 28;
            // 
            // btnBrowseDir
            // 
            this.btnBrowseDir.Location = new System.Drawing.Point(367, 100);
            this.btnBrowseDir.Name = "btnBrowseDir";
            this.btnBrowseDir.Size = new System.Drawing.Size(75, 21);
            this.btnBrowseDir.TabIndex = 27;
            this.btnBrowseDir.Text = "Browse";
            this.btnBrowseDir.UseVisualStyleBackColor = true;
            this.btnBrowseDir.Click += new System.EventHandler(this.btnBrowseDir_Click);
            // 
            // rdbChangeDir
            // 
            this.rdbChangeDir.AutoSize = true;
            this.rdbChangeDir.Location = new System.Drawing.Point(6, 75);
            this.rdbChangeDir.Name = "rdbChangeDir";
            this.rdbChangeDir.Size = new System.Drawing.Size(162, 17);
            this.rdbChangeDir.TabIndex = 1;
            this.rdbChangeDir.TabStop = true;
            this.rdbChangeDir.Text = "Use Current Project Directory";
            this.rdbChangeDir.UseVisualStyleBackColor = true;
            this.rdbChangeDir.CheckedChanged += new System.EventHandler(this.rdbChangeDir_CheckedChanged);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(25, 100);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(336, 20);
            this.txtFile.TabIndex = 26;
            // 
            // rdbUseCurrent
            // 
            this.rdbUseCurrent.AutoSize = true;
            this.rdbUseCurrent.Location = new System.Drawing.Point(6, 23);
            this.rdbUseCurrent.Name = "rdbUseCurrent";
            this.rdbUseCurrent.Size = new System.Drawing.Size(162, 17);
            this.rdbUseCurrent.TabIndex = 0;
            this.rdbUseCurrent.TabStop = true;
            this.rdbUseCurrent.Text = "Use Current Project Directory";
            this.rdbUseCurrent.UseVisualStyleBackColor = true;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.ForeColor = System.Drawing.Color.Red;
            this.lblSize.Location = new System.Drawing.Point(13, 375);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(0, 13);
            this.lblSize.TabIndex = 2;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(336, 400);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(125, 30);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(367, 23);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 21);
            this.btnSelectAll.TabIndex = 29;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.Location = new System.Drawing.Point(367, 77);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(75, 21);
            this.btnDeselectAll.TabIndex = 30;
            this.btnDeselectAll.Text = "Deselect All";
            this.btnDeselectAll.UseVisualStyleBackColor = true;
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // btnSelectEn
            // 
            this.btnSelectEn.Location = new System.Drawing.Point(367, 50);
            this.btnSelectEn.Name = "btnSelectEn";
            this.btnSelectEn.Size = new System.Drawing.Size(75, 21);
            this.btnSelectEn.TabIndex = 31;
            this.btnSelectEn.Text = "Just English";
            this.btnSelectEn.UseVisualStyleBackColor = true;
            this.btnSelectEn.Click += new System.EventHandler(this.btnSelectEn_Click);
            // 
            // frmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 447);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(488, 486);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(488, 486);
            this.Name = "frmExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Project";
            this.Load += new System.EventHandler(this.frmExport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox chkLstLanguages;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbChangeDir;
        private System.Windows.Forms.RadioButton rdbUseCurrent;
        private System.Windows.Forms.Button btnBrowseDir;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.TextBox txtCurrentLoc;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSelectEn;
        private System.Windows.Forms.Button btnDeselectAll;
        private System.Windows.Forms.Button btnSelectAll;

    }
}