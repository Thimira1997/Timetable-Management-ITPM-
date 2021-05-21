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
    public partial class locParallelAdd : Form
    {
        LocParallel w = new LocParallel();
        public locParallelAdd()
        {
            InitializeComponent();
        }

        private void locParallelAdd_Load(object sender, EventArgs e)
        {
            LodingComboRoom();
            LodingComboLec();
        }

        public void LodingComboLec()
        {
            SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            comboBox4.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT sessionID  FROM Parallel";
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
            SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
            w.sessionID = comboBox4.Text;
            w.location = comboBox3.Text;


            bool y = w.Insert(w);
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
