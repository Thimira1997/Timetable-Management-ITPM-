using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DakHome
{
    class Consecutive
    {
        public string sessionID { get; set; }
        public string L1 { get; set; }
        public string L2 { get; set; }
        public string sub_code { get; set; }
        public string subject { get; set; }
        public string tag { get; set; }
        public string grp { get; set; }
        

        public bool Insert(Consecutive w)
        {
            bool x = false;

            SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            try
            {
                string sql = "INSERT INTO Consecutive(sessionID,L1,L2,sub_code,subject,tag,grp) VALUES(@sID,@lec1,@lec2,@subcode,@sub,@Tag,@grp)";
                SqlCommand cmd = new SqlCommand(sql, con);
                MessageBox.Show(w.grp);

                cmd.Parameters.AddWithValue("@sID", w.sessionID);
                cmd.Parameters.AddWithValue("@lec1", w.L1);
                cmd.Parameters.AddWithValue("@lec2", w.L2);
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

        public bool Delete(Consecutive w)
        {
            bool x = false;

            SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            try
            {
                string sql = "DELETE FROM Consecutive WHERE sessionID = @id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", w.sessionID);

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
