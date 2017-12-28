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
    public partial class frmAddQuestion : Form
    {
        bool justEn;
        string language;
        string title;
        string artist;
        string description;

        public frmAddQuestion(bool _justEN)
        {
            InitializeComponent();
            justEn = _justEN;
        }
        public frmAddQuestion(bool _justEN, Languages _lang, string _tit, string[] _artist, string _desc)
        {
            InitializeComponent();
            justEn = _justEN;
            language = Convert.ToString(_lang);
            title = _tit;
            artist = _artist == null ? "" : string.Join(";", _artist);
            description = _desc;
        }

        public string SelectedLanguage
        {
            get { return language; }
        }
        public string InsertedTitle
        {
            get { return title; }
        }
        public string[] InsertedArtists
        {
            get { return artist.Split(';'); }
        }
        public string InsertedDescription
        {
            get { return this.description; }
        }
        private void frmAdditionalLang__Load(object sender, EventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof(Languages)))
            {
                cmbLang.Items.Add(item);
            }
            int index = cmbLang.FindString(language);
            cmbLang.SelectedIndex = index;
            if(justEn == true)            
                cmbLang.Enabled = false;

            txtArtists.Text = artist;
            txtTitle.Text = title;
            txtDescription.Text = description;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnInsertAdditionalPlylistData_Click(object sender, EventArgs e)
        {
            language = cmbLang.Items[cmbLang.SelectedIndex].ToString();
            artist = txtArtists.Text;
            title = txtTitle.Text;
            description = txtDescription.Text;
            if (!this.justEn)
                MessageBox.Show("If you enter new data in non-English languages, old data will be overwritten!", "Non-English Data Change Alert");
            this.DialogResult = DialogResult.OK;
        }

        private void cmbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbLang.FindString("English");
            if (cmbLang.SelectedIndex != index)
            {
                txtArtists.Text = "";
                txtTitle.Text = "";
                txtDescription.Text = "";
            }
            else
            {
                txtArtists.Text = artist;
                txtTitle.Text = title;
                txtDescription.Text = description;
            }
        }
    }
}
