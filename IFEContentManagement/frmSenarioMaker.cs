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
    public partial class frmSenarioMaker : Form
    {
        Form1 parent;
        public frmSenarioMaker(Form1 _parent)
        {
            parent = _parent;
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to close project:  "+Program.currentProject.GetTitle()+"  ?","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                this.parent.Show();
                this.Hide();
                Program.currentProject = null;
                Program.mcmFile = null;
                this.Dispose();
            }
        }

        private void frmSenarioMaker_Load(object sender, EventArgs e)
        {
            UpdateTreesPresentation();
        }

        private void btnAddPlaylist_Click(object sender, EventArgs e)
        {
            int id = Program.currentProject.FindLastPlaylistID();
            MusicPlaylist newPlaylist = new MusicPlaylist(id);
            frmAddPlaylist newPllstDlg = new frmAddPlaylist(newPlaylist, true, null);
            if (newPllstDlg.ShowDialog(this) == DialogResult.OK)
            {
                //newPlaylist.id = Program.currentProject.FindLastPlaylistID();
                Program.currentProject.AddPlaylist(newPlaylist);
                if (newPllstDlg.nonEngAdditionalData.Count > 0)
                    Program.currentProject.SavePlaylistsNonEnglishData(newPllstDlg.nonEngAdditionalData);
                this.ApplyChangesOnHardDrive();
            }
            this.UpdateTreesPresentation();

        }

        private void ApplyChangesOnHardDrive()
        {
            

            lblStatus.Text = "Saving Playlists...";
            Program.currentProject.SavePlaylistData();
            progBar.PerformStep();

            lblStatus.Text = "Saving Movies...";
            Program.currentProject.SaveMoviesData();
            progBar.PerformStep();

            lblStatus.Text = "Saving Announcements...";
            Program.currentProject.SaveAnnouncData();
            progBar.PerformStep();

            lblStatus.Text = "Saving Articles...";
            Program.currentProject.SaveArticleData();
            progBar.PerformStep();

            lblStatus.Text = "Saving Surveys...";
            Program.currentProject.SaveSurveyData();
            progBar.PerformStep();

            lblStatus.Text = "Ready";
            progBar.Value = 0;
        }

        private void UpdateTreesPresentation()
        {
            // update playlists
            treePlaylists.Nodes.Clear();
            TreeNode root = new TreeNode("Playlists");
            foreach (MusicPlaylist x in Program.currentProject.GetPlaylistsCollection())
            {
                TreeNode child = new TreeNode(x.id.ToString());
                foreach(MusicFile y in x.GetMusicFilesInfo())
                {
                    TreeNode child2 = new TreeNode(y.title);
                    child.Nodes.Add(child2);
                }
                root.Nodes.Add(child);
            }
            treePlaylists.Nodes.Add(root);
            treePlaylists.ExpandAll();

            // update movies
            treeMovies.Nodes.Clear();
            root = new TreeNode("Movies");
            foreach (MovieFile x in Program.currentProject.GetMoviesCollection())
            {
                TreeNode child = new TreeNode(x.id.ToString());
                root.Nodes.Add(child);
            }
            treeMovies.Nodes.Add(root);
            treeMovies.ExpandAll();

            // update announcements
            treeAnnounc.Nodes.Clear();
            root = new TreeNode("Announcements");
            foreach (MovieFile x in Program.currentProject.GetAnnouncesCollection())
            {
                TreeNode child = new TreeNode(x.id.ToString());
                root.Nodes.Add(child);
            }
            treeAnnounc.Nodes.Add(root);
            treeAnnounc.ExpandAll();

            // update articles
            treeArticle.Nodes.Clear();
            root = new TreeNode("Articles");
            foreach (ArticleFile x in Program.currentProject.GetArticlesCollection())
            {
                TreeNode child = new TreeNode(x.id.ToString());
                root.Nodes.Add(child);
            }
            treeArticle.Nodes.Add(root);
            treeArticle.ExpandAll();

            // update surveys
            treeQuestions.Nodes.Clear();
            root = new TreeNode("All Surveys");
            foreach (Dictionary<string, QuestionCollection> item in Program.currentProject.GetSurveysCollection())
            {
                TreeNode child = new TreeNode("Servey");
                foreach (QuestionCollection qc in item.Values)
                {
                    TreeNode child2 = new TreeNode("Language RTL:"+(qc.rtl==true?"Yes":"No"));
                    foreach (Question q in qc.questions)
                    {
                        TreeNode child3 = new TreeNode(q.title);
                        child2.Nodes.Add(child3);
                    }
                    child.Nodes.Add(child2);
                }
                root.Nodes.Add(child);
            }
            treeQuestions.Nodes.Add(root);
            treeQuestions.ExpandAll();
            //treeProject.EndUpdate();
        }

        private void frmSenarioMaker_Activated(object sender, EventArgs e)
        {


        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close project:  " + Program.currentProject.GetTitle() + "  ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.parent.Show();
                this.Hide();
                Program.currentProject = null;
                Program.mcmFile = null;
                parent.btnNewProject_Click(sender, e);
                this.Dispose();
            }
           // MessageBox.Show(Program.currentProject.FindLastPlaylistID().ToString());
        }

        private void treeProject_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                int id = Convert.ToInt32(e.Node.Text);
                // find current playist in memory
                MusicPlaylist existPlaylist = Program.currentProject.FindPlaylistWithID(id);
                //find all additional data for the given playlist id
                Dictionary<string, MusicPlaylist> nonEngData = Program.currentProject.ReadPlaylistNonEnglishData(id);
                frmAddPlaylist newPllstDlg = new frmAddPlaylist(existPlaylist, false,nonEngData);
                newPllstDlg.Text = "Edit Playlist";
                if (newPllstDlg.ShowDialog(this) == DialogResult.OK)
                {
                    //newPlaylist.id = Program.currentProject.FindLastPlaylistID();
                    //Program.currentProject.AddPlaylist(existPlaylist);
                    if (newPllstDlg.nonEngAdditionalData.Count > 0)
                        Program.currentProject.SavePlaylistsNonEnglishData(newPllstDlg.nonEngAdditionalData);
                    this.ApplyChangesOnHardDrive();
                }
                this.UpdateTreesPresentation();
            }
        }

        private void frmSenarioMaker_FormClosed(object sender, FormClosedEventArgs e)
        {
            toolStripButton9_Click(sender, e);
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            int id = Program.currentProject.FindLastMovieID();
            MovieFile newMovie = new MovieFile(id);
            frmAddMovie newPllstDlg = new frmAddMovie(newMovie, true);
            if (newPllstDlg.ShowDialog(this) == DialogResult.OK)
            {
                //newPlaylist.id = Program.currentProject.FindLastPlaylistID();
                Program.currentProject.AddMovie(newMovie);
                if (newPllstDlg.nonEngAdditionalData.Count > 0)
                    Program.currentProject.SaveMoviesNonEnglishData(newPllstDlg.nonEngAdditionalData);
                this.ApplyChangesOnHardDrive();
            }
            this.UpdateTreesPresentation();
        }

        private void treeMovies_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                int id = Convert.ToInt32(e.Node.Text);
                MovieFile existMovie = Program.currentProject.FindMovieWithID(id);
                frmAddMovie newMovDlg = new frmAddMovie(existMovie, false);
                newMovDlg.Text = "Edit Movie";
                if (newMovDlg.ShowDialog(this) == DialogResult.OK)
                {
                    //newPlaylist.id = Program.currentProject.FindLastPlaylistID();
                    //Program.currentProject.AddMovie(existMovie);
                    if (newMovDlg.nonEngAdditionalData.Count > 0)
                        Program.currentProject.SaveMoviesNonEnglishData(newMovDlg.nonEngAdditionalData);
                    this.ApplyChangesOnHardDrive();
                }
                this.UpdateTreesPresentation();
            }
        }

        private void btnAddAnnounc_Click(object sender, EventArgs e)
        {
            int id = Program.currentProject.FindLastAnnouncID();
            MovieFile newMovie = new MovieFile(id);
            frmAddMovie newAnnDlg = new frmAddMovie(newMovie, true);
            newAnnDlg.Text = "Add Announcement";
            if (newAnnDlg.ShowDialog(this) == DialogResult.OK)
            {
                //newPlaylist.id = Program.currentProject.FindLastPlaylistID();
                Program.currentProject.AddAnnouncement(newMovie);
                if (newAnnDlg.nonEngAdditionalData.Count > 0)
                    Program.currentProject.SaveAnnouncesNonEnglishData(newAnnDlg.nonEngAdditionalData);
                this.ApplyChangesOnHardDrive();
            }
            this.UpdateTreesPresentation();
        }

        private void treeAnnounc_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                int id = Convert.ToInt32(e.Node.Text);
                MovieFile existMovie = Program.currentProject.FindAnnouncWithID(id);
                frmAddMovie existMovDlg = new frmAddMovie(existMovie, false);
                existMovDlg.Text = "Edit Announcement";
                if (existMovDlg.ShowDialog(this) == DialogResult.OK)
                {
                    //newPlaylist.id = Program.currentProject.FindLastPlaylistID();
                    //Program.currentProject.AddMovie(existMovie);
                    if (existMovDlg.nonEngAdditionalData.Count > 0)
                        Program.currentProject.SaveAnnouncesNonEnglishData(existMovDlg.nonEngAdditionalData);
                    this.ApplyChangesOnHardDrive(); ;
                }
                this.UpdateTreesPresentation();
            }
        }

        private void btnAddArticle_Click(object sender, EventArgs e)
        {
            int id = Program.currentProject.FindLastArticleID();
            ArticleFile newArticle = new ArticleFile(id);
            frmAddArticle newArtDlg = new frmAddArticle(newArticle, true);
            newArtDlg.Text = "Add Article";
            if (newArtDlg.ShowDialog(this) == DialogResult.OK)
            {
                //newPlaylist.id = Program.currentProject.FindLastPlaylistID();
                Program.currentProject.AddArticle(newArticle);
                if (newArtDlg.nonEngAdditionalData.Count > 0)
                    Program.currentProject.SaveArticlesNonEnglishData(newArtDlg.nonEngAdditionalData);
                this.ApplyChangesOnHardDrive();
            }
            this.UpdateTreesPresentation();
        }

        private void treeArticle_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                int id = Convert.ToInt32(e.Node.Text);
                ArticleFile existArt = Program.currentProject.FindArticleWithID(id);
                frmAddArticle existArtDlg = new frmAddArticle(existArt, false);
                existArtDlg.Text = "Edit Article";
                if (existArtDlg.ShowDialog(this) == DialogResult.OK)
                {
                    //newPlaylist.id = Program.currentProject.FindLastPlaylistID();
                    //Program.currentProject.AddMovie(existMovie);
                    if (existArtDlg.nonEngAdditionalData.Count > 0)
                        Program.currentProject.SaveArticlesNonEnglishData(existArtDlg.nonEngAdditionalData);
                   this.ApplyChangesOnHardDrive();
                }
                this.UpdateTreesPresentation();
            }
        }

        private void btnAddSurvey_Click(object sender, EventArgs e)
        {
            frmAddSurvey newAddServey = new frmAddSurvey();
            if (newAddServey.ShowDialog(this) == DialogResult.OK)
            {
                Program.currentProject.AddSurvey(newAddServey.QuestionCollection);
                this.ApplyChangesOnHardDrive();
            }
            this.UpdateTreesPresentation();
            
        }

        private void treeQuestions_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Level==1)
            {
                int index = e.Node.Index;
                Dictionary<string, QuestionCollection> toEdit = Program.currentProject.GetSurvey(index);
                frmAddSurvey newAddServey = new frmAddSurvey(toEdit);
                newAddServey.Text = "Edit Survey";
                if (newAddServey.ShowDialog(this) == DialogResult.OK)
                {
                    //Program.currentProject.AddSurvey(newAddServey.QuestionCollection);
                    this.ApplyChangesOnHardDrive();
                }
                this.UpdateTreesPresentation();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            frmExport newExport = new frmExport();
            if(newExport.ShowDialog(this)==DialogResult.OK)
            {
                Program.currentProject = new ProjectFolder(Program.mcmFile);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    }
}
