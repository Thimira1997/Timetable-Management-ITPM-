﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DakHome
{
    class Parallel
    {
        public string sessionID { get; set; }
        public string L1 { get; set; }
        public string L2 { get; set; }
        public string sub_code { get; set; }
        public string subject { get; set; }
        public string tag { get; set; }
        public string grp { get; set; }
       

        public bool Insert(Parallel w)
        {
            bool x = false;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30");

            try
            {
                string sql = "INSERT INTO Parallel(sessionID,L1,L2,sub_code,subject,tag,grp) VALUES(@sID,@lec,@lecs,@subcode,@sub,@Tag,@grp)";
                SqlCommand cmd = new SqlCommand(sql, con);
                MessageBox.Show(w.grp);

                cmd.Parameters.AddWithValue("@sID", w.sessionID);
                cmd.Parameters.AddWithValue("@lec", w.L1);
                cmd.Parameters.AddWithValue("@lecs", w.L2);
                cmd.Parameters.AddWithValue("@subcode", w.sub_code);
                cmd.Parameters.AddWithValue("@sub", w.subject);
                cmd.Parameters.AddWithValue("@Tag", w.tag);
                cmd.Parameters.AddWithValue("@grp", w.grp);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    x = true;
                }
                else
                {
                    x = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return x;
        }

        public bool Delete(Parallel w)
        {
            bool x = false;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30");

            try
            {
                string sql = "DELETE FROM Parallel WHERE sessionID = @id and  grp = @grp";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", w.sessionID);
                cmd.Parameters.AddWithValue("@grp", w.grp);

                con.Open();

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    x = true;
                }
                else
                {
                    x = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return x;

        }
    }
}
