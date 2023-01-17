namespace DAL;
using StudentApp.Models;
using MySql.Data.MySqlClient;
using System.Data;
public class DBManager
{

    public static string conString = @"server=localhost;port=3306;user=root;password=ntpc;database=student";

    public static List<Student> GetAllStudents()
    {
        List<Student> allStudents = new List<Student>();

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;
        try
        {
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            string query = "SELECT * FROM uustudent";
            cmd.CommandText = query;

            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);

            DataTable dt = ds.Tables[0];
            DataRowCollection rows = dt.Rows;

            foreach (DataRow row in rows)
            {
                int id = int.Parse(row["id"].ToString());
                string name = row["name"].ToString();
                string branch = row["branch"].ToString();

                Student student = new Student
                {
                    Sid = id,
                    Sname = name,
                    Sbranch = branch
                };
                allStudents.Add(student);



            }
        }
        catch (Exception ee)
        {
            Console.WriteLine(ee.Message);
        }
        return allStudents;
    }


    public static Student GetStudent(int id)
    {
        Student std = new Student();

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = conString;

        try
        {
            con.Open();
            string query = "select * from uustudent where id=" + id;
            MySqlCommand cmd = new MySqlCommand(query, con);

            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                int idd = int.Parse(reader["id"].ToString());
                string name = reader["name"].ToString();
                string branch = reader["branch"].ToString();

                Student newStudent = new Student
                {
                    Sid = idd,
                    Sname = name,
                    Sbranch = branch

                };
                std = newStudent;

            }
                




        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
return std;
}

public static void Insert(Student student){

MySqlConnection con=new MySqlConnection();
con.ConnectionString=conString;
try{
    con.Open();
//$"insert into students(sid,sname,course) values('{student.Sid}','{student.Sname}','{student.Course}')";
    string query=$"insert into uustudent(id,name,branch) values('"+student.Sid+"','"+student.Sname+"','"+student.Sbranch+"')";
MySqlCommand cmd=new MySqlCommand(query,con);
cmd.ExecuteNonQuery();


}
catch(Exception e){
Console.WriteLine(e.Message);

}
finally{
    con.Close();
}


}
public static void DelbyId(int id){

}

}