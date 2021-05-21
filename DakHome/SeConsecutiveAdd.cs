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
    public partial class SeConsecutiveAdd : Form
    {
        Consecutive c = new Consecutive();
        public SeConsecutiveAdd()
        {
            InitializeComponent();
        }

        private void SeConsecutiveAdd_Load(object sender, EventArgs e)
        {
            LodingComboLec();
            LodingComboSub();
            LodingComboTag();
            LodingComboSubGrop();
        }

        public void LodingComboLec()
        {
            SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
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
                comboBox3.Items.Add(dr["name"].ToString());
                comboBox4.Items.Add(dr["name"].ToString());
            }


            con.Close();
        }

        public void LodingComboSub()
        {
            SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            comboBox2.Items.Clear();
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
                comboBox2.Items.Add(dr["Subject_Code"].ToString());
                comboBox1.Items.Add(dr["Name"].ToString());

            }


            con.Close();
        }

        public void LodingComboTag()
        {
            SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            comboBox5.Items.Clear();

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
                comboBox5.Items.Add(dr["Tag_Code"].ToString());


            }


            con.Close();
        }

        public void LodingComboSubGrop()
        {
            SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            comboBox6.Items.Clear();
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
                comboBox6.Items.Add(dr["groupId"].ToString());
            }


            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || comboBox4.Text == "" || comboBox3.Text == "" || comboBox2.Text == "" || comboBox1.Text== "" || comboBox5.Text == "" || comboBox6.Text == "")
            {
                MessageBox.Show("You have empty record");
            }
            else
            {
                c.sessionID = textBox1.Text;
                c.L1 = comboBox4.Text;
                c.L2 = comboBox3.Text;
                c.sub_code = comboBox2.Text;
                c.subject = comboBox1.Text;
                c.tag = comboBox5.Text;
                c.grp = comboBox6.Text;


                bool y = c.Insert(c);
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
    }
}
