using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DakHome
{
    class Lecture
    {
        public string empId { get; set; }
        public string name { get; set; }
        public string faculty { get; set; }
        public string dep { get; set; }
        public string campus { get; set; }
        public string building { get; set; }
        public string level { get; set; }
        public string rank { get; set; }

        public bool Insert(Lecture l)
        {
            bool x = false;

            SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            try
            {
                string sql = "INSERT INTO Lecture(empId,name,faculty,dep,campus,building,level,rank) VALUES (@id,@Name,@Faculty,@Dep,@Campus,@Building,@Level,@Rank)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@id", l.empId);
                cmd.Parameters.AddWithValue("@Name", l.name);
                cmd.Parameters.AddWithValue("@Faculty", l.faculty);
                cmd.Parameters.AddWithValue("@Dep", l.dep);
                cmd.Parameters.AddWithValue("@Campus", l.campus);
                cmd.Parameters.AddWithValue("@Building", l.building);
                cmd.Parameters.AddWithValue("@Level", l.level);
                cmd.Parameters.AddWithValue("@Rank", l.rank);

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


        public bool Delete(Lecture l)
        {
            bool x = false;

            SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            try
            {
                string sql = "DELETE FROM Lecture WHERE empId = @id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", l.empId);

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
