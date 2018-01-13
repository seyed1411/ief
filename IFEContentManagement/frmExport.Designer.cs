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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkLstLanguages);
            this.groupBox1.Location = new System.Drawing.Point(17, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(597, 263);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Languages";
            // 
            // chkLstLanguages
            // 
            this.chkLstLanguages.FormattingEnabled = true;
            this.chkLstLanguages.Location = new System.Drawing.Point(8, 28);
            this.chkLstLanguages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkLstLanguages.Name = "chkLstLanguages";
            this.chkLstLanguages.Size = new System.Drawing.Size(580, 225);
            this.chkLstLanguages.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCurrentLoc);
            this.groupBox2.Controls.Add(this.btnBrowseDir);
            this.groupBox2.Controls.Add(this.rdbChangeDir);
            this.groupBox2.Controls.Add(this.txtFile);
            this.groupBox2.Controls.Add(this.rdbUseCurrent);
            this.groupBox2.Location = new System.Drawing.Point(17, 288);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(597, 165);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Export Directory";
            // 
            // txtCurrentLoc
            // 
            this.txtCurrentLoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCurrentLoc.Location = new System.Drawing.Point(33, 57);
            this.txtCurrentLoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCurrentLoc.Name = "txtCurrentLoc";
            this.txtCurrentLoc.ReadOnly = true;
            this.txtCurrentLoc.Size = new System.Drawing.Size(448, 15);
            this.txtCurrentLoc.TabIndex = 28;
            // 
            // btnBrowseDir
            // 
            this.btnBrowseDir.Location = new System.Drawing.Point(489, 123);
            this.btnBrowseDir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrowseDir.Name = "btnBrowseDir";
            this.btnBrowseDir.Size = new System.Drawing.Size(100, 26);
            this.btnBrowseDir.TabIndex = 27;
            this.btnBrowseDir.Text = "Browse";
            this.btnBrowseDir.UseVisualStyleBackColor = true;
            this.btnBrowseDir.Click += new System.EventHandler(this.btnBrowseDir_Click);
            // 
            // rdbChangeDir
            // 
            this.rdbChangeDir.AutoSize = true;
            this.rdbChangeDir.Location = new System.Drawing.Point(8, 92);
            this.rdbChangeDir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbChangeDir.Name = "rdbChangeDir";
            this.rdbChangeDir.Size = new System.Drawing.Size(214, 21);
            this.rdbChangeDir.TabIndex = 1;
            this.rdbChangeDir.TabStop = true;
            this.rdbChangeDir.Text = "Use Current Project Directory";
            this.rdbChangeDir.UseVisualStyleBackColor = true;
            this.rdbChangeDir.CheckedChanged += new System.EventHandler(this.rdbChangeDir_CheckedChanged);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(33, 123);
            this.txtFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(447, 22);
            this.txtFile.TabIndex = 26;
            // 
            // rdbUseCurrent
            // 
            this.rdbUseCurrent.AutoSize = true;
            this.rdbUseCurrent.Location = new System.Drawing.Point(8, 28);
            this.rdbUseCurrent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbUseCurrent.Name = "rdbUseCurrent";
            this.rdbUseCurrent.Size = new System.Drawing.Size(214, 21);
            this.rdbUseCurrent.TabIndex = 0;
            this.rdbUseCurrent.TabStop = true;
            this.rdbUseCurrent.Text = "Use Current Project Directory";
            this.rdbUseCurrent.UseVisualStyleBackColor = true;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.ForeColor = System.Drawing.Color.Red;
            this.lblSize.Location = new System.Drawing.Point(17, 462);
            this.lblSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(0, 17);
            this.lblSize.TabIndex = 2;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(448, 492);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(167, 37);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 542);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(646, 589);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(646, 589);
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

    }
}