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
    public partial class SessionAdd : Form
    {
        NormalClz w = new NormalClz();

        public SessionAdd()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBox7.Text == "" || comboBox3.Text == "" || comboBox2.Text == "" || comboBox1.Text == "" || textBox1.Text == "" || comboBox6.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("You have empty record");
            }
            else
            {
                w.sessionID = textBox4.Text;
                w.lecture = comboBox7.Text;
                w.lectures = textBox2.Text;
                w.sub_code = comboBox6.Text;
                w.subject = comboBox1.Text;
                w.tag = comboBox2.Text;
                w.grp = comboBox3.Text;
                w.numofstudent = textBox3.Text;
                w.duration = textBox1.Text;

                bool y = w.Insert(w);
                if (y == true)
                {
                    MessageBox.Show("Successfully");

                }
                else if (y == false)
                {
                    MessageBox.Show("UnSuccessfully");
                }
            }
        }

        private void SessionAdd_Load(object sender, EventArgs e)
        {
            LodingComboLec();
            LodingComboSub();
            LodingComboTag();
            LodingComboSubGrop();
        }

        public void LodingComboLec()
        {
            SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            comboBox1.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT name  FROM Lecture";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox7.Items.Add(dr["name"].ToString());
            }


            con.Close();
        }

        public void LodingComboSub()
        {
            SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            comboBox6.Items.Clear();
            comboBox1.Items.Clear();
            
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Subject_Code,Name  FROM Subject";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox6.Items.Add(dr["Subject_Code"].ToString());
                comboBox1.Items.Add(dr["Name"].ToString());
                
            }


            con.Close();
        }

        public void LodingComboTag()
        {
            SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            comboBox2.Items.Clear();

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT  Tag_Code FROM Tag_Table";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox2.Items.Add(dr["Tag_Code"].ToString());
                

            }


            con.Close();
        }

        public void LodingComboSubGrop()
        {
            SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            comboBox3.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT groupId  FROM StudentInfo";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox3.Items.Add(dr["groupId"].ToString());
            }


            con.Close();
        }
    }
}
