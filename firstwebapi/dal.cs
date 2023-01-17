namespace DAL;
using poco;
using MySql.Data.MySqlClient;
using System.Data;
public class dal
{

    public static string conString = @"server=localhost;port=3306;user=root;password=ntpc;database=student";

    public static List<uu> GetAllStudents()
    {
        List<uu> allStudents = new List<uu>();

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

                uu student = new uu{
                    Id = id,
                    Name = name,
                    Branch = branch
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


}