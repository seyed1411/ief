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
    public partial class frmAddSurvey : Form
    {
        public Dictionary<string, QuestionCollection> QuestionCollection;

        public frmAddSurvey()
        {
            InitializeComponent();
            QuestionCollection = new Dictionary<string, QuestionCollection>();
        }

        public frmAddSurvey(Dictionary<string, QuestionCollection> _questionCollection)
        {
            InitializeComponent();
            QuestionCollection = _questionCollection;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmAddSurvey_Load(object sender, EventArgs e)
        {
            this.lstQuestions.Items.Clear();
            if (this.QuestionCollection.Count == 0)
                return;
            else
            {
                foreach (KeyValuePair<string, QuestionCollection> item in QuestionCollection)
                {
                    foreach (Question x in item.Value.questions)
                    {
                        lstQuestions.Items.Add(item.Key + "-" + x.title);
                    }
                }
            }
        }

        private string LanguageAbb(string _p)
        {
            return _p.Substring(0, 2).ToLower();
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            frmAddQues newQues = new frmAddQues();
            if (newQues.ShowDialog(this) == DialogResult.OK)
            {
                Question q = new Question("enum", newQues.InsertedAnswers, newQues.InsertedTitle);
                string languageKey = LanguageAbb(newQues.SelectedLanguage);
                if (QuestionCollection.ContainsKey(languageKey))
                    this.QuestionCollection[languageKey].questions.Add(q);
                else
                {
                    QuestionCollection newCollection = new QuestionCollection(DiagRTL(languageKey));
                    newCollection.questions.Add(q);
                    this.QuestionCollection.Add(languageKey, newCollection);
                }
                this.frmAddSurvey_Load(sender, e);

            }
        }
        private bool DiagRTL(string languageKey)
        {
            if (languageKey == "fa" || languageKey == "ar")
                return true;
            else
                return false;

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstQuestions.SelectedItem == null)
                return;
            else
            {
                string selected = lstQuestions.SelectedItem.ToString();
                string key = selected.Split('-')[0];
                string title = selected.Split('-')[1];
                //Question pointer = new Question();
                foreach (Question x in QuestionCollection[key].questions)
                {
                    if (x.title == title) { QuestionCollection[key].questions.Remove(x); break; }
                }
                //QuestionCollection[key].questions.Remove(pointer);
            }
            frmAddSurvey_Load(sender, e);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (this.lstQuestions.Items.Count == 0)
                this.DialogResult = DialogResult.Cancel;
            else
                this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

       
    }
}
