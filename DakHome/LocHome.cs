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
    public partial class LocHome : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30");
        public LocHome()
        {
            InitializeComponent();
        }
        private Form activeForm = null;
        private void openChildForm2(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm2.Controls.Add(childForm);
            panelChildForm2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            openChildForm2(new LocRemove());
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {

        }

        private void panelChildForm2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            openChildForm2(new LocShow());
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            openChildForm2(new LocAdd());
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            openChildForm2(new LocUpdate());
        }

        private void LocHome_Load(object sender, EventArgs e)
        {
            LodingCombo();
            select();
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
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30"))
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
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30"))
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
