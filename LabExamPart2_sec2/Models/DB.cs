using LabExamPart2_sec2.Models;
using System.Data;
using System.Data.SqlClient;

namespace LabExamPart2_sec2.Models
{
    public class DB
    {
        string conStr = "Data Source=YourServerName;Initial Catalog=LabExam_SaraAhmed_UniversityDB;Integrated Security=True";
        public bool findStudent(string username)
        {
            SqlConnection con = new SqlConnection(conStr);
            try { 
                con.Open();
                string query = "select * from Student where username= '" + username + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                object? result = cmd.ExecuteScalar();
                if (result!=null)
                    return true;
                else
                    return false;
            } catch (SqlException e) { throw e; } finally { con.Close(); }
        }
        public string getStudentName(string username) {
            SqlConnection con = new SqlConnection(conStr);
            try
            {
                con.Open();
                string query = "select name from Student where username= '" + username + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                string result = (string)cmd.ExecuteScalar();
                if (result != null)
                    return result;
                else
                    return "";
            }
            catch (SqlException e) { throw e; }
            finally { con.Close(); }
        }
        public List<Course> getCourses(string username)
        {
            SqlConnection con = new SqlConnection(conStr);
            try
            {
                con.Open();
                string query = "select Course.id as course_id, Course.course_name, Section.id as section_id, Section.instructor_name instructor, Grade.grade_Letter from Course inner join Section on Course.id = Section.course_id \r\ninner join Grade on Grade.section_id = Section.id inner join\r\nStudent on Student.id = Grade.student_id\r\nwhere Student.username = '" + username + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable result = new DataTable();
                result.Load(cmd.ExecuteReader());
                List<Course> courses = new List<Course>();

                foreach (DataRow dr in result.Rows)
                {
                    courses.Add(new Course
                    {
                        id = (string)dr["course_id"],
                        name = (string)dr["course_name"],
                        secId = (int)dr["section_id"],
                        instructor = (string)dr["instructor"],
                        grade = (string)dr["grade_Letter"]
                    });
                }
                return courses;
            }
            catch (SqlException e) { throw e; }
            finally { con.Close(); }
        }
    }
}
