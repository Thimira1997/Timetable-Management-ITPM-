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
    public partial class Static : Form
    {
        public Static()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
           
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {



        }

        private void button2_Click(object sender, EventArgs e)
        {
            int SE = 0;
            int CN = 0;
            int IM = 0;
            int Tot = 0;
            int Tot1 = 0,Tot2 = 0,Tot3 = 0;


            for (int i = 1; i < dataGridView1.Rows.Count; i++)
            {

                
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30"))
                {

                    /*con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select program,Id from Student where program = 'SE' AND Id = dataGridView1.Rows.Count";
                    cmd.Connection = con;
                    SqlDataReader datareder;
                    datareder = cmd.ExecuteReader();
                    
                    while (datareder.Read())
                    {
                        
                        SE = SE + 1;
                        break;
                    }

                    con.Close();*/
                }

                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    string sql = "SELECT *FROM Student WHERE program = 'CN' AND Id = i";
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(sql, con);
                        int row = cmd.ExecuteNonQuery();


                        if (row == 1)
                        {
                            CN = CN + 1;
                        }

                    }
                    catch (Exception ex)
                    {

                    }

                    con.Close();
                }

                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    string sql = "SELECT *FROM Student WHERE program = 'IM'";
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(sql, con);
                        int row = cmd.ExecuteNonQuery();


                        if (row == 1)
                        {
                            IM = IM + 1;
                        }

                    }
                    catch (Exception ex)
                    {

                    }

                    con.Close();
                }

                Tot1++;

            }

            for (int i = 1; i < dataGridView2.Rows.Count; i++)
            {
                Tot2++;
            }

            for (int i = 1; i < dataGridView3.Rows.Count; i++)
            {
                Tot3++;
            }

            Tot = SE + CN + IM;
            label1.Text = (Tot2).ToString();
            label2.Text = (Tot1).ToString();
            label3.Text = (Tot3).ToString();

            this.chart1.Series["ChartLine"].Points.AddXY("SE", 20);
            this.chart1.Series["ChartLine"].Points.AddXY("CN", 30);
            this.chart1.Series["ChartLine"].Points.AddXY("IM", 10);
            this.chart1.Series["ChartLine"].Points.AddXY("IT", 30);
            this.chart1.Series["ChartLine"].Points.AddXY("ENGINEERING", 40);


        }


        private void Static_Load(object sender, EventArgs e)
        {
            Select1();
            Select2();
            Select3();
        }

        public void Select1()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                SqlDataAdapter sad = new SqlDataAdapter("SELECT *FROM Student ", con);
                DataTable dt = new DataTable();
                _ = sad.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        public void Select2()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                SqlDataAdapter sad = new SqlDataAdapter("SELECT *FROM Lecture ", con);
                DataTable dt = new DataTable();
                _ = sad.Fill(dt);

                dataGridView2.DataSource = dt;
            }
        }

        public void Select3()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                SqlDataAdapter sad = new SqlDataAdapter("SELECT *FROM Subject ", con);
                DataTable dt = new DataTable();
                _ = sad.Fill(dt);

                dataGridView3.DataSource = dt;
            }
        }
    }
    
}
