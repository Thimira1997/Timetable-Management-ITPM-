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
    public partial class SessionParallelUpdate : Form
    {
        public SessionParallelUpdate()
        {
            InitializeComponent();
        }

        private void SessionParallelUpdate_Load(object sender, EventArgs e)
        {
            LodingComboLec();
            select();
        }

        public void select()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                SqlDataAdapter sad = new SqlDataAdapter("SELECT *FROM Parallel ", con);
                DataTable dt = new DataTable();
                _ = sad.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        public void LodingComboLec()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30");
            comboBox1.Items.Clear();
            comboBox6.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT sessionID,grp  FROM Parallel";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["sessionID"].ToString());
                comboBox6.Items.Add(dr["grp"].ToString());
            }


            con.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                SqlDataAdapter sad = new SqlDataAdapter("SELECT *FROM Parallel WHERE grp = '" + comboBox6.Text.Trim() + "' and sessionID = '" + comboBox1.Text.Trim() + "'", con);
                DataTable dt = new DataTable();
                _ = sad.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.AllowUserToAddRows = false;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30");
            for (int item = 0; item <= dataGridView1.Rows.Count - 1; item++)
            {
                SqlCommand cmd3 = new SqlCommand("update Parallel set sessionID =@sID,L1 = @lec,L2 = @lecs,sub_code = @subcode,subject = @subject,tag = @Tag,grp = @grp where id = @id", con);
                cmd3.Parameters.AddWithValue("@sID", dataGridView1.Rows[item].Cells[1].Value);
                cmd3.Parameters.AddWithValue("@lec", dataGridView1.Rows[item].Cells[2].Value);
                cmd3.Parameters.AddWithValue("@lecs", dataGridView1.Rows[item].Cells[3].Value);
                cmd3.Parameters.AddWithValue("@subcode", dataGridView1.Rows[item].Cells[4].Value);
                cmd3.Parameters.AddWithValue("@subject", dataGridView1.Rows[item].Cells[5].Value);
                cmd3.Parameters.AddWithValue("@Tag", dataGridView1.Rows[item].Cells[6].Value);
                cmd3.Parameters.AddWithValue("@grp", dataGridView1.Rows[item].Cells[7].Value);
                cmd3.Parameters.AddWithValue("id", dataGridView1.Rows[item].Cells[0].Value);

                con.Open();
                _ = cmd3.ExecuteNonQuery();
                con.Close();
            }

            MessageBox.Show("Updated!!");
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                SqlDataAdapter sad = new SqlDataAdapter("SELECT *FROM Parallel WHERE  sessionID = '" + comboBox1.Text.Trim() + "'", conn);
                DataTable dt = new DataTable();
                _ = sad.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }
    }
}
