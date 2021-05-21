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
    public partial class LocUpdate : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public LocUpdate()
        {
            InitializeComponent();
        }

        private void LocUpdate_Load(object sender, EventArgs e)
        {
            LodingCombo();
            select();
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
            foreach (DataRow dr in dt.Rows)
            {
                comboBox2.Items.Add(dr["roomname"].ToString());
            }
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["buildingname"].ToString());
            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                con.Open();
                SqlDataAdapter sad = new SqlDataAdapter("SELECT *FROM Location WHERE buildingname = '" + comboBox1.Text.Trim() + "' and roomname = '" + comboBox2.Text.Trim() + "'", con);
                DataTable dt = new DataTable();
                _ = sad.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.AllowUserToAddRows = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int item = 0; item <= dataGridView1.Rows.Count - 1; item++)
            {
                SqlCommand cmd3 = new SqlCommand("update Location set type = @type,capacity = @cap where buildingname = @bul and roomname = @room", con);
                cmd3.Parameters.AddWithValue("@type", dataGridView1.Rows[item].Cells[3].Value);
                cmd3.Parameters.AddWithValue("@cap", dataGridView1.Rows[item].Cells[4].Value);
                cmd3.Parameters.AddWithValue("@bul", dataGridView1.Rows[item].Cells[1].Value);
                cmd3.Parameters.AddWithValue("room", dataGridView1.Rows[item].Cells[2].Value);

                con.Open();
                cmd3.ExecuteNonQuery();
                con.Close();
            }

            MessageBox.Show("Updated!!");
        }
    }
}
