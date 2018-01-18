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
    public partial class frmExport : Form
    {
        public frmExport()
        {
            InitializeComponent();
        }

        private void rdbChangeDir_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbChangeDir.Checked)
                txtFile.Enabled = btnBrowseDir.Enabled = true;
            else
                txtFile.Enabled = btnBrowseDir.Enabled = false;

        }

        private void btnBrowseDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlgBrowse = new FolderBrowserDialog();
            if (dlgBrowse.ShowDialog() == DialogResult.OK)
                txtFile.Text = dlgBrowse.SelectedPath;
        }

        private void frmExport_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in Enum.GetValues(typeof(Languages)))
                {
                    chkLstLanguages.Items.Add(item);
                }
                chkLstLanguages.SetItemChecked(0, true);
                txtCurrentLoc.Text = Program.currentProject.ContentLocation;
                txtFile.Enabled = btnBrowseDir.Enabled = false;

                int numOfFiles = 0;
                long filesVolume = Program.currentProject.GetAllFilesVolume(out numOfFiles);
                string volStr = HumanPresentVolume(filesVolume);
                lblSize.Text = numOfFiles.ToString() + "  files (About " + volStr + " ) must be copied.";
            }
            catch (Exception exp)
            {
                Program.ShowExceptionData(exp);
            }
        }

        private string HumanPresentVolume(long _volToByte)
        {
            string retVal = "";
            if (_volToByte < 1024)
                retVal = Convert.ToString(_volToByte) + " bytes";
            else if (_volToByte >= 1024 && _volToByte < 1048576)
                retVal = (_volToByte / 1024).ToString("0.0") + " KiloBytes";
            else if(_volToByte >= 1048576 && _volToByte < 1073741824)
                retVal = (_volToByte / 1048576).ToString("0.0") + " MegaBytes";
            else if(_volToByte >= 1073741824)
                retVal = (_volToByte / 1073741824).ToString("0.0") + " GigaBytes";
            return retVal;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (DiskIO.IsValidPath(this.SelectedExportPath) && SelectedLanguages != null)
                {
                    int i;
                    if (DiskIO.DriveHasFreeSpace(SelectedExportPath, Program.currentProject.GetAllFilesVolume(out i)))
                    {
                        FileCopier[] allCopy = Program.currentProject.ExportTo(SelectedExportPath, SelectedLanguages);
                        frmCopyProgress progressDlg = new frmCopyProgress(allCopy);
                        if (progressDlg.ShowDialog(this) == DialogResult.OK)
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else
                    {
                        MessageBox.Show("There is no enough free space in selected drive. Please choose another location.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please choose proper location for export.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exp)
            {
                Program.ShowExceptionData(exp);
            }
            
        }

        public string SelectedExportPath
        {
            get
            {
                if (rdbUseCurrent.Checked)
                    return txtCurrentLoc.Text;
                else
                    return txtFile.Text;
            }
        }

        public string[] SelectedLanguages {
            get
            {
                if (chkLstLanguages.CheckedItems.Count == 0)
                    return null;
                string[] retval = new string[chkLstLanguages.CheckedItems.Count];
                int i = 0;
                foreach(var item in chkLstLanguages.CheckedItems)
                {
                    retval[i++] = item.ToString();
                }
                return retval;
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for(int i=0; i<chkLstLanguages.Items.Count;i++)
            {
                chkLstLanguages.SetItemChecked(i, true);
            }
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chkLstLanguages.Items.Count; i++)
            {
                chkLstLanguages.SetItemChecked(i, false);
            }
        }

        private void btnSelectEn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chkLstLanguages.Items.Count; i++)
            {
                chkLstLanguages.SetItemChecked(i, false);
            }
            chkLstLanguages.SetItemChecked(0, true);
        }
    }
}
