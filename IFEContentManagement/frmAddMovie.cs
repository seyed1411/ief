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
    public partial class frmAddMovie : Form
    {
        public MovieFile movieToComplete;
        public Dictionary<string, MovieFile> nonEngAdditionalData;
        public bool isNewMovie;

        public frmAddMovie(MovieFile _movToComplete, bool _isNew)
        {
            InitializeComponent();
            movieToComplete = _movToComplete;
            nonEngAdditionalData = new Dictionary<string, MovieFile>();
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
            if (movieToComplete.genre != null)
                foreach (string x in movieToComplete.genre)
                    lstGenres.SetSelected(lstGenres.FindString(x), true);

        }

        private void btnNewLang_Click(object sender, EventArgs e)
        {
            if (this.FormCompleted())
            {
                if (isNewMovie)
                {
                    frmAddNewLanguage frmNewDlg = new frmAddNewLanguage("English", movieToComplete.title, movieToComplete.artist, movieToComplete.description);
                    if (frmNewDlg.ShowDialog(this) == DialogResult.OK)
                    {
                        this.movieToComplete.title = frmNewDlg.InsertedTitle;
                        this.movieToComplete.artist = frmNewDlg.InsertedArtists;
                        this.movieToComplete.description = frmNewDlg.InsertedDescription;
                    }
                }
                else
                {
                    frmAddNewLanguage frmNewDlg = new frmAddNewLanguage("English", movieToComplete.title, movieToComplete.artist, movieToComplete.description);
                    if (frmNewDlg.ShowDialog(this) == DialogResult.OK)
                    {
                        if (frmNewDlg.SelectedLanguage == "English")
                        {
                            this.movieToComplete.title = frmNewDlg.InsertedTitle;
                            this.movieToComplete.artist = frmNewDlg.InsertedArtists;
                            this.movieToComplete.description = frmNewDlg.InsertedDescription;
                        }
                        else
                        {
                            // in this condotion we should add new non-Eng language to the private list of playlist
                            MovieFile m = new MovieFile();
                            movieToComplete.CopyTo(m);
                            m.title = frmNewDlg.InsertedTitle;
                            m.artist = frmNewDlg.InsertedArtists;
                            m.description = frmNewDlg.InsertedDescription;
                            if (nonEngAdditionalData.ContainsKey(frmNewDlg.SelectedLanguage))
                                nonEngAdditionalData.Remove(frmNewDlg.SelectedLanguage);
                            nonEngAdditionalData.Add(frmNewDlg.SelectedLanguage, m);
                        }
                    }
                }
            }
            else
                MessageBox.Show("Please fill all of information filds.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private bool FormCompleted()
        {
            if (txtMovieFile.Text == "" || txtCover.Text == "" ||
                cmbAge.SelectedItem == null || lstGenres.SelectedItems == null)
                return false;
           
            return true;
        }

        private bool MovieInfoComplete()
        {
            if (txtMovieFile.Text == "" || txtCover.Text == "" ||
               cmbAge.SelectedItem == null || lstGenres.SelectedItems == null)
                return false;
            if (string.IsNullOrEmpty(movieToComplete.title)
                || string.IsNullOrEmpty(movieToComplete.description)
                || movieToComplete.artist.Length == 0)
                return false;
            return true;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (this.MovieInfoComplete())
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
                // apply for other languages
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
                MessageBox.Show("Please fill all of information filds.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    MessageBox.Show("This folder contains no music file. Please Select another.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                    MessageBox.Show("This folder contains no music file. Please Select another.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            txtTrailerFie.Text = dlgBrowse.FileName;
        }
    }
}
