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
    public partial class frmAddArticle : Form
    {
        public ArticleFile articleToComplete;
        public Dictionary<string, ArticleFile> nonEngAdditionalData;
        public bool isNewArticle;

        public frmAddArticle(ArticleFile _artToComplete, bool _isNew, Dictionary<string, ArticleFile> _nonEngData)
        {
            InitializeComponent();
            articleToComplete = _artToComplete;
            nonEngAdditionalData = new Dictionary<string, ArticleFile>();
            isNewArticle = _isNew;
            foreach (var item in Enum.GetValues(typeof(Languages)))
            {
                cmbLanguage.Items.Add(item);
            }
        }

        private void frmAddArticle_Load(object sender, EventArgs e)
        {
            txtFile.Text = articleToComplete.file;
            txtCover.Text = articleToComplete.cover;
            txtYear.Text = articleToComplete.year == 0 ? "" : articleToComplete.year.ToString();
            if (articleToComplete.ageCategory != null)
            {
                int index = cmbAge.FindString(articleToComplete.ageCategory);
                cmbAge.SelectedIndex = index;
            }
            if (articleToComplete.lannguage != null)
            {
                int index = cmbLanguage.FindString(articleToComplete.lannguage);
                cmbLanguage.SelectedIndex = index;
            }
            if (articleToComplete.genre != null)
                foreach (string x in articleToComplete.genre)
                    lstGenres.SetSelected(lstGenres.FindString(x), true);

        }

        private void btnNewLang_Click(object sender, EventArgs e)
        {
            if (this.FormCompleted())
            {
                if (isNewArticle)
                {
                    frmAddNewLanguage frmNewDlg = new frmAddNewLanguage("English", articleToComplete.title, articleToComplete.writer, articleToComplete.description);
                    frmNewDlg.lblArtist.Text = "Artists:";
                    if (frmNewDlg.ShowDialog(this) == DialogResult.OK)
                    {
                        this.articleToComplete.title = frmNewDlg.InsertedTitle;
                        this.articleToComplete.writer = frmNewDlg.InsertedArtists;
                        this.articleToComplete.description = frmNewDlg.InsertedDescription;
                    }
                }
                else
                {
                    frmAddNewLanguage frmNewDlg = new frmAddNewLanguage("English", articleToComplete.title, articleToComplete.writer, articleToComplete.description);
                    if (frmNewDlg.ShowDialog(this) == DialogResult.OK)
                    {
                        if (frmNewDlg.SelectedLanguage == "English")
                        {
                            this.articleToComplete.title = frmNewDlg.InsertedTitle;
                            this.articleToComplete.writer = frmNewDlg.InsertedArtists;
                            this.articleToComplete.description = frmNewDlg.InsertedDescription;
                        }
                        else
                        {
                            // in this condotion we should add new non-Eng language to the private list of playlist
                            ArticleFile art = new ArticleFile(articleToComplete.id);
                            articleToComplete.CopyTo(art);
                            art.title = frmNewDlg.InsertedTitle;
                            art.writer = frmNewDlg.InsertedArtists;
                            art.description = frmNewDlg.InsertedDescription;
                            if (nonEngAdditionalData.ContainsKey(frmNewDlg.SelectedLanguage))
                                nonEngAdditionalData.Remove(frmNewDlg.SelectedLanguage);
                            nonEngAdditionalData.Add(frmNewDlg.SelectedLanguage, art);
                        }
                    }
                }
            }
            else
                MessageBox.Show("Please fill all of information filds.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private bool FormCompleted()
        {
            if (txtFile.Text == "" || txtCover.Text == "" || txtYear.Text == "" || cmbAge.SelectedItem == null || lstGenres.SelectedItems == null)
                return false;
            return true;
        }
        private bool ArticleInfoComplete()
        {
            if (txtFile.Text == "" || txtCover.Text == "" ||
               cmbAge.SelectedItem == null || lstGenres.SelectedItems == null)
                return false;
            if (string.IsNullOrEmpty(articleToComplete.title)
                || string.IsNullOrEmpty(articleToComplete.description)
                || articleToComplete.writer.Length == 0)
                return false;
            return true;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (this.ArticleInfoComplete())
            {

                this.articleToComplete.file = txtFile.Text;
                this.articleToComplete.cover = txtCover.Text;
                this.articleToComplete.year = Convert.ToInt32(txtYear.Text);
                this.articleToComplete.ageCategory = cmbAge.Items[cmbAge.SelectedIndex].ToString();
                this.articleToComplete.lannguage = cmbLanguage.Items[cmbLanguage.SelectedIndex].ToString();
                string[] str = new string[lstGenres.SelectedItems.Count];
                int i = 0;
                foreach (object x in lstGenres.SelectedItems)
                    str[i++] = lstGenres.GetItemText(x);
                this.articleToComplete.genre = str;

                // apply for other languages
                foreach (KeyValuePair<string, ArticleFile> x in this.nonEngAdditionalData)
                {
                    x.Value.id = this.articleToComplete.id;
                    x.Value.file = txtFile.Text;
                    x.Value.cover = txtCover.Text;
                    x.Value.year = Convert.ToInt32(txtYear.Text);
                    x.Value.ageCategory = cmbAge.Items[cmbAge.SelectedIndex].ToString();
                    x.Value.lannguage = cmbLanguage.Items[cmbLanguage.SelectedIndex].ToString();
                    str = new string[lstGenres.SelectedItems.Count];
                    i = 0;
                    foreach (object obj in lstGenres.SelectedItems)
                        str[i++] = lstGenres.GetItemText(obj);
                    x.Value.genre = str;
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
                if (DiskIO.IsArticleFile(dlgBrowse.FileName))
                    break;
                else
                    MessageBox.Show("Selected file is not article (.pdf) file. Please Select another.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            txtFile.Text = dlgBrowse.FileName;
        }

        private void btnBrowseCov_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            while (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                if (DiskIO.IsImageFile(dlgOpen.FileName))
                    break;
                else
                    MessageBox.Show("Selected file is not an image file. Please Select another.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            txtCover.Text = dlgOpen.FileName;

        }
    }
}
