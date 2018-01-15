using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;

namespace IFEContentManagement
{
    public partial class frmAddPlaylist : Form
    {
        public MusicPlaylist playlistToComplete;
        public Dictionary<string, MusicPlaylist> nonEngAdditionalData;
        public bool isNewPlaylist;

        public frmAddPlaylist(MusicPlaylist _plsToComplete, bool _isNew, Dictionary<string, MusicPlaylist> _nonEngData)
        {
            InitializeComponent();
            playlistToComplete = _plsToComplete;
            if (_nonEngData == null)
            {
                nonEngAdditionalData = new Dictionary<string, MusicPlaylist>();
            }
            else
                nonEngAdditionalData = _nonEngData;
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
            else
                cmbAge.SelectedIndex = 0;

            //
            lstGenres.Items.Clear();
            lstGenres.Items.AddRange(GetAudioGenres());
            if (playlistToComplete.genre != null)
                foreach (string x in playlistToComplete.genre)
                    if (lstGenres.FindString(x) != -1)
                        lstGenres.SetSelected(lstGenres.FindString(x), true);

            // create non-english langs panel
            UpdateLangsPanel();
        }

        private void additionalLangRecord_RemoveButton_Click(object sender, LabelEditEventArgs e)
        {
            nonEngAdditionalData.Remove(e.Label);
            UpdateLangsPanel();
        }

        private void additionalLangRecord_EditButton_Click(object sender, LabelEditEventArgs e)
        {
            MusicPlaylist temp = nonEngAdditionalData[e.Label];
            frmAddNewLanguage frmNewDlg = new frmAddNewLanguage(e.Label, temp.title, temp.artist, temp.description);
            if (frmNewDlg.ShowDialog(this) == DialogResult.OK)
            {              
                temp.title = frmNewDlg.InsertedTitle;
                temp.artist = frmNewDlg.InsertedArtists;
                temp.description = frmNewDlg.InsertedDescription;
            }
            UpdateLangsPanel();
        }
        

        private void btnNewLang_Click(object sender, EventArgs e)
        {
            // fetch which additional langs already filled for current playlist
            string[] existlangs = new string[nonEngAdditionalData.Count];
            int i = 0;
            foreach(var item in nonEngAdditionalData)
            {
                existlangs[i++] = item.Key;
            }
            // if all additional langs already filled, no action occured
            if (existlangs.Length == Enum.GetValues(typeof(Languages)).Length)
                return;
            frmAddNewLanguage newDlg = new frmAddNewLanguage(!EnglishMoreDataExist(), existlangs);
            if (newDlg.ShowDialog(this) == DialogResult.OK)
            {
                MusicPlaylist p = new MusicPlaylist(playlistToComplete.id);
                p.title = newDlg.InsertedTitle;
                p.artist = newDlg.InsertedArtists;
                p.description = newDlg.InsertedDescription;
                if (nonEngAdditionalData.ContainsKey(newDlg.SelectedLanguage))
                    nonEngAdditionalData.Remove(newDlg.SelectedLanguage);
                nonEngAdditionalData.Add(newDlg.SelectedLanguage, p);
            }
            UpdateLangsPanel();
        }        

        private void btnInsert_Click(object sender, EventArgs e)
        {
             if (this.FormCompleted() && EnglishMoreDataExist())
            {

                this.playlistToComplete.SetPlaylist(txtDirectory.Text);
                this.playlistToComplete.cover = txtCover.Text;
                this.playlistToComplete.year =txtYear.Text==""?0:  Convert.ToInt32(txtYear.Text);
                this.playlistToComplete.ageCategory = cmbAge.Items[cmbAge.SelectedIndex].ToString();
                string[] str = new string[lstGenres.SelectedItems.Count];
                int i = 0;
                foreach (object x in lstGenres.SelectedItems)
                    str[i++] = lstGenres.GetItemText(x);
                this.playlistToComplete.genre = str;
                this.playlistToComplete.num_tracks = DiskIO.GetFilesNumber(this.playlistToComplete.playlist, "*.mp3");
                // apply english language
                this.playlistToComplete.title = nonEngAdditionalData["English"].title;
                this.playlistToComplete.artist = nonEngAdditionalData["English"].artist;
                this.playlistToComplete.description = nonEngAdditionalData["English"].description;
                // apply for other languages
                nonEngAdditionalData.Remove("English");
                foreach (KeyValuePair<string, MusicPlaylist> x in this.nonEngAdditionalData)
                {
                    x.Value.id = this.playlistToComplete.id;
                    x.Value.SetPlaylist(txtDirectory.Text);
                    x.Value.cover = txtCover.Text;
                    x.Value.year = txtYear.Text == "" ? 0 : Convert.ToInt32(txtYear.Text);
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
                MessageBox.Show("Please fill Directory, Age, Genre and English Additional data first.","Warning",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        // other methodes
        private string[] GetAudioGenres()
        {
            string[] retval;
            try
            {
                SQLiteConnection mConn;
                SQLiteDataAdapter mAdapter;
                DataTable mTable;
                string mDbPath = Application.StartupPath + "/genres.db";

                // If DB Not Exists, it will be created.
                mConn = new SQLiteConnection("Data Source=" + mDbPath);
                mConn.Open();
                mAdapter = new SQLiteDataAdapter("SELECT Genre FROM [Audios]", mConn);
                mTable = new DataTable(); // Don't forget initialize!
                mAdapter.Fill(mTable);

                retval = mTable.AsEnumerable().Select(x => x["Genre"].ToString()).ToArray();
                mConn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Some Error in Genres fetch. Please review Audio genres database.\n" + e.Message, "Error", MessageBoxButtons.OK);
                retval = new string[1] { "Pop" };
            }
            return retval;
        }
        private void UpdateLangsPanel()
        {
            panelLangs.Controls.Clear();
            foreach (var item in nonEngAdditionalData)
            {
                EditRemoveAdditional additionalLangRecord = new EditRemoveAdditional(item.Key);
                additionalLangRecord.Width = 300;
                additionalLangRecord.EditButton_Click += additionalLangRecord_EditButton_Click;
                additionalLangRecord.RemoveButton_Click += additionalLangRecord_RemoveButton_Click;
                panelLangs.Controls.Add(additionalLangRecord);
            }
        }
        private string GetFullLangName(string _abbr)
        {
            foreach (var item in Enum.GetValues(typeof(Languages)))
            {
                if (item.ToString().StartsWith(_abbr))
                    return item.ToString();
            }
            return "";
        }

        private bool EnglishMoreDataExist()
        {
            return nonEngAdditionalData.ContainsKey("English");
        }


        private bool FormCompleted()
        {
            if (txtDirectory.Text == "" || cmbAge.SelectedItem == null || lstGenres.SelectedItems == null)
                return false;
            return true;
        }
    }
}