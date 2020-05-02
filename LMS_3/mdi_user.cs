using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS_3
{
    public partial class mdi_user : Form
    {
        private int childFormNumber = 0;

        public mdi_user()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void mdi_user_Load(object sender, EventArgs e)
        {
           
        }

        private void addNewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_books ab = new add_books();
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(ab);
            ab.Show();
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view_books vb = new view_books();
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(vb);
            vb.Show();

        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_student_info asi = new add_student_info();
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(asi);
            asi.Show();

        }

        private void viewStudentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view_student_info vsi = new view_student_info();
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(vsi);
            vsi.Show();

        }

        private void addFacultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_faculty_info afi = new add_faculty_info();
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(afi);
            afi.Show();
        }

        private void viewFacultyInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view_faculty_info vfi = new view_faculty_info();
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(vfi);
            vfi.Show();

        }

        private void issueBooksToStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            issue_books ib = new issue_books();
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(ib);
            ib.Show();
        }

        private void issueBooksToFacultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            issue_books_faculty ibf = new issue_books_faculty();
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(ibf);
            ibf.Show();
        }

        private void returnBooksStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            return_books rb = new return_books();
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(rb);
            rb.Show();
        }

        private void returnBooksFacultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            return_books_faculty rbf = new return_books_faculty();
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(rbf);
            rbf.Show();
        }

        private void booksRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            books_stock bs = new books_stock();
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(bs);
            bs.Show();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            add_books ab = new add_books();
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(ab);
            ab.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            view_books vb = new view_books();
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(vb);
            vb.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            issue_books ib = new issue_books();
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(ib);
            ib.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            issue_books_faculty ibf = new issue_books_faculty();
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(ibf);
            ibf.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            return_books rb = new return_books();
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(rb);
            rb.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {

            return_books_faculty rbf = new return_books_faculty();
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(rbf);
            rbf.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {

            books_stock bs = new books_stock();
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(bs);
            bs.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            add_student_info asi = new add_student_info();
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(asi);
            asi.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            view_student_info vsi = new view_student_info();
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(vsi);
            vsi.Show();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            add_faculty_info afi = new add_faculty_info();
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(afi);
            afi.Show();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            view_faculty_info vfi = new view_faculty_info();
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(vfi);
            vfi.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login lg = new login();
            this.Hide();
            lg.Show();
            
        }
    }
}
