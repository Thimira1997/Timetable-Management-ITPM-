using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DakHome
{
    class NotAvailable
    {

        public string sessionID { get; set; }
        public string lecture { get; set; }
        public string grp { get; set; }
        public string sub_grp { get; set; }
        public string time { get; set; }

        public bool Insert(NotAvailable l)
        {
            bool x = false;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30");

            try
            {
                string sql = "INSERT INTO NotAvailable(sessionID,lecture,grp,sub_grp,time) VALUES (@id,@lec,@grp,@sgrp,@time)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@id", l.sessionID);
                cmd.Parameters.AddWithValue("@lec", l.lecture);
                cmd.Parameters.AddWithValue("@grp", l.grp);
                cmd.Parameters.AddWithValue("@sgrp", l.sub_grp);
                cmd.Parameters.AddWithValue("@time", l.time);

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


        public bool Delete(NotAvailable l)
        {
            bool x = false;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30");

            try
            {
                string sql = "DELETE FROM NotAvailable WHERE sessionID = @id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", l.sessionID);

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
