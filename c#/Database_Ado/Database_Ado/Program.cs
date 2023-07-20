using MySql.Data.MySqlClient;
using System;
using System.Data;

public class Practice
{
    static void Main()
    {
        DataSet ds = new DataSet();
        var connectionString = "server=127.0.0.1;uid=root;pwd=mindfire;database=practice";
        //var mysqlConn = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
        /*using (var con = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
        {   
            var sde = new MySqlDataAdapter("Select * from student", con);
            sde.Fill(ds,);
            *//*foreach (DataRow row in ds.Tables["Address"].Rows)
            {
                Console.WriteLine(row[0]+" " + row[1]+" " + row[2]+" "+row[3]);
            }*//*


        }*/

        using (var con = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
        {
            string query = "insert into student2 values(4,'Aniket','Ani',22)";
            MySqlCommand ms= new MySqlCommand(query, con);
            con.Open();
            int x = ms.ExecuteNonQuery();
            Console.WriteLine(x);

            /*MyReader2 = ms.ExecuteReader();
            while(MyReader2.Read())
            {
                Console.WriteLine(MyReader2["Id"]);
            }*/
            con.Close();
        }
        Console.ReadLine();
    }
}