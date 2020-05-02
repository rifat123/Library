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


namespace LMS_3
{
    public partial class add_books : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\rifat\Documents\LMS_3.mdf;Integrated Security=True;Connect Timeout=30");
        public add_books()
        {
            TopLevel = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into books_info values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','"+dateTimePicker1.Value.ToString() +"'," + textBox5.Text + "," + textBox6.Text + "," + textBox6.Text + ")";

            cmd.ExecuteNonQuery();


            //this.Hide();
            MessageBox.Show("Added Successfylly");


            con.Close();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
           // textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            MessageBox.Show("Added Successfully");




        }

        private void add_books_Load(object sender, EventArgs e)
        {

        }
    }
}
