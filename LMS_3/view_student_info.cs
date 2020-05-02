﻿using System;
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
    public partial class view_student_info : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\rifat\Documents\LMS_3.mdf;Integrated Security=True;Connect Timeout=30");
       
        //string pwd = Class1.GetRandomPassword(20);
       // int i = 0;
        string wanted_path;
        string pwd = Class1.GetRandomPassword(20);
        DialogResult result;

        public view_student_info()
        {
            TopLevel = false;
            InitializeComponent();
        }

        private void view_student_info_Load(object sender, EventArgs e)
        {

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
            cmd.CommandText = "select * from student_info";
            
              //  con.Open();
                
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            Bitmap img;
            DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
            imageCol.Width = 500;
            imageCol.HeaderText = "Student Images";
            imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imageCol.Width = 100;
            dataGridView1.Columns.Add(imageCol);
            foreach (DataRow dr in dt.Rows)
            {
                //  img = new Bitmap(@"..\..\"+dr["student_image"]).ToString());
                //
                //img = new Bitmap(@"..\..\"+dr["student_image"].);
                img = new Bitmap(@"..\..\" + dr["student_image"].ToString());
                dataGridView1.Rows[i].Cells[8].Value = img;

                dataGridView1.Rows[i].Height = 100;
                i = i + 1;

            }
              //  con.Close();
        } 
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try {

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
               // con.Open();
                cmd.CommandText = "select * from student_info where student_name like ('%"+textBox1.Text+"%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                Bitmap img;
                DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                imageCol.Width = 500;
                imageCol.HeaderText = "Student Images";
                imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imageCol.Width = 100;
                dataGridView1.Columns.Add(imageCol);
                foreach (DataRow dr in dt.Rows)
                {
                    //  img = new Bitmap(@"..\..\"+dr["student_image"]).ToString());
                    //
                    //img = new Bitmap(@"..\..\"+dr["student_image"].);
                    img = new Bitmap(@"..\..\" + dr["student_image"].ToString());
                    dataGridView1.Rows[i].Cells[8].Value = img;

                    dataGridView1.Rows[i].Height = 100;
                    i = i + 1;

                }
              //  con.Close();
            }

             catch(Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;

            string id = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from student_info where id = "+id+"";
          //  con.Open();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
           // dataGridView1.DataSource = dt;
            foreach (DataRow dr in dt.Rows)
            {

                student_name.Text = dr["student_name"].ToString();
                student_enroll.Text = dr["student_enrollment_no"].ToString();
                student_dept.Text = dr["student_department"].ToString();
                student_sem.Text = dr["student_sem"].ToString();
                student_contact.Text = dr["student_contact"].ToString();
                student_email.Text = dr["student_email"].ToString();


            }
           // con.Close();
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

                File.Copy(openFileDialog1.FileName, wanted_path + "\\student_images\\" + pwd + ".jpg");
                img_path = "student_images\\" + pwd + ".jpg";

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update student_info set student_name = '"+student_name.Text+"',student_image = '"+img_path.ToString()+"',student_enrollment_no = '"+student_enroll.Text+"',student_department = '"+student_dept.Text+"',student_sem = '"+student_sem.Text+"',student_contact = '"+student_contact.Text+"',student_email = '"+student_email.Text+"'where id = "+i+"";
             //   con.Open();
                cmd.ExecuteNonQuery();
                fill_grid();
                MessageBox.Show("Record Updated Successfully");
               // con.Close();
            }
            else if(result==DialogResult.Cancel)
            {
                int i;
                i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update student_info set student_name = '" + student_name.Text + "',student_enrollment_no = '" + student_enroll.Text + "',student_department = '" + student_dept.Text + "',student_sem = '" + student_sem.Text + "',student_contact = '" + student_contact.Text + "',student_email = '" + student_email.Text + "'where id = " + i + "";
              //  con.Open();
                cmd.ExecuteNonQuery();
                fill_grid();
                MessageBox.Show("Record Updated Successfully");
                //con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;

            string id = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();

            SqlCommand cmd = new SqlCommand("DELETE FROM STUDENT_INFO WHERE ID = '" + id + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Student Deleted !!");
            con.Close();
            fill_grid();
           // disp_books();
        }
    }
}
