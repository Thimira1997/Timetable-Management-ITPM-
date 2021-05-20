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
    public partial class LecUpdate : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30");
        public LecUpdate()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            for (int item = 0; item <= dataGridView1.Rows.Count - 1; item++)
            {
                SqlCommand cmd2 = new SqlCommand("update Lecture set name = @name,faculty = @faculty,dep = @dep,campus = @cam,building = @bul,level = @level,rank = @rank where empId = @id", con);

                cmd2.Parameters.AddWithValue("@name", dataGridView1.Rows[item].Cells[2].Value);
                cmd2.Parameters.AddWithValue("@faculty", dataGridView1.Rows[item].Cells[3].Value);
                cmd2.Parameters.AddWithValue("@dep", dataGridView1.Rows[item].Cells[4].Value);
                cmd2.Parameters.AddWithValue("@cam", dataGridView1.Rows[item].Cells[5].Value);
                cmd2.Parameters.AddWithValue("@bul", dataGridView1.Rows[item].Cells[6].Value);
                cmd2.Parameters.AddWithValue("@level", dataGridView1.Rows[item].Cells[7].Value);
                cmd2.Parameters.AddWithValue("@rank", dataGridView1.Rows[item].Cells[8].Value);
                cmd2.Parameters.AddWithValue("id", dataGridView1.Rows[item].Cells[1].Value);

                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
            }

            MessageBox.Show("Updated!!");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                SqlDataAdapter sad = new SqlDataAdapter("SELECT *FROM Lecture WHERE empId = '" + comboBox1.Text.Trim() + "'", con);
                DataTable dt = new DataTable();
                _ = sad.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.AllowUserToAddRows = false;
            }
        }

        private void LecUpdate_Load(object sender, EventArgs e)
        {
            Select();
            LodingCombo();
        }

        public void Select()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                SqlDataAdapter sad = new SqlDataAdapter("SELECT *FROM Lecture ", con);
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
            cmd.CommandText = "SELECT empId  FROM Lecture";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["empId"].ToString());
            }


            con.Close();
        }
    }
}
