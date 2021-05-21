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
    public partial class SessionNotAvaAdd : Form
    {
        NotAvailable c = new NotAvailable();
        public SessionNotAvaAdd()
        {
            InitializeComponent();
        }

        private void SessionNotAvaAdd_Load(object sender, EventArgs e)
        {
            LodingComboLec();
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
                comboBox1.Items.Add(dr["name"].ToString());
            }


            con.Close();
        }


        public void LodingComboSubGrop()
        {
            SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            comboBox2.Items.Clear();
            comboBox4.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT groupId,subgroupId  FROM StudentInfo";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox2.Items.Add(dr["groupId"].ToString());
                comboBox4.Items.Add(dr["subgroupId"].ToString());
            }


            con.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBox4.Text == "" || textBox2.Text == "" || comboBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("You have empty record");
            }
            else
            {
                c.sessionID = textBox2.Text;
                c.lecture = comboBox1.Text;
                c.grp = comboBox2.Text;
                c.sub_grp = comboBox4.Text;
                c.time = textBox1.Text;



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
