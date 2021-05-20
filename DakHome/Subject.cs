using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DakHome
{
    class Subject
    {
        public string Name { get; set; }
        public string Subject_Code { get; set; }
        public string Offered_Year { get; set; }
        public string Offered_Semester { get; set; }
        public string NumOfLecHours { get; set; }
        public string NumOfTuteHours { get; set; }
        public string NumOfLabHours { get; set; }
        public string NumOfEvaHours { get; set; }

        public bool Insert(Subject S)
        {
            bool x = false;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30");

            try
            {
                string sql = "INSERT INTO Subject(Name,Subject_Code,Offered_Year,Offered_Semester,NumOfLecHours,NumOfTuteHours,NumOfLabHours,NumOfEvaHours) VALUES (@Name,@Subject_Code,@Offered_Year,@Offered_Semester,@NumOfLecHours,@NumOfTuteHours,@NumOfLabHours,@NumOfEvaHours)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Name", S.Name);
                cmd.Parameters.AddWithValue("@Subject_Code", S.Subject_Code);
                cmd.Parameters.AddWithValue("@Offered_Year", S.Offered_Year);
                cmd.Parameters.AddWithValue("@Offered_Semester", S.Offered_Semester);
                cmd.Parameters.AddWithValue("@NumOfLecHours", S.NumOfLecHours);
                cmd.Parameters.AddWithValue("@NumOfTuteHours", S.NumOfTuteHours);
                cmd.Parameters.AddWithValue("@NumOfLabHours", S.NumOfLabHours);
                cmd.Parameters.AddWithValue("@NumOfEvaHours", S.NumOfEvaHours);

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


        public bool Delete(Subject S)
        {
            bool x = false;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30");

            try
            {
                string sql = "DELETE FROM Subject WHERE Subject_Code = @Subject_Code";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Subject_Code", S.Subject_Code);

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
