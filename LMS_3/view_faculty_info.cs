using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;



namespace LMS_3
{
    public partial class view_faculty_info : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\rifat\Documents\LMS_3.mdf;Integrated Security=True;Connect Timeout=30");
      //  string pwd = Class1.GetRandomPassword(20);
        string wanted_path;
        string pwd = Class1.GetRandomPassword(20);
        DialogResult result;
        public view_faculty_info()
        {
            TopLevel = false;
            InitializeComponent();
        }

        private void view_faculty_info_Load(object sender, EventArgs e)
        {
            //int i = 0;

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            fill_grid();
            
        }

        public void fill_grid()
        {

            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from faculty_info";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            Bitmap img;
            DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
            imageCol.Width = 500;
            imageCol.HeaderText = "faculty Images";
            imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imageCol.Width = 100;
            dataGridView1.Columns.Add(imageCol);
            foreach (DataRow dr in dt.Rows)
            {

                img = new Bitmap(@"..\..\" + dr["faculty_image"].ToString());
                dataGridView1.Rows[i].Cells[8].Value = img;

                dataGridView1.Rows[i].Height = 100;
                i = i + 1;

            }  
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                dataGridView1.Columns.Clear();
                dataGridView1.Refresh();

                int i = 0;

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from faculty_info where faculty_name like ('%" + textBox1.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                Bitmap img;
                DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                imageCol.Width = 500;
                imageCol.HeaderText = "Faculty Images";
                imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imageCol.Width = 100;
                dataGridView1.Columns.Add(imageCol);
                foreach (DataRow dr in dt.Rows)
                {
                    
                    img = new Bitmap(@"..\..\" + dr["faculty_image"].ToString());
                    dataGridView1.Rows[i].Cells[8].Value = img;

                    dataGridView1.Rows[i].Height = 100;
                    i = i + 1;

                }

            }

            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from faculty_info where id = " + i + "";

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            // dataGridView1.DataSource = dt;
            foreach (DataRow dr in dt.Rows)
            {

                faculty_name.Text = dr["faculty_name"].ToString();
                //  student_name.Text = dr["student_name"].ToString();
                faculty_enroll.Text = dr["faculty_enrollment_no"].ToString();
                faculty_dept.Text = dr["faculty_department"].ToString();
                faculty_sem.Text = dr["faculty_sem"].ToString();
                faculty_contact.Text = dr["faculty_contact"].ToString();
                faculty_email.Text = dr["faculty_email"].ToString();


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            result = openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "JPEG Files(*.jpeg) |*.jpeg|PNG Files(*.png)|*.png| JPG Files (*.jpg)|*.jpg|GIF Files(*.gif)|*.gif";
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (result == DialogResult.OK)
            {
                int i;
                i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                string img_path;

                File.Copy(openFileDialog1.FileName, wanted_path + "\\faculty_images\\" + pwd + ".jpg");
                img_path = "faculty_images\\" + pwd + ".jpg";

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update faculty_info set faculty_name = '" + faculty_name.Text + "',faculty_image = '" + img_path.ToString() + "',faculty_enrollment_no = '" + faculty_enroll.Text + "',faculty_department = '" + faculty_dept.Text + "',faculty_sem = '" + faculty_sem.Text + "',faculty_contact = '" + faculty_contact.Text + "',faculty_email = '" + faculty_email.Text + "'where id = " + i + "";
                cmd.ExecuteNonQuery();
                fill_grid();

                MessageBox.Show("Record Updated Successfully");
            }
            else if (result == DialogResult.Cancel)
            {
                int i;
                i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update faculty_info set faculty_name = '" + faculty_name.Text + "',faculty_enrollment_no = '" + faculty_enroll.Text + "',faculty_department = '" + faculty_dept.Text + "',faculty_sem = '" + faculty_sem.Text + "',faculty_contact = '" + faculty_contact.Text + "',faculty_email = '" + faculty_email.Text + "'where id = " + i + "";
                cmd.ExecuteNonQuery();
                fill_grid();

                MessageBox.Show("Record Updated Successfully");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;

            string id = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();

            SqlCommand cmd = new SqlCommand("DELETE FROM FACULTY_INFO WHERE ID = '" + id + "'", con);
           // con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Student Deleted !!");
            //con.Close();
            fill_grid();
        }
    }
}
