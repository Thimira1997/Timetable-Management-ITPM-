﻿using System;
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
    public partial class LecRemove : Form
    {
        Lecture l = new Lecture();
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30");


        public LecRemove()
        {
            InitializeComponent();
        }

        private void LecRemove_Load(object sender, EventArgs e)
        {
            Select();
            LodingCombo(); 
        }

        private void label2_Click(object sender, EventArgs e)
        {

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

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            l.empId = comboBox1.Text;
            bool y = l.Delete(l);

            if(y == true)
            {
                MessageBox.Show("Successfull!");
            }
            else
            {
                MessageBox.Show("UnSuccessfull!");
            }

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                SqlDataAdapter sad = new SqlDataAdapter("SELECT *FROM Lecture WHERE empId = '" + comboBox1.Text.Trim() + "'", con);
                DataTable dt = new DataTable();
                _ = sad.Fill(dt);

                dataGridView1.DataSource = dt;
            }
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
