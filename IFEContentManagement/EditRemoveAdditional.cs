using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IFEContentManagement
{
    public partial class EditRemoveAdditional : UserControl
    {
        public event LabelEditEventHandler RemoveButton_Click;
        public event LabelEditEventHandler EditButton_Click;

        public EditRemoveAdditional(string _languagetag)
        {
            InitializeComponent();
            lblLabel.Text = _languagetag;
        }
        public string LanguageTag
        {
            get
            {
                if (!string.IsNullOrEmpty(lblLabel.Text))
                    return lblLabel.Text;
                else
                    return "";
            }
        }
        private void EditRemoveAdditional_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            if (this.RemoveButton_Click != null)
            {
                LabelEditEventArgs arg = new LabelEditEventArgs(0, LanguageTag);
                this.RemoveButton_Click(sender, arg);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            if (this.EditButton_Click != null)
            {
                LabelEditEventArgs arg = new LabelEditEventArgs(0, LanguageTag);
                this.EditButton_Click(sender, arg);
            }
        }

       
    }
}
