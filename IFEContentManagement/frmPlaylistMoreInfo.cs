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
    public partial class frmAddNewLanguage : Form
    {
        bool justEn;
        bool isNew;
        string language;
        string[] removedLangs;
        string title;
        string artist;
        string description;

        //constructores
        public frmAddNewLanguage(bool _justEN, string[] _removedLang)
        {
            InitializeComponent();
            justEn = _justEN;
            isNew = true;
            removedLangs = _removedLang;
        }
        public frmAddNewLanguage(string _lang, string _tit, string[] _artist, string _desc)
        {
            InitializeComponent();
            justEn = false;
            isNew = false;            
            language = _lang;
            title = _tit;
            artist = _artist == null ? "" : string.Join(";", _artist);
            description = _desc;
        }

        // properties
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

        // events
        private void frmAdditionalLang__Load(object sender, EventArgs e)
        {
            // add all languages to combo list
            cmbLang.Items.Clear();
            foreach (var item in Enum.GetValues(typeof(Languages)))
            {
                cmbLang.Items.Add(item);
            }

            // decide based on calling situation
            if(!isNew)
            {
                int index = cmbLang.FindString(language);
                cmbLang.SelectedIndex = index;
                cmbLang.Enabled = false;
            }
            else
            {
                if (justEn)
                {
                    int index = cmbLang.FindString("English");
                    cmbLang.SelectedIndex = index;
                    cmbLang.Enabled = false;
                }
                else
                {
                    foreach (var item in Enum.GetValues(typeof(Languages)))
                        if (removedLangs.Contains<string>(item.ToString()))
                            cmbLang.Items.Remove(item);
                    cmbLang.SelectedIndex = 0;
                }
            }
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
            if(txtArtists.Text==""&&txtTitle.Text==""&&txtDescription.Text=="")
            {
                MessageBox.Show("Please fill at least one of filds to create new record.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            language = cmbLang.Items[cmbLang.SelectedIndex].ToString();
            artist = txtArtists.Text;
            title = txtTitle.Text;
            description = txtDescription.Text;            
            this.DialogResult = DialogResult.OK;
        }

        private void cmbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtArtists.Text = "";
            txtTitle.Text = "";
            txtDescription.Text = "";
        }
    }
}
