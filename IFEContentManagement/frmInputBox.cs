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
    public partial class frmInputBox : Form
    {
        public string Message;
        public string Input;
        public frmInputBox(string _message)
        {
            InitializeComponent();
            Message = _message;
        }

        private void frmInputBox_Load(object sender, EventArgs e)
        {
            lblMessage.Text = Message;
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Input = textBox1.Text;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Input = "";
            DialogResult = DialogResult.Cancel;
        }
    }
}
