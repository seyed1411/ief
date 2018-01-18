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
        }

        public void btnNewProject_Click(object sender, EventArgs e)
        {
            try
            {

                frmNewProject newProjWin = new frmNewProject();
                var res = newProjWin.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    Program.currentProject = new ProjectFolder(newProjWin.SelectedTitle, newProjWin.SeletedFolder);
                    Program.mcmFile = newProjWin.SeletedFolder + "\\" + newProjWin.SelectedTitle + "\\.mcm";
                    Program.currentProject.CreateNewProjectDirectories();


                    frmSenarioMaker workDlg = new frmSenarioMaker(this);
                    this.Hide();
                    workDlg.Show();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Can not create new project. Please review location and title parameters.\n" + "Details: " + exp.Source + " - " + exp.Message, "Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnOpenProject_Click(object sender, EventArgs e)
        {
            try
            {
                var dlgOpen = new OpenFileDialog();
                dlgOpen.Filter = "Mahan Content Management Files | *.mcm";
                if (dlgOpen.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(dlgOpen.FileName))
                {

                    if (ProjectFolder.IsValidProjectDirectory(DiskIO.GetDirectoryName(dlgOpen.FileName)))
                    {
                        //MessageBox.Show("sdadada");

                        Program.currentProject = new ProjectFolder(dlgOpen.FileName);
                        Program.mcmFile = dlgOpen.FileName;

                        frmSenarioMaker workDlg = new frmSenarioMaker(this);
                        this.Hide();
                        workDlg.Show();
                    }
                    else
                        throw new Exception(".MCM File or project directory is not valid.");

                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Can not load existed project. Please review directory and .mcm file.\n" + "Details: " + exp.Source + " - " + exp.Message, "Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}
