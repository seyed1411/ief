using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace IFEContentManagement
{
    public partial class frmCopyProgress : Form
    {
        // Class to report progress
        private class UIProgress
        {
            public UIProgress(string name_, long bytes_, long maxbytes_)
            {
                name = name_; bytes = bytes_; maxbytes = maxbytes_;
            }
            public string name;
            public long bytes;
            public long maxbytes;
        }
        // Class to report exception {
        private class UIError
        {
            public UIError(Exception ex, string path_)
            {
                msg = ex.Message; path = path_; result = DialogResult.Cancel;
            }
            public string msg;
            public string path;
            public DialogResult result;
        }
        private BackgroundWorker mCopier;
        private delegate void ProgressChanged(UIProgress info);
        private delegate void CopyError(UIError err);
        private ProgressChanged OnChange;
        private CopyError OnError;

        private FileCopier[] bank;
        public frmCopyProgress(FileCopier[] _b)
        {
            InitializeComponent();
            mCopier = new BackgroundWorker();
            mCopier.DoWork += Copier_DoWork;
            mCopier.RunWorkerCompleted += Copier_RunWorkerCompleted;
            mCopier.WorkerSupportsCancellation = true;
            OnChange += Copier_ProgressChanged;
            OnError += Copier_Error;
            button1.Click += button1_Click;
            ChangeUI(false);
            bank = _b;
        }

        private void Copier_DoWork(object sender, DoWorkEventArgs e)
        {
            
            long maxbytes = 0;
            
            foreach (FileCopier file in bank)
            {
                FileInfo info = new FileInfo(file.SourceFile);                
                    maxbytes += info.Length;
            }
            // Copy files
            long bytes = 0;
            foreach (FileCopier file in bank)
            {
                FileInfo info = new FileInfo(file.SourceFile);
                try
                {
                    this.BeginInvoke(OnChange, new object[] { new UIProgress(Path.GetFileName(file.SourceFile), bytes, maxbytes) });
                    File.Copy(file.SourceFile,file.DestinationFile, true);
                }
                catch (Exception ex)
                {
                    UIError err = new UIError(ex, file.SourceFile);
                    this.Invoke(OnError, new object[] { err });
                    if (err.result == DialogResult.Cancel) break;
                }
                bytes += info.Length;
            }
            this.DialogResult = DialogResult.OK;
        }
        private void Copier_ProgressChanged(UIProgress info)
        {
            // Update progress
            progressBar1.Value = (int)(100.0 * info.bytes / info.maxbytes);
            label1.Text = "Copying " + info.name;
        }
        private void Copier_Error(UIError err)
        {
            // Error handler
            string msg = string.Format("Error copying file {0}\n{1}\nClick OK to continue copying files", err.path, err.msg);
            err.result = MessageBox.Show(msg, "Copy error", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
        }
        private void Copier_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Operation completed, update UI
            ChangeUI(false);
        }
        private void ChangeUI(bool docopy)
        {
            label1.Visible = docopy;
            progressBar1.Visible = docopy;
            button1.Text = docopy ? "Cancel" : "Start";
            label1.Text = "Starting copy...";
            progressBar1.Value = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool docopy = button1.Text == "Start";
            ChangeUI(docopy);
            if (docopy) mCopier.RunWorkerAsync();
            else mCopier.CancelAsync();
        }

        private void frmCopyProgress_Load(object sender, EventArgs e)
        {
            bool docopy = button1.Text == "Start";
            ChangeUI(docopy);
            if (docopy) mCopier.RunWorkerAsync();
            else mCopier.CancelAsync();
        }

        private void frmCopyProgress_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
                e.Cancel = true;
        }
    }

}
