using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace IFEContentManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           /* ProjectFolder p = new ProjectFolder();
            lblSoftName.Text = p.SerializeJSON();//JsonConvert.SerializeObject(p);
            
            p.Deser();
            lblSoftName.Text = p.SerializeJSON();//JsonConvert.SerializeObject(p);*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnNewProject_Click(object sender, EventArgs e)
        {
            frmNewProject newProgWin = new frmNewProject();
            newProgWin.Show();
            this.Hide();
        }
    }
}
