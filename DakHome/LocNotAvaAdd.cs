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
    public partial class LocNotAvaAdd : Form
    {
        LocNotAvailable c = new LocNotAvailable();
        public LocNotAvaAdd()
        {
            InitializeComponent();
        }

        private void LocNotAvaAdd_Load(object sender, EventArgs e)
        {
            LodingComboLec();
            LodingRomm();
        }

        public void LodingRomm()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30");
            comboBox3.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT roomname  FROM Location";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox3.Items.Add(dr["roomname"].ToString());
            }


            con.Close();
        }

        public void LodingComboLec()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30");
            comboBox2.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT sessionID  FROM Notavailable";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox2.Items.Add(dr["sessionID"].ToString());
            }


            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            c.sessionID = textBox2.Text;
            c.room = comboBox3.Text;
            c.day = comboBox1.Text;
            c.stime = textBox2.Text;
            c.etime = textBox3.Text;


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
