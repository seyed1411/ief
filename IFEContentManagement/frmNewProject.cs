using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IFEContentManagement
{
    public partial class frmNewProject : Form
    {
        string strTit;
        string strLoc;
        public frmNewProject()
        {
            InitializeComponent();
        }

        public string SelectedTitle
        {
            get { return strTit; }
            set { strTit = value; }
        }
        public string SeletedFolder
        {
            get { return strLoc; }
            set { strLoc = value; }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            SelectedTitle = txtTitle.Text;
            SeletedFolder = txtLocation.Text;
            Program.currentProject = new ProjectFolder(strTit, strLoc);
            Program.currentProject.CreateNewProjectDirectories();
            this.DialogResult = DialogResult.OK;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var dlgCreate = new FolderBrowserDialog();
            if (dlgCreate.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(dlgCreate.SelectedPath))
            {
                strLoc = dlgCreate.SelectedPath;
                txtLocation.Text = strLoc;                
            }
        }

        private void chbImportProjData_CheckedChanged(object sender, EventArgs e)
        {
            if(btnImportBrowse.Enabled)
            {
                btnImportBrowse.Enabled = txtImportedLoc.Enabled = false;
            }
            else
            {
                btnImportBrowse.Enabled = txtImportedLoc.Enabled = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            //this.Dispose();
        }

        private void frmNewProject_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnBack_Click(sender,e);
        }

        private void frmNewProject_Load(object sender, EventArgs e)
        {
            strLoc = Program.latestPath;            
            txtTitle.Text = string.Empty;
            txtLocation.Text = strLoc;
            txtTitle.Focus();
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtLocation_Leave(object sender, EventArgs e)
        {
           
        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
