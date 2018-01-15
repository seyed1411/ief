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
        string RightclickedItemLabel;

        public frmSenarioMaker(Form1 _parent)
        {
            parent = _parent;
            InitializeComponent();
        }

        private void btnCloseProject_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close project:  " + Program.currentProject.GetTitle() + "  ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
        private void frmSenarioMaker_FormClosed(object sender, FormClosedEventArgs e)
        {


        }
        private void btnNewProject_Click(object sender, EventArgs e)
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
        }

        private void btnAddPlaylist_Click(object sender, EventArgs e)
        {
            int id = Program.currentProject.FindLastPlaylistID();
            MusicPlaylist newPlaylist = new MusicPlaylist(id);
            frmAddPlaylist newPllstDlg = new frmAddPlaylist(newPlaylist, true, null);
            if (newPllstDlg.ShowDialog(this) == DialogResult.OK)
            {
                Program.currentProject.AddPlaylist(newPlaylist);
                if (newPllstDlg.nonEngAdditionalData.Count > 0)
                    Program.currentProject.SavePlaylistsNonEnglishData(newPllstDlg.nonEngAdditionalData);
                this.ApplyChangesOnHardDrive();
            }
            this.UpdateTreesPresentation();

        }

        private void EditPlaylistWithID(string _id)
        {
            int id = Convert.ToInt32(_id);
            // find current playist in memory
            MusicPlaylist existPlaylist = Program.currentProject.FindPlaylistWithID(id);
            //find all additional data for the given playlist id
            Dictionary<string, MusicPlaylist> nonEngData = Program.currentProject.ReadPlaylistNonEnglishData(id);
            frmAddPlaylist newPllstDlg = new frmAddPlaylist(existPlaylist, false, nonEngData);
            newPllstDlg.Text = "Edit Playlist";
            if (newPllstDlg.ShowDialog(this) == DialogResult.OK)
            {
                if (newPllstDlg.nonEngAdditionalData.Count > 0)
                    Program.currentProject.SavePlaylistsNonEnglishData(newPllstDlg.nonEngAdditionalData);
                this.ApplyChangesOnHardDrive();
            }
            this.UpdateTreesPresentation();
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            int id = Program.currentProject.FindLastMovieID();
            MovieFile newMovie = new MovieFile(id);
            frmAddMovie newMovDlg = new frmAddMovie(newMovie, true, null);
            if (newMovDlg.ShowDialog(this) == DialogResult.OK)
            {
                Program.currentProject.AddMovie(newMovie);
                if (newMovDlg.nonEngAdditionalData.Count > 0)
                    Program.currentProject.SaveMoviesNonEnglishData(newMovDlg.nonEngAdditionalData);
                this.ApplyChangesOnHardDrive();
            }
            this.UpdateTreesPresentation();
        }

        private void EditMovieWithId(string _id)
        {
            int id = Convert.ToInt32(_id);
            // find current movie in memory
            MovieFile existMov = Program.currentProject.FindMovieWithID(id);
            // find all additional data for the given movie id
            Dictionary<string, MovieFile> nonEngData = Program.currentProject.ReadMovieNonEnglishData(id);
            frmAddMovie newMovDlg = new frmAddMovie(existMov, false, nonEngData);
            newMovDlg.Text = "Edit Movie";
            if (newMovDlg.ShowDialog(this) == DialogResult.OK)
            {
                if (newMovDlg.nonEngAdditionalData.Count > 0)
                    Program.currentProject.SaveMoviesNonEnglishData(newMovDlg.nonEngAdditionalData);
                this.ApplyChangesOnHardDrive();
            }
            this.UpdateTreesPresentation();
        }

        private void btnAddAnnounc_Click(object sender, EventArgs e)
        {
            int id = Program.currentProject.FindLastAnnouncID();
            MovieFile newMovie = new MovieFile(id);
            frmAddMovie newAnnDlg = new frmAddMovie(newMovie, true, null);
            newAnnDlg.Text = "Add Announcement";
            if (newAnnDlg.ShowDialog(this) == DialogResult.OK)
            {
                Program.currentProject.AddAnnouncement(newMovie);
                if (newAnnDlg.nonEngAdditionalData.Count > 0)
                    Program.currentProject.SaveAnnouncesNonEnglishData(newAnnDlg.nonEngAdditionalData);
                this.ApplyChangesOnHardDrive();
            }
            this.UpdateTreesPresentation();
        }

        private void EditAnnounceWithID(string _id)
        {
            int id = Convert.ToInt32(_id);
            // find current announcement in memory
            MovieFile existAnn = Program.currentProject.FindAnnouncWithID(id);
            // find all additional data for the given announcement id
            Dictionary<string, MovieFile> nonEngData = Program.currentProject.ReadAnnouncNonEnglishData(id);
            frmAddMovie existAnnDlg = new frmAddMovie(existAnn, false, nonEngData);
            existAnnDlg.Text = "Edit Announcement";
            if (existAnnDlg.ShowDialog(this) == DialogResult.OK)
            {
                if (existAnnDlg.nonEngAdditionalData.Count > 0)
                    Program.currentProject.SaveAnnouncesNonEnglishData(existAnnDlg.nonEngAdditionalData);
                this.ApplyChangesOnHardDrive(); ;
            }
            this.UpdateTreesPresentation();
        }

        private void btnAddArticle_Click(object sender, EventArgs e)
        {
            int id = Program.currentProject.FindLastArticleID();
            ArticleFile newArticle = new ArticleFile(id);
            frmAddArticle newArtDlg = new frmAddArticle(newArticle, true, null);
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

        private void EditArticleWithID(string _id)
        {
            int id = Convert.ToInt32(_id);
            ArticleFile existArt = Program.currentProject.FindArticleWithID(id);
            // find all additional data for the given announcement id
            Dictionary<string, ArticleFile> nonEngData = Program.currentProject.ReadArticleNonEnglishData(id);
            frmAddArticle existArtDlg = new frmAddArticle(existArt, false, nonEngData);
            existArtDlg.Text = "Edit Article";
            if (existArtDlg.ShowDialog(this) == DialogResult.OK)
            {
                if (existArtDlg.nonEngAdditionalData.Count > 0)
                    Program.currentProject.SaveArticlesNonEnglishData(existArtDlg.nonEngAdditionalData);
                this.ApplyChangesOnHardDrive();
            }
            this.UpdateTreesPresentation();
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

        private void EditSurveyWithID(int _index)
        {
            int index = _index;
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            // return if nothing added to project
            if (Program.currentProject.IsEmpty())
            {
                MessageBox.Show("There is no content added to project. Please add some items first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            frmExport newExport = new frmExport();
            if (newExport.ShowDialog(this) == DialogResult.OK)
            {
                Program.currentProject = new ProjectFolder(Program.mcmFile);
            }
        }

        private void playlistGeneresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageGenre newDlg = new frmManageGenre("Audios");
            newDlg.ShowDialog(this);
        }

        private void videoGenresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageGenre newDlg = new frmManageGenre("Videos");
            newDlg.ShowDialog(this);
        }

        private void articleGenresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageGenre newDlg = new frmManageGenre("Articles");
            newDlg.ShowDialog(this);
        }

        private void frmSenarioMaker_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close project:  " + Program.currentProject.GetTitle() + "  ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.parent.Show();
                this.Hide();
                Program.currentProject = null;
                Program.mcmFile = null;
                this.Dispose();
            }
            else
                e.Cancel = true;
        }

        // other methods
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
                TreeNode child = new TreeNode("[" + x.id.ToString() + "] - " + x.title);
                foreach (MusicFile y in x.GetMusicFilesInfo())
                {
                    TreeNode child2 = new TreeNode(y.title);
                    child.Nodes.Add(child2);
                }
                root.Nodes.Add(child);
            }
            root.Expand();
            treePlaylists.Nodes.Add(root);
            //treePlaylists.ExpandAll();

            // update movies
            treeMovies.Nodes.Clear();
            root = new TreeNode("Movies");
            foreach (MovieFile x in Program.currentProject.GetMoviesCollection())
            {
                TreeNode child = new TreeNode("[" + x.id.ToString() + "] - " + x.title);
                root.Nodes.Add(child);
            }
            treeMovies.Nodes.Add(root);
            treeMovies.ExpandAll();

            // update announcements
            treeAnnounc.Nodes.Clear();
            root = new TreeNode("Announcements");
            foreach (MovieFile x in Program.currentProject.GetAnnouncesCollection())
            {
                TreeNode child = new TreeNode("[" + x.id.ToString() + "] - " + x.title);
                root.Nodes.Add(child);
            }
            treeAnnounc.Nodes.Add(root);
            treeAnnounc.ExpandAll();

            // update articles
            treeArticle.Nodes.Clear();
            root = new TreeNode("Articles");
            foreach (ArticleFile x in Program.currentProject.GetArticlesCollection())
            {
                TreeNode child = new TreeNode("[" + x.id.ToString() + "] - " + x.title);
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
                    TreeNode child2 = new TreeNode("Language RTL:" + (qc.rtl == true ? "Yes" : "No"));
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

        private void mnuButEdit_Click(object sender, EventArgs e)
        {
            string nodeId = ExtractIDFromNodeLabel(this.RightclickedItemLabel);
            if (nodeId != null)
            {
                if (tabs.SelectedTab == tabPlaylists)
                    EditPlaylistWithID(nodeId);
                else if (tabs.SelectedTab == tabMovies)
                    EditMovieWithId(nodeId);
                else if (tabs.SelectedTab == tabAnnounc)
                    EditAnnounceWithID(nodeId);
                else if (tabs.SelectedTab == tabArticles)
                    EditAnnounceWithID(nodeId);
                else if (tabs.SelectedTab == tabSurvey)
                    EditSurveyWithID(Convert.ToInt32(RightclickedItemLabel));
            }

        }

        private string ExtractIDFromNodeLabel(string _label)
        {
            if (_label != null)
            {
                string ret = _label.Split(']')[0];
                ret = ret.Remove(0, 1);
                return ret;
            }
            return null;
        }

        private void mnuButRemove_Click(object sender, EventArgs e)
        {
            string nodeId = ExtractIDFromNodeLabel(this.RightclickedItemLabel);
            if (nodeId != null)
            {
                if (tabs.SelectedTab == tabPlaylists)
                    RemovePlaylistWithID(nodeId);
                else if (tabs.SelectedTab == tabMovies)
                    RemoveMovieWithId(nodeId);
                else if (tabs.SelectedTab == tabAnnounc)
                    RemoveAnnounceWithID(nodeId);
                else if (tabs.SelectedTab == tabArticles)
                    RemoveArticleWithID(nodeId);
                else if (tabs.SelectedTab == tabSurvey)
                    RemoveSurveyWithIndex(Convert.ToInt32(RightclickedItemLabel));
            }
        }

        private void RemoveSurveyWithIndex(int _index)
        {
            if (MessageBox.Show("Are you sure you want to delete survey number: " + RightclickedItemLabel, "Delete Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // find current playist in memory
                Program.currentProject.RemoveSurveyWithIndex(_index);
                this.ApplyChangesOnHardDrive();
                this.UpdateTreesPresentation();
            }
        }

        private void RemoveArticleWithID(string _id)
        {
            if (MessageBox.Show("Are you sure you want to delete article: " + RightclickedItemLabel, "Delete Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // find current playist in memory
                int id = Convert.ToInt32(_id);
                Program.currentProject.RemoveArticleWithID(id);
                this.ApplyChangesOnHardDrive();
                this.UpdateTreesPresentation();
            }
        }

        private void RemoveAnnounceWithID(string _id)
        {
            if (MessageBox.Show("Are you sure you want to delete announcement: " + RightclickedItemLabel, "Delete Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // find current playist in memory
                int id = Convert.ToInt32(_id);
                Program.currentProject.RemoveAnnouncWithID(id);
                this.ApplyChangesOnHardDrive();
                this.UpdateTreesPresentation();
            }
        }

        private void RemoveMovieWithId(string _id)
        {
            if (MessageBox.Show("Are you sure you want to delete movie: " + RightclickedItemLabel, "Delete Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // find current playist in memory
                int id = Convert.ToInt32(_id);
                Program.currentProject.RemoveMovietWithID(id);
                this.ApplyChangesOnHardDrive();
                this.UpdateTreesPresentation();
            }
        }

        private void RemovePlaylistWithID(string _id)
        {
            if (MessageBox.Show("Are you sure you want to delete playlist: " + RightclickedItemLabel, "Delete Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // find current playist in memory
                int id = Convert.ToInt32(_id);
                Program.currentProject.RemovePlaylistWithID(id);
                this.ApplyChangesOnHardDrive();
                this.UpdateTreesPresentation();
            }
        }

        private void treePlaylists_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    //clickedNode = e.Node.Name;
                    this.RightclickedItemLabel = e.Node.Text;
                    mnuRightClick.Show(treePlaylists, e.Location);
                }
            }
            else
                this.RightclickedItemLabel = null;
        }

        private void treeMovies_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    //clickedNode = e.Node.Name;
                    this.RightclickedItemLabel = e.Node.Text;
                    mnuRightClick.Show(treeMovies, e.Location);
                }
            }
            else
                this.RightclickedItemLabel = null;
        }

        private void treeAnnounc_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    //clickedNode = e.Node.Name;
                    this.RightclickedItemLabel = e.Node.Text;
                    mnuRightClick.Show(treeAnnounc, e.Location);
                }
            }
            else
                this.RightclickedItemLabel = null;
        }

        private void treeArticle_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    //clickedNode = e.Node.Name;
                    this.RightclickedItemLabel = e.Node.Text;
                    mnuRightClick.Show(treeArticle, e.Location);
                }
            }
            else
                this.RightclickedItemLabel = null;
        }

        private void treeQuestions_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    //clickedNode = e.Node.Name;
                    this.RightclickedItemLabel = e.Node.Index.ToString();
                    mnuRightClick.Show(treeQuestions, e.Location);
                }
            }
            else
                this.RightclickedItemLabel = null;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (TreeNode node in treePlaylists.Nodes[0].Nodes)
            {
                MusicPlaylist toSearch = Program.currentProject.FindPlaylistWithID(Convert.ToInt32(ExtractIDFromNodeLabel(node.Text)));
                if (toSearch.description.ToLower().Contains(textBox1.Text.ToLower()) ||
                    toSearch.id.ToString().ToLower().Contains(textBox1.Text.ToLower()) ||
                    toSearch.title.ToLower().Contains(textBox1.Text.ToLower()))
                {
                    treePlaylists.Nodes[0].Nodes.Clear();
                    treePlaylists.Nodes[0].Nodes.Add(node);
                    return;
                }
            }
            UpdateTreesPresentation();
            return;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            foreach (TreeNode node in treeMovies.Nodes[0].Nodes)
            {
                MovieFile toSearch = Program.currentProject.FindMovieWithID(Convert.ToInt32(ExtractIDFromNodeLabel(node.Text)));
                if (toSearch.description.ToLower().Contains(textBox1.Text.ToLower()) ||
                    toSearch.id.ToString().ToLower().Contains(textBox1.Text.ToLower()) ||
                    toSearch.title.ToLower().Contains(textBox1.Text.ToLower()))
                {
                    treePlaylists.Nodes[0].Nodes.Clear();
                    treePlaylists.Nodes[0].Nodes.Add(node);
                    return;
                }
            }
            UpdateTreesPresentation();
            return;

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            foreach (TreeNode node in treeAnnounc.Nodes[0].Nodes)
            {
                MovieFile toSearch = Program.currentProject.FindMovieWithID(Convert.ToInt32(ExtractIDFromNodeLabel(node.Text)));
                if (toSearch.description.ToLower().Contains(textBox1.Text.ToLower()) ||
                    toSearch.id.ToString().ToLower().Contains(textBox1.Text.ToLower()) ||
                    toSearch.title.ToLower().Contains(textBox1.Text.ToLower()))
                {
                    treePlaylists.Nodes[0].Nodes.Clear();
                    treePlaylists.Nodes[0].Nodes.Add(node);
                    return;
                }
            }
            UpdateTreesPresentation();
            return;
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            foreach (TreeNode node in treeArticle.Nodes[0].Nodes)
            {
                ArticleFile toSearch = Program.currentProject.FindArticleWithID(Convert.ToInt32(ExtractIDFromNodeLabel(node.Text)));
                if (toSearch.description.ToLower().Contains(textBox1.Text.ToLower()) ||
                    toSearch.id.ToString().ToLower().Contains(textBox1.Text.ToLower()) ||
                    toSearch.title.ToLower().Contains(textBox1.Text.ToLower()))
                {
                    treePlaylists.Nodes[0].Nodes.Clear();
                    treePlaylists.Nodes[0].Nodes.Add(node);
                    return;
                }
            }
                UpdateTreesPresentation();
                return;
        }
            
        
    }
}
