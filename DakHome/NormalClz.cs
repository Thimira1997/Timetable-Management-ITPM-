using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DakHome
{
    class NormalClz
    {
        public string sessionID { get; set; }
        public string lecture { get; set; }
        public string lectures { get; set; }
        public string sub_code { get; set; }
        public string subject { get; set; }
        public string tag { get; set; }
        public string grp { get; set; }
        public string numofstudent { get; set; }
        public string duration { get; set; }

        public bool Insert(NormalClz w)
        {
            bool x = false;

            SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            try
            {
                string sql = "INSERT INTO NomalSession(sessionID,lecture,lectures,sub_code,subject,tag,grp,numofstudent,duration) VALUES(@sID,@lec,@lecs,@subcode,@sub,@Tag,@grp,@nOfs,@dura)";
                SqlCommand cmd = new SqlCommand(sql, con);
                MessageBox.Show(w.grp);

                cmd.Parameters.AddWithValue("@sID", w.sessionID);
                cmd.Parameters.AddWithValue("@lec", w.lecture);
                cmd.Parameters.AddWithValue("@lecs", w.lectures);
                cmd.Parameters.AddWithValue("@subcode", w.sub_code);
                cmd.Parameters.AddWithValue("@sub", w.subject);
                cmd.Parameters.AddWithValue("@Tag", w.tag);
                cmd.Parameters.AddWithValue("@grp", w.grp);
                cmd.Parameters.AddWithValue("@nOfs", w.numofstudent);
                cmd.Parameters.AddWithValue("@dura", w.duration);

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

        public bool Delete(NormalClz w)
        {
            bool x = false;

            SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            try
            {
                string sql = "DELETE FROM NomalSession WHERE sessionID = @id";
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
