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
    public partial class LocNormalSessionHome : Form
    {
        public LocNormalSessionHome()
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
            openChildForm(new LocNormalShow());
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            openChildForm(new LocNormalAdd());
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            openChildForm(new LocNormalUpdate());
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            openChildForm(new LocNormalRemove());
        }

        private void LocNormalSessionHome_Load(object sender, EventArgs e)
        {
            LodingComboLec();
            select();
        }

        public void select()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                con.Open();
                SqlDataAdapter sad = new SqlDataAdapter("SELECT *FROM LocNomal ", con);
                DataTable dt = new DataTable();
                _ = sad.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }
        public void LodingComboLec()
        {
            SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            comboBox1.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT sessionID  FROM LocNomal";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["sessionID"].ToString());
            }


            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                con.Open();
                SqlDataAdapter sad = new SqlDataAdapter("SELECT *FROM LocNomal WHERE  sessionID = '" + comboBox1.Text.Trim() + "'", con);
                DataTable dt = new DataTable();
                _ = sad.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }
    }
}
