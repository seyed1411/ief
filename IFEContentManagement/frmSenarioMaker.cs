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
            UpdatePlaylistTreePresentation();
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
            this.UpdatePlaylistTreePresentation();

        }

        private void UpdatePlaylistTreePresentation()
        {
            //treeProject.BeginUpdate();
            treeProject.Nodes.Clear();
            TreeNode root = new TreeNode("Playlists");
            foreach (MusicPlaylist x in Program.currentProject.GetPlaylistsCollection())
            {
                TreeNode child = new TreeNode(x.id.ToString());
                root.Nodes.Add(child);
            }
            treeProject.Nodes.Add(root);
            treeProject.ExpandAll();
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

        }

        private void frmSenarioMaker_FormClosed(object sender, FormClosedEventArgs e)
        {
            toolStripButton9_Click(sender, e);
        }
        
    }
}
