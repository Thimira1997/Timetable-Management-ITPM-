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
    public partial class SubUpdate : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30");
        public SubUpdate()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                SqlDataAdapter sad = new SqlDataAdapter("SELECT *FROM Subject WHERE Subject_Code = '" + comboBox1.Text.Trim() + "'", con);
                DataTable dt = new DataTable();
                _ = sad.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.AllowUserToAddRows = false;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            for (int item = 0; item <= dataGridView1.Rows.Count - 1; item++)
            {
                SqlCommand cmd2 = new SqlCommand("update Subject set Name = @Name,Offered_Year = @Offered_Year,Offered_Semester = @Offered_Semester,NumOfLecHours = @NumOfLecHours,NumOfTuteHours = @NumOfTuteHours,NumOfLabHours = @NumOfLabHours,NumOfEvaHours = @NumOfEvaHours where Subject_Code = @Subject_Code", con);
                cmd2.Parameters.AddWithValue("@Name", dataGridView1.Rows[item].Cells[0].Value);
                cmd2.Parameters.AddWithValue("@Offered_Year", dataGridView1.Rows[item].Cells[2].Value);
                cmd2.Parameters.AddWithValue("@Offered_Semester", dataGridView1.Rows[item].Cells[3].Value);
                cmd2.Parameters.AddWithValue("@NumOfLecHours", dataGridView1.Rows[item].Cells[4].Value);
                cmd2.Parameters.AddWithValue("@NumOfTuteHours", dataGridView1.Rows[item].Cells[5].Value);
                cmd2.Parameters.AddWithValue("@NumOfLabHours", dataGridView1.Rows[item].Cells[6].Value);
                cmd2.Parameters.AddWithValue("@NumOfEvaHours", dataGridView1.Rows[item].Cells[7].Value);

                cmd2.Parameters.AddWithValue("Subject_Code", dataGridView1.Rows[item].Cells[1].Value);

                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
            }

            MessageBox.Show("Updated!!");
        }

        private void SubUpdate_Load(object sender, EventArgs e)
        {
            Select();
            LodingCombo();
        }

        public void Select()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                SqlDataAdapter sad = new SqlDataAdapter("SELECT *FROM  Subject", con);
                DataTable dt = new DataTable();
                _ = sad.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        public void LodingCombo()
        {

            comboBox1.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Subject_Code  FROM Subject";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["Subject_Code"].ToString());
            }


            con.Close();
        }
    }
    }

