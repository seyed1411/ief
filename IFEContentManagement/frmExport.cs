﻿using System;
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

            txtFile.Text = dlgBrowse.SelectedPath;
        }

        private void frmExport_Load(object sender, EventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof(Languages)))
            {
                chkLstLanguages.Items.Add(item);
            }
            chkLstLanguages.SetItemChecked(0, true);
            txtCurrentLoc.Text = Program.currentProject.ContentLocation;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (DiskIO.IsValidPath(this.SelectedExportPath) && SelectedLanguages!= null)
            {
                FileCopier[] allCopy=Program.currentProject.ExportTo(SelectedExportPath,SelectedLanguages);
                frmCopyProgress progressDlg = new frmCopyProgress(allCopy);
                if (progressDlg.ShowDialog(this) == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                }
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
    }
}