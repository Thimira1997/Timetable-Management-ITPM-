using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DakHome
{
    class Student
    {

        public int id { get; set; }
        public String groupId { get; set; }
        public String subgroupId { get; set; }
        public String yearsem { get; set; }
        public String program { get; set; }
        public String grpno { get; set; }
        public String subgrpno { get; set; }

        public bool Insert(Student st)
        {
            bool x = false;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30");
            try
            {
                string sql = "INSERT INTO Student(groupId,subgroupId,yearsem,program,grpno,subgrpno) VALUES (@gid,@sgid,@ys,@pro,@gno,@subgno)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@gid", st.groupId);
                cmd.Parameters.AddWithValue("@sgid", st.subgroupId);
                cmd.Parameters.AddWithValue("@ys", st.yearsem);
                cmd.Parameters.AddWithValue("@pro", st.program);
                cmd.Parameters.AddWithValue("@gno", st.grpno);
                cmd.Parameters.AddWithValue("@subgno", st.subgrpno);

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

        public bool Delete(Student st)
        {
            bool x = false;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\TimeTableManagement.mdf;Integrated Security=True;Connect Timeout=30");

            try
            {
                string sql = "DELETE FROM Student WHERE subgroupId = @subgroupId";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@subgroupId", st.subgroupId);


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
