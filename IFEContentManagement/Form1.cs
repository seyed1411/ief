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
          /*  SurveyFolder f = new SurveyFolder();
            QuestionCollection q = new QuestionCollection();
            string[] ansnsn = new string[]{"good","bad"};
            q.questions.Add(new Question("enum",ansnsn,"How was food?"));
            q.questions.Add(new Question("enum",ansnsn,"How was larg monarch?"));
            s.questions.Add("en",q);
            f.surveys.Add(s);
            MessageBox.Show(JsonConvert.SerializeObject(f));
           ProjectFolder p = new ProjectFolder();
            lblSoftName.Text = p.SerializeJSON();//JsonConvert.SerializeObject(p);
            
            p.Deser();
            lblSoftName.Text = p.SerializeJSON();//JsonConvert.SerializeObject(p);*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void btnNewProject_Click(object sender, EventArgs e)
        {
            frmNewProject newProjWin = new frmNewProject();
            var res = newProjWin.ShowDialog(this);
            if (res == DialogResult.OK)
            {                
                Program.currentProject = new ProjectFolder(newProjWin.SelectedTitle, newProjWin.SeletedFolder);
                Program.mcmFile = newProjWin.SeletedFolder + "\\" + newProjWin.SelectedTitle + "\\.mcm";
                try
                {                   
                    Program.currentProject.CreateNewProjectDirectories();                    
                }
                catch(Exception exp)
                {
                    MessageBox.Show("Can not create new project. Please review location and title parameters.\n"+"Details: "+exp.Message, "Creation Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                frmSenarioMaker workDlg = new frmSenarioMaker(this);
                this.Hide();
                workDlg.Show();
            }
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnOpenProject_Click(object sender, EventArgs e)
        {
            var dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Mahan Content Management Files | *.mcm";
            if (dlgOpen.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(dlgOpen.FileName))
            {
                if(ProjectFolder.IsValidProjectDirectory(DiskIO.GetDirectoryName(dlgOpen.FileName)))
                {
                    //MessageBox.Show("sdadada");
                    //try
                    //{
                         Program.currentProject = new ProjectFolder(dlgOpen.FileName);
                         Program.mcmFile = dlgOpen.FileName;
                    //}
                    //catch (Exception exp)
                    //{
                      //  MessageBox.Show("Can not load existed project. Please review directory and .mcm file.\n" + "Details: " + exp.Message);
                    //}
                    frmSenarioMaker workDlg = new frmSenarioMaker(this);
                    this.Hide();
                    workDlg.Show();
                }
            }
        }
    }
}
