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
    public partial class frmAddPlaylist : Form
    {
        public MusicPlaylist playlistToComplete;
        public Dictionary<string, MusicPlaylist> nonEngAdditionalData;
        public bool isNewPlaylist;

        public frmAddPlaylist(MusicPlaylist _plsToComplete, bool _isNew)
        {
            InitializeComponent();
            playlistToComplete = _plsToComplete;
            nonEngAdditionalData = new Dictionary<string, MusicPlaylist>();
            isNewPlaylist = _isNew;
        }

        private void frmAddPlaylist_Load(object sender, EventArgs e)
        {
            txtDirectory.Text = playlistToComplete.playlist;
            txtCover.Text = playlistToComplete.cover;
            txtYear.Text = playlistToComplete.year == 0 ? "" : playlistToComplete.year.ToString();
            if (playlistToComplete.ageCategory != null)
            {
                int index = cmbAge.FindString(playlistToComplete.ageCategory);
                cmbAge.SelectedIndex = index;
            }
            if (playlistToComplete.genre != null)
                foreach (string x in playlistToComplete.genre)
                    lstGenres.SetSelected(lstGenres.FindString(x), true);

        }

        private void btnNewLang_Click(object sender, EventArgs e)
        {
            if (this.FormCompleted())
            {
                if (isNewPlaylist)
                {
                    frmAddQuestion frmNewDlg = new frmAddQuestion(true, Languages.English, playlistToComplete.title, playlistToComplete.artist, playlistToComplete.description);
                    if (frmNewDlg.ShowDialog(this) == DialogResult.OK)
                    {
                        this.playlistToComplete.title = frmNewDlg.InsertedTitle;
                        this.playlistToComplete.artist = frmNewDlg.InsertedArtists;
                        this.playlistToComplete.description = frmNewDlg.InsertedDescription;
                    }
                }
                else
                {
                    frmAddQuestion frmNewDlg = new frmAddQuestion(false, Languages.English, playlistToComplete.title, playlistToComplete.artist, playlistToComplete.description);
                    if (frmNewDlg.ShowDialog(this) == DialogResult.OK)
                    {
                        if (frmNewDlg.SelectedLanguage == "English")
                        {
                            this.playlistToComplete.title = frmNewDlg.InsertedTitle;
                            this.playlistToComplete.artist = frmNewDlg.InsertedArtists;
                            this.playlistToComplete.description = frmNewDlg.InsertedDescription;
                        }
                        else
                        {
                            // in this condotion we should add new non-Eng language to the private list of playlist
                            MusicPlaylist p = new MusicPlaylist(playlistToComplete.id);
                            playlistToComplete.CopyTo(p);
                            p.title = frmNewDlg.InsertedTitle;
                            p.artist = frmNewDlg.InsertedArtists;
                            p.description = frmNewDlg.InsertedDescription;
                            if (nonEngAdditionalData.ContainsKey(frmNewDlg.SelectedLanguage))
                                nonEngAdditionalData.Remove(frmNewDlg.SelectedLanguage);
                            nonEngAdditionalData.Add(frmNewDlg.SelectedLanguage, p);
                        }
                    }
                }
            }
            else
                MessageBox.Show("Please fill all of information filds.", "Warning",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private bool FormCompleted()
        {
            if (txtDirectory.Text == "" || txtCover.Text == "" || txtYear.Text == "" || cmbAge.SelectedItem == null || lstGenres.SelectedItems == null)
                return false;
            return true;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (this.FormCompleted())
            {

                this.playlistToComplete.SetPlaylist(txtDirectory.Text);
                this.playlistToComplete.cover = txtCover.Text;
                this.playlistToComplete.year = Convert.ToInt32(txtYear.Text);
                this.playlistToComplete.ageCategory = cmbAge.Items[cmbAge.SelectedIndex].ToString();
                string[] str = new string[lstGenres.SelectedItems.Count];
                int i = 0;
                foreach (object x in lstGenres.SelectedItems)
                    str[i++] = lstGenres.GetItemText(x);
                this.playlistToComplete.genre = str;
                this.playlistToComplete.num_tracks = DiskIO.GetFilesNumber(this.playlistToComplete.playlist, "*.mp3");
                // apply for other languages
                foreach (KeyValuePair<string, MusicPlaylist> x in this.nonEngAdditionalData)
                {
                    x.Value.id = this.playlistToComplete.id;
                    x.Value.SetPlaylist(txtDirectory.Text);
                    x.Value.cover = txtCover.Text;
                    x.Value.year = Convert.ToInt32(txtYear.Text);
                    x.Value.ageCategory = cmbAge.Items[cmbAge.SelectedIndex].ToString();
                    str = new string[lstGenres.SelectedItems.Count];
                    i = 0;
                    foreach (object obj in lstGenres.SelectedItems)
                        str[i++] = lstGenres.GetItemText(obj);
                    x.Value.genre = str;
                    x.Value.num_tracks = DiskIO.GetFilesNumber(this.playlistToComplete.playlist, "*.mp3");
                }
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Please fill all of information filds.","Warning",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnBrowseDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlgBrowse = new FolderBrowserDialog();
            while (dlgBrowse.ShowDialog() == DialogResult.OK)
            {
                if (DiskIO.DirectoryHasMusicFile(dlgBrowse.SelectedPath))
                    break;
                else
                    MessageBox.Show("This folder contains no music file. Please Select another.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            txtDirectory.Text = dlgBrowse.SelectedPath;
        }

        private void btnBrowseCov_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            while (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                if (DiskIO.IsImageFile(dlgOpen.FileName))
                    break;
                else
                    MessageBox.Show("This file is not an image file. Please Select another.", "Warning", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            txtCover.Text = dlgOpen.FileName;

        }
    }
}