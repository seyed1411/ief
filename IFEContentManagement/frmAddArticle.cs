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
            if (_nonEngData == null)
            {
                nonEngAdditionalData = new Dictionary<string, ArticleFile>();
            }
            else
                nonEngAdditionalData = _nonEngData; isNewArticle = _isNew;
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
            ArticleFile temp = nonEngAdditionalData[e.Label];
            frmAddNewLanguage frmNewDlg = new frmAddNewLanguage(e.Label, temp.title, temp.writer, temp.description);
            if (frmNewDlg.ShowDialog(this) == DialogResult.OK)
            {
                temp.title = frmNewDlg.InsertedTitle;
                temp.writer = frmNewDlg.InsertedArtists;
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
                ArticleFile p = new ArticleFile(articleToComplete.id);
                p.title = newDlg.InsertedTitle;
                p.writer = newDlg.InsertedArtists;
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

                // apply english language
                this.articleToComplete.title = nonEngAdditionalData["English"].title;
                this.articleToComplete.writer = nonEngAdditionalData["English"].writer;
                this.articleToComplete.description = nonEngAdditionalData["English"].description;
                // apply for other languages
                nonEngAdditionalData.Remove("English");
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
                MessageBox.Show("Please fill File, Age, Genre and English Additional data first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    MessageBox.Show("Selected file is not an article (.pdf) file. Please Select another.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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

        // other methodes
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
            if (txtFile.Text == "" || cmbAge.SelectedItem == null || lstGenres.SelectedItems == null)
                return false;
            return true;
        }
    }
}
