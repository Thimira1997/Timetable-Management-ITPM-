using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DakHome
{
    public partial class StudentGroupUpdate : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public StudentGroupUpdate()
        {
            InitializeComponent();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                con.Open();
                SqlDataAdapter sad = new SqlDataAdapter("SELECT *FROM Student WHERE subgroupId = '" + comboBox7.Text + "' ", con);
                DataTable dt = new DataTable();
                _ = sad.Fill(dt);

                dataGridView1.DataSource = dt;
            }

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Student where subgroupId = '" + comboBox7.Text + "'";
            cmd.Connection = con;
            SqlDataReader datareder;
            datareder = cmd.ExecuteReader();
            bool temp = false;
            while (datareder.Read())
            {
                comboBox1.Text = datareder.GetString(3);
                comboBox4.Text = datareder.GetString(4);
                comboBox3.Text = datareder.GetString(5);
                comboBox2.Text = datareder.GetString(6);
                textBox1.Text = datareder.GetString(1);
                textBox2.Text = datareder.GetString(2);

                temp = true;
            }
            if (temp == false)
            {
                MessageBox.Show("Not Found");
            }
            con.Close();
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from Student", con);
            da.Fill(ds, "Student");
            con.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String grpid = comboBox1.Text.Trim() + "." + comboBox3.Text.Trim() + "(" + comboBox4.Text.Trim() + ")";
            String subgrpid = comboBox1.Text.Trim() + "." + comboBox3.Text.Trim() + "." + comboBox2.Text.Trim() + "(" + comboBox4.Text.Trim()+")";

            textBox1.Text = grpid;
            textBox2.Text = subgrpid;
        }

        private void StudentGroupUpdate_Load(object sender, EventArgs e)
        {
            LodingCombo();
        }

        public void LodingCombo()
        {
            SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            comboBox7.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT  groupId,subgroupId FROM Student";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox7.Items.Add(dr["subgroupId"].ToString());
            }

            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            

            string constring = @"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string query = "update Student set groupId = '" + this.textBox1.Text + "', subgroupId = '" + this.textBox2.Text + "',yearsem ='" + this.comboBox1.Text + "',program = '" + this.comboBox4.Text + "',grpno = '" + this.comboBox3.Text + "',subgrpno = '" + this.comboBox2.Text + "'  where  subgroupId = '" + this.comboBox7.Text + "';";
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                MessageBox.Show("Update Saved...");
                while (reader.Read())
                {

                }

            }
            catch (Exception)
            {
                MessageBox.Show("ex.Message");
            }
            con.Close();

            using (SqlConnection conn = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                conn.Open();
                SqlDataAdapter sad = new SqlDataAdapter("SELECT *FROM Student WHERE subgroupId = '" + textBox2.Text + "' ", con);
                DataTable dt = new DataTable();
                _ = sad.Fill(dt);

                dataGridView1.DataSource = dt;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
