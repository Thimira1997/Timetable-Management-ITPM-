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
    public partial class TagUpdate : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public TagUpdate()
        {
            InitializeComponent();
        }

        private void TagUpdate_Load(object sender, EventArgs e)
        {
            Select();
            LodingCombo();
        }

        public void Select()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                con.Open();
                SqlDataAdapter sad = new SqlDataAdapter("SELECT *FROM  Tag_Table", con);
                DataTable dt = new DataTable();
                _ = sad.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Tag_Table where Tag_Code = '" + comboBox1.Text.Trim() + "'";
            cmd.Connection = con;
            SqlDataReader datareder;
            datareder = cmd.ExecuteReader();
            bool temp = false;
            while (datareder.Read())
            {
                textBox2.Text = datareder.GetString(1);
                comboBox1.Text = datareder.GetString(2);
                comboBox2.Text = datareder.GetString(3);

                temp = true;
            }
            if(temp == false)
            {
                MessageBox.Show("Not Found");
            }
            con.Close();
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tag_Table",con);
            da.Fill(ds, "Tag_Code");
            con.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            string constring = @"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string query = "update Tag_Table set Tag_Code = '" + this.comboBox1.Text + "', Sub_Code = '" + this.textBox2.Text + "',Tag_Name ='" + this.comboBox1.Text + "',Related_Tag = '" + this.comboBox2.Text + "'  where  Tag_Code = '" + this.comboBox1.Text + "';";
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

            using (SqlConnection conn = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                conn.Open();
                SqlDataAdapter sad = new SqlDataAdapter("SELECT *FROM  Tag_Table WHERE Tag_Code = '" + comboBox1.Text.Trim() + "'", conn);
                DataTable dt = new DataTable();
                _ = sad.Fill(dt);

                dataGridView1.DataSource = dt;
            }

        }

        public void LodingCombo()
        {

            comboBox3.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Tag_Code  FROM Tag_Table";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox3.Items.Add(dr["Tag_Code"].ToString());
            }


            con.Close();
        }



    }

}
