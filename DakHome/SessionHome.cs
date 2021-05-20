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
    public partial class SessionHome : Form
    {
        public SessionHome()
        {
            InitializeComponent();
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PanelChildForm.Controls.Add(childForm);
            PanelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            openChildForm(new SessionShow());
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            openChildForm(new SessionAdd());
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            openChildForm(new SessionUpdate());
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            openChildForm(new SessionRemove());
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SessionHome_Load(object sender, EventArgs e)
        {
            LodingComboLec();
            select();
        }

        public void select()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                SqlDataAdapter sad = new SqlDataAdapter("SELECT *FROM NomalSession ", con);
                DataTable dt = new DataTable();
                _ = sad.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        public void LodingComboLec()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30");
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT sessionID,lecture  FROM NomalSession";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["sessionID"].ToString());
                comboBox2.Items.Add(dr["lecture"].ToString());
            }


            con.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    SqlDataAdapter sad = new SqlDataAdapter("SELECT *FROM NomalSession WHERE lecture = '" + comboBox2.Text.Trim() + "' and sessionID = '" + comboBox1.Text.Trim() + "'", con);
                    DataTable dt = new DataTable();
                    _ = sad.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            
        }
    }
}
