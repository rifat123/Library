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
using System.Web;
using System.Net.Mail;
using System.Net;

namespace LMS_3
{
    public partial class books_stock : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\rifat\Documents\LMS_3.mdf;Integrated Security=True;Connect Timeout=30");
      
        public books_stock()
        {
            TopLevel = false;
            InitializeComponent();
        }

        private void books_stock_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
            fill_books_info();
            fill_faculty();
            //fill_student_info();
        }

        public void fill_books_info()
        {

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select books_name,books_author_name,books_quantity,available_qty from books_info";

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        
        }
        public void fill_faculty()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from issue_books_faculty";

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView3.DataSource = dt;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            string i;
            i = dataGridView1.SelectedCells[0].Value.ToString();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from issue_books where books_name = '"+i.ToString()+"' and book_return_date = ''", con);
            da.Fill(dt);
            dataGridView2.DataSource = dt;

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from issue_books_faculty where books_name = '" + i.ToString() + "' and book_return_date = ''", con);
            da1.Fill(dt1);
            dataGridView3.DataSource = dt1;
        }

      

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select books_name,books_author_name,books_quantity,available_qty from books_info where books_name like ('%"+textBox1.Text+"%')";

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        
        }

       /* private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string i;
            i = dataGridView2.SelectedCells[6].Value.ToString();

            textBox2.Text = i.ToString();

        }*/

        /*private void button1_Click(object sender, EventArgs e)
        {


            MailMessage mail = new MailMessage("rifat.hasan55511@gmail.com", textBox2.Text, "Please Return the book", textBox3.Text);
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("rifat.hasan55511@gmail.com","rifat55511");
            client.EnableSsl = true;
            client.Send(mail);
            MessageBox.Show("Sent");

//            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
  //          smtp.EnableSsl = true;
    //        smtp.UseDefaultCredentials = false;
      //      smtp.Credentials = new NetworkCredential("rifat.hasan55511@gmail.com", "rifat55511");
        //    MailMessage mail = new MailMessage("rifat.hasan55511@gmail.com", textBox2.Text, "Please Return the book", textBox3.Text);
          //  mail.Priority = MailPriority.High;
            //smtp.Send(mail);
            //MessageBox.Show("Mail Has Been Sent");


        } */
    }
}
