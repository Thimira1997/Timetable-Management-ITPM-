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
    public partial class LocConAdd : Form
    {
        LocConsecutive c = new LocConsecutive();
        public LocConAdd()
        {
            InitializeComponent();
        }

        private void LocConAdd_Load(object sender, EventArgs e)
        {
            LodingComboLec();
            LodingComboRoom();
        }

        public void LodingComboLec()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30");
            comboBox4.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT sessionID  FROM Consecutive";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox4.Items.Add(dr["sessionID"].ToString());
            }


            con.Close();
        }

        public void LodingComboRoom()
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

        private void button4_Click(object sender, EventArgs e)
        {
            c.sessionID = comboBox4.Text;
            c.location = comboBox3.Text;


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
