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
    public partial class frmAddMovie : Form
    {
        public MovieFile movieToComplete;
        public Dictionary<string, MovieFile> nonEngAdditionalData;
        public bool isNewMovie;

        public frmAddMovie(MovieFile _movToComplete, bool _isNew, Dictionary<string, MovieFile> _nonEngData)
        {
            InitializeComponent();
            movieToComplete = _movToComplete;
            if (_nonEngData == null)
            {
                nonEngAdditionalData = new Dictionary<string, MovieFile>();
            }
            else
                nonEngAdditionalData = _nonEngData;
            isNewMovie = _isNew;
        }

        private void frmAddMovie_Load(object sender, EventArgs e)
        {
            txtMovieFile.Text = movieToComplete.video.path;
            txtTrailerFie.Text = movieToComplete.trailer.path;
            txtCover.Text = movieToComplete.cover;
            txtDirector.Text = movieToComplete.director;
            if (movieToComplete.ageCategory != null)
            {
                int index = cmbAge.FindString(movieToComplete.ageCategory);
                cmbAge.SelectedIndex = index;
            }
            else
                cmbAge.SelectedIndex = 0;
            lstGenres.Items.Clear();
            lstGenres.Items.AddRange(GetVideoGenres());
            if (movieToComplete.genre != null)
                foreach (string x in movieToComplete.genre)
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
            MovieFile temp = nonEngAdditionalData[e.Label];
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
            foreach (var item in nonEngAdditionalData)
            {
                existlangs[i++] = item.Key;
            }
            // if all additional langs already filled, no action occured
            if (existlangs.Length == Enum.GetValues(typeof(Languages)).Length)
                return;
            frmAddNewLanguage newDlg = new frmAddNewLanguage(!EnglishMoreDataExist(), existlangs);
            if (newDlg.ShowDialog(this) == DialogResult.OK)
            {
                MovieFile p = new MovieFile(movieToComplete.id);
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

                this.movieToComplete.video.path = txtMovieFile.Text;
                this.movieToComplete.trailer.path = txtTrailerFie.Text;
                this.movieToComplete.cover = txtCover.Text;
                this.movieToComplete.director = txtDirector.Text;
                this.movieToComplete.ageCategory = cmbAge.Items[cmbAge.SelectedIndex].ToString();
                string[] str = new string[lstGenres.SelectedItems.Count];
                int i = 0;
                foreach (object x in lstGenres.SelectedItems)
                    str[i++] = lstGenres.GetItemText(x);
                this.movieToComplete.genre = str;
                this.movieToComplete.length = 0;//go back 
                // apply english language
                this.movieToComplete.title = nonEngAdditionalData["English"].title;
                this.movieToComplete.artist = nonEngAdditionalData["English"].artist;
                this.movieToComplete.description = nonEngAdditionalData["English"].description;
                // apply for other languages
                nonEngAdditionalData.Remove("English");
                foreach (KeyValuePair<string, MovieFile> x in this.nonEngAdditionalData)
                {
                    x.Value.id = this.movieToComplete.id;
                    x.Value.video.path = txtMovieFile.Text;
                    x.Value.trailer.path = txtTrailerFie.Text;
                    x.Value.cover = txtCover.Text;
                    x.Value.director = txtDirector.Text;
                    x.Value.ageCategory = cmbAge.Items[cmbAge.SelectedIndex].ToString();
                    str = new string[lstGenres.SelectedItems.Count];
                    i = 0;
                    foreach (object obj in lstGenres.SelectedItems)
                        str[i++] = lstGenres.GetItemText(obj);
                    x.Value.genre = str;
                    x.Value.length = 0;//go back 
                }
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Please fill Video, Age, Genre and English Additional data first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnBrowseDir_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgBrowse = new OpenFileDialog();
            while (dlgBrowse.ShowDialog() == DialogResult.OK)
            {
                if (DiskIO.IsVideoFile(dlgBrowse.FileName))
                    break;
                else
                    MessageBox.Show("This file is not a valid video file. Please Select another.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            txtMovieFile.Text = dlgBrowse.FileName;
        }

        private void btnBrowseCov_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            while (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                if (DiskIO.IsImageFile(dlgOpen.FileName))
                    break;
                else
                    MessageBox.Show("This file is not an image file. Please Select another.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            txtCover.Text = dlgOpen.FileName;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgBrowse = new OpenFileDialog();
            while (dlgBrowse.ShowDialog() == DialogResult.OK)
            {
                if (DiskIO.IsVideoFile(dlgBrowse.FileName))
                    break;
                else
                    MessageBox.Show("This file is not a valid video file. Please Select another.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            txtTrailerFie.Text = dlgBrowse.FileName;
        }

        // other methodes
        private string[] GetVideoGenres()
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
                mAdapter = new SQLiteDataAdapter("SELECT Genre FROM [Videos]", mConn);
                mTable = new DataTable(); // Don't forget initialize!
                mAdapter.Fill(mTable);
               
                retval = mTable.AsEnumerable().Select(x => x["Genre"].ToString()).ToArray();
                mConn.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("Some Error in Genres fetch. Please review Video genres database.\n" + e.Message, "Error", MessageBoxButtons.OK);
                retval = new string[1] { "Drama" };
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
            if (txtMovieFile.Text == "" || cmbAge.SelectedItem == null || lstGenres.SelectedItems == null)
                return false;
            return true;
        }
    }
}