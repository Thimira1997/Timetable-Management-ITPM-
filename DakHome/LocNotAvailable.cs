using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DakHome
{
    class LocNotAvailable
    {
        public string sessionID { get; set; }
        public string room { get; set; }
        public string day { get; set; }
        public string stime { get; set; }
        public string etime { get; set; }

        public bool Insert(LocNotAvailable l)
        {
            bool x = false;

            SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            try
            {
                string sql = "INSERT INTO LocNotAvailable(sessionID,room,day,stime,etime) VALUES (@id,@room,@day,@stime,@etime)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@id", l.sessionID);
                cmd.Parameters.AddWithValue("@room", l.room);
                cmd.Parameters.AddWithValue("@day", l.day);
                cmd.Parameters.AddWithValue("@stime", l.stime);
                cmd.Parameters.AddWithValue("@etime", l.etime);

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


        public bool Delete(LocNotAvailable l)
        {
            bool x = false;

            SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            try
            {
                string sql = "DELETE FROM LocNotAvailable WHERE sessionID = @id";
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
