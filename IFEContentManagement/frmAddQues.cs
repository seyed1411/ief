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
    public partial class frmAddQues : Form
    {
        string language;
        string title;
        string answers;

        public frmAddQues()
        {
            InitializeComponent();
        }
        public frmAddQues(Languages _lang, string _tit, string[] _answer)
        {
            InitializeComponent();
            language = Convert.ToString(_lang);
            title = _tit;
            answers = _answer == null ? "" : string.Join(";", _answer);
        }

        public string SelectedLanguage
        {
            get { return language; }
        }
        public string InsertedTitle
        {
            get { return title; }
        }
        public string[] InsertedAnswers
        {
            get { return answers.Split(';'); }
        }

        private void frmAddQues_Load(object sender, EventArgs e)
        {
            cmbLanguage.Items.Clear();
            foreach (var item in Enum.GetValues(typeof(Languages)))
            {
                cmbLanguage.Items.Add(item);
            }
            if (language != null)
            {
                int index = cmbLanguage.FindString(language);
                cmbLanguage.SelectedIndex = index;
            }
            else
                cmbLanguage.SelectedIndex = 0;
            txtAnswers.Text = answers;
            txtTitle.Text = title;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnInsertAdditionalPlylistData_Click(object sender, EventArgs e)
        {
            if(txtAnswers.Text.Contains (';')==false)
            {
                MessageBox.Show("You must enter at least two answer for question. Seperate answers with character \";\"", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            language = cmbLanguage.Items[cmbLanguage.SelectedIndex].ToString();
            answers = txtAnswers.Text;
            title = txtTitle.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
