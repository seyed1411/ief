namespace IFEContentManagement
{
    partial class Form1
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
            this.lblSoftName = new System.Windows.Forms.Label();
            this.btnNewProject = new System.Windows.Forms.Button();
            this.btnOpenProject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSoftName
            // 
            this.lblSoftName.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoftName.Location = new System.Drawing.Point(12, 179);
            this.lblSoftName.Name = "lblSoftName";
            this.lblSoftName.Size = new System.Drawing.Size(288, 73);
            this.lblSoftName.TabIndex = 0;
            this.lblSoftName.Text = "IFE Content Management";
            this.lblSoftName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSoftName.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnNewProject
            // 
            this.btnNewProject.Location = new System.Drawing.Point(17, 256);
            this.btnNewProject.Name = "btnNewProject";
            this.btnNewProject.Size = new System.Drawing.Size(283, 47);
            this.btnNewProject.TabIndex = 1;
            this.btnNewProject.Text = "Create New Project";
            this.btnNewProject.UseVisualStyleBackColor = true;
            this.btnNewProject.Click += new System.EventHandler(this.btnNewProject_Click);
            // 
            // btnOpenProject
            // 
            this.btnOpenProject.Location = new System.Drawing.Point(17, 309);
            this.btnOpenProject.Name = "btnOpenProject";
            this.btnOpenProject.Size = new System.Drawing.Size(283, 47);
            this.btnOpenProject.TabIndex = 2;
            this.btnOpenProject.Text = "Open Existing Project";
            this.btnOpenProject.UseVisualStyleBackColor = true;
            this.btnOpenProject.Click += new System.EventHandler(this.btnOpenProject_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 375);
            this.Controls.Add(this.btnOpenProject);
            this.Controls.Add(this.btnNewProject);
            this.Controls.Add(this.lblSoftName);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IFE Content Management System";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSoftName;
        private System.Windows.Forms.Button btnNewProject;
        private System.Windows.Forms.Button btnOpenProject;
    }
}

