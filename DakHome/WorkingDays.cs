using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DakHome
{
    class WorkingDays
    {
        public string Emp_ID { get; set; }
        public string NoOfWork { get; set; }
        public string WorkDays { get; set; }
        public string WorkingPerDay { get; set; }


        public bool Insert(WorkingDays w)
        {
            bool x = false;

            SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            try
            {
                string sql = "INSERT INTO WorkingDays (Emp_ID,NoOfWork,WorkDays,WorkingPerDay) VALUES (@empid,@noofwork,@workdays,@workingperday)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@empid", w.Emp_ID);
                cmd.Parameters.AddWithValue("@noofwork", w.NoOfWork);
                cmd.Parameters.AddWithValue("@workdays", w.WorkDays);
                cmd.Parameters.AddWithValue("@workingperday", w.WorkingPerDay);


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

        public bool Delete(WorkingDays w)
        {
            bool x = false;

            SqlConnection con = new SqlConnection(@"Data Source=timetablemanagement.database.windows.net;Initial Catalog=timetable;User ID=it19032320;Password=456Dakshinda*;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            try
            {
                string sql = "DELETE FROM WorkingDays WHERE Emp_ID = @id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", w.Emp_ID);

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
