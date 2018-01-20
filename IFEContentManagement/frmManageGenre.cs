using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace IFEContentManagement
{
    public partial class frmManageGenre : Form
    {
        SQLiteConnection mConn;
        SQLiteDataAdapter mAdapter;
        DataTable mTable;
        string TableName;

        public frmManageGenre(string _tableName)
        {
            InitializeComponent();
            TableName = _tableName;
        }

        private void frmManageGenre_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Manage " + TableName + " Genres";
                textBox1.Focus();
                string mDbPath = Application.StartupPath + "/genres.db";

                // If DB Not Exists, it will be created.
                mConn = new SQLiteConnection("Data Source=" + mDbPath);
                mConn.Open();
                // a genre column for id of genre and:
                // for each Language we create a column and enter data but it is optional for all languages
                using (SQLiteCommand mCmd = new SQLiteCommand(string.Format("CREATE TABLE IF NOT EXISTS [{0}]" +
                    "('Genre' TEXT PRIMARY KEY, 'English' TEXT, 'Farsi' TEXT,'Arabic' TEXT," +
                    "'Spanish' TEXT,'French' TEXT, 'Russian' TEXT, 'Chinese' TEXT, 'Hindi' TEXT, 'German' TEXT);", TableName), mConn))
                {
                    mCmd.ExecuteNonQuery();
                }
                mAdapter = new SQLiteDataAdapter("SELECT * FROM [" + TableName + "]", mConn);
                mTable = new DataTable(); // Don't forget initialize!
                mAdapter.Fill(mTable);
                if (mTable.Columns.Contains("Genre"))
                {
                    mTable.Columns["Genre"].ReadOnly = true;
                }
                new SQLiteCommandBuilder(mAdapter);
                dataGridView1.DataSource = mTable;
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                }
            }
            catch (Exception exp)
            {
                Program.ShowExceptionData(exp);
            }
        }

        private void frmManageGenre_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                textBox1.Focus();
                if (mAdapter == null) // If No Table Was Opened.
                    return;

                mAdapter.Update(mTable);
            }
            catch (Exception exp)
            {
                Program.ShowExceptionData(exp);
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Some errors happened in data insertion or selection.", "Error", MessageBoxButtons.OK);  
        }

        private void btnNewGenre_Click(object sender, EventArgs e)
        {
            try
            {
                do
                {
                    frmInputBox inp = new frmInputBox("Enter New " + TableName + " Genre:");
                    if (inp.ShowDialog(this) == DialogResult.Cancel)
                        return;
                    else
                    {
                        DataRow toInsert = mTable.NewRow();
                        toInsert[0] = inp.Input;
                        mTable.Rows.Add(toInsert);
                        dataGridView1.DataSource = mTable;
                        return;
                    }

                } while (true);
            }
            catch (Exception exp)
            {
                Program.ShowExceptionData(exp);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    DataRow toRemove = mTable.Rows[dataGridView1.CurrentRow.Index];
                    toRemove.Delete();
                    dataGridView1.DataSource = mTable;
                }
            }
            catch (Exception exp)
            {
                Program.ShowExceptionData(exp);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = -1;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value.ToString().ToLower().Contains(textBox1.Text.ToLower()))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }
                if (rowIndex != -1)
                {
                    dataGridView1.Rows[rowIndex].Selected = true;
                }
            }
            catch (Exception exp)
            {
                Program.ShowExceptionData(exp);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = "Search";
        }
    }
}
