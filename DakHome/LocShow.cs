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
    
 
    public partial class LocShow : Form
    {
        
        SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public LocShow()
        {
            InitializeComponent();
        }

        public void LodingCombo()
        {
            comboBox2.Items.Clear();
            comboBox1.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT  roomname,buildingname FROM Location";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                comboBox2.Items.Add(dr["roomname"].ToString());
            }
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["buildingname"].ToString());
            }

            con.Close();
        }

        private void LocShow_Load(object sender, EventArgs e)
        {
            LodingCombo();
            select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                con.Open();
                SqlDataAdapter sad = new SqlDataAdapter("SELECT *FROM Location WHERE buildingname = '" + comboBox1.Text.Trim() + "' or roomname = '" + comboBox2.Text.Trim() + "'", con);
                DataTable dt = new DataTable();
                _ = sad.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        public void select()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                con.Open();
                SqlDataAdapter sad = new SqlDataAdapter("SELECT *FROM Location ", con);
                DataTable dt = new DataTable();
                _ = sad.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }
    }

    
}
