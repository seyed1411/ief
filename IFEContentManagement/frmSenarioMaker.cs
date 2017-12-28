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
        Form parent;
        public frmSenarioMaker(Form _parent)
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
            if(MessageBox.Show("Are you sure you want to close project: "+Program.currentProject.GetTitle()+"?","Warning",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                Application.Restart();
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
            frmAddPlaylist newPllstDlg = new frmAddPlaylist(newPlaylist, true);
            if (newPllstDlg.ShowDialog(this) == DialogResult.OK)
            {
                //newPlaylist.id = Program.currentProject.FindLastPlaylistID();
                Program.currentProject.AddPlaylist(newPlaylist);
                if (newPllstDlg.nonEngAdditionalData.Count > 0)
                    Program.currentProject.SavePlaylistsNonEnglishData(newPllstDlg.nonEngAdditionalData);
                Program.currentProject.ApplyChangesOnHardDrive();
            }
            this.UpdateTreesPresentation();

        }

        private void UpdateTreesPresentation()
        {
            // update playlists
            treePlaylists.Nodes.Clear();
            TreeNode root = new TreeNode("Playlists");
            foreach (MusicPlaylist x in Program.currentProject.GetPlaylistsCollection())
            {
                TreeNode child = new TreeNode(x.id.ToString());
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
            MessageBox.Show(Program.currentProject.FindLastPlaylistID().ToString());
        }

        private void treeProject_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                int id = Convert.ToInt32(e.Node.Text);
                MusicPlaylist existPlaylist = Program.currentProject.FindPlaylistWithID(id);
                frmAddPlaylist newPllstDlg = new frmAddPlaylist(existPlaylist, false);
                if (newPllstDlg.ShowDialog(this) == DialogResult.OK)
                {
                    //newPlaylist.id = Program.currentProject.FindLastPlaylistID();
                    //Program.currentProject.AddPlaylist(existPlaylist);
                    if (newPllstDlg.nonEngAdditionalData.Count > 0)
                        Program.currentProject.SavePlaylistsNonEnglishData(newPllstDlg.nonEngAdditionalData);
                    Program.currentProject.ApplyChangesOnHardDrive();
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
                Program.currentProject.ApplyChangesOnHardDrive();
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
                if (newMovDlg.ShowDialog(this) == DialogResult.OK)
                {
                    //newPlaylist.id = Program.currentProject.FindLastPlaylistID();
                    //Program.currentProject.AddMovie(existMovie);
                    if (newMovDlg.nonEngAdditionalData.Count > 0)
                        Program.currentProject.SaveMoviesNonEnglishData(newMovDlg.nonEngAdditionalData);
                    Program.currentProject.ApplyChangesOnHardDrive();
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
                Program.currentProject.ApplyChangesOnHardDrive();
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
                if (existMovDlg.ShowDialog(this) == DialogResult.OK)
                {
                    //newPlaylist.id = Program.currentProject.FindLastPlaylistID();
                    //Program.currentProject.AddMovie(existMovie);
                    if (existMovDlg.nonEngAdditionalData.Count > 0)
                        Program.currentProject.SaveAnnouncesNonEnglishData(existMovDlg.nonEngAdditionalData);
                    Program.currentProject.ApplyChangesOnHardDrive();
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
                Program.currentProject.ApplyChangesOnHardDrive();
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
                if (existArtDlg.ShowDialog(this) == DialogResult.OK)
                {
                    //newPlaylist.id = Program.currentProject.FindLastPlaylistID();
                    //Program.currentProject.AddMovie(existMovie);
                    if (existArtDlg.nonEngAdditionalData.Count > 0)
                        Program.currentProject.SaveArticlesNonEnglishData(existArtDlg.nonEngAdditionalData);
                    Program.currentProject.ApplyChangesOnHardDrive();
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
                Program.currentProject.ApplyChangesOnHardDrive();
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
                if (newAddServey.ShowDialog(this) == DialogResult.OK)
                {
                    //Program.currentProject.AddSurvey(newAddServey.QuestionCollection);
                    Program.currentProject.ApplyChangesOnHardDrive();
                }
                this.UpdateTreesPresentation();
            }
        }
        
    }
}
