using Database_Ado;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common.CommandTrees;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

public class Practice
{
    static string connectionString = "server=127.0.0.1;uid=root;pwd=mindfire;database=practice";
    static void Main()
    {
        DataSet ds = new DataSet();
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
        /*
        using (var con = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
        {
            string query = "insert into student2 values(4,'Aniket','Ani',22)";
            MySqlCommand ms= new MySqlCommand(query, con);
            con.Open();
            int x = ms.ExecuteNonQuery();
            Console.WriteLine(x);

            *//*MyReader2 = ms.ExecuteReader();
            while(MyReader2.Read())
            {
                Console.WriteLine(MyReader2["Id"]);
            }*//*
            con.Close();
        }*/
        /*using (var con = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select * from student2",con);
            MySqlCommand command = new MySqlCommand("update student2 set Fname='Ani' where Age=22",con);
            con.Open();
            int rowsAffected=command.ExecuteNonQuery();
            con.Close();
            dataAdapter.Fill(ds);
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine(row[0]+" " + row[1]+" " + row[2]+" " + row[3]);
            }

        }*/
        /* using (var con = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
         {
             MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select * from student2", con);
             MySqlCommand command1 = new MySqlCommand("update student2 set Fname='Ani' where Age=22", con);
             MySqlCommand command2 = new MySqlCommand("select * from student2;select * from student", con);
             con.Open();
             int rowsAffected = command1.ExecuteNonQuery();
             MySqlDataReader reader = command2.ExecuteReader();
             while (reader.HasRows)
             {
                 while (reader.Read())
                 {
                     Console.WriteLine(reader.GetString(0)+" "+ reader.GetString(1)+" "+ reader.GetString(2));
                 }
                 reader.NextResult();
             }
             dataAdapter.Fill(ds);
             con.Close();
             Console.WriteLine("dataset");
             foreach (DataRow row in ds.Tables[0].Rows)
             {
                 Console.WriteLine(row[0] + " " + row[1] + " " + row[2] + " " + row[3]);
             }
         }*/
        /*using (var con = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select * from student2", con);
            MySqlCommand command1 = new MySqlCommand("delete from  student2 where Age=22", con);
            MySqlCommand command2 = new MySqlCommand("select * from student2;select * from student", con);
            dataAdapter.Fill(ds);
            Console.WriteLine("Before");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine(row[0] + " " + row[1] + " " + row[2] + " " + row[3]);
            }
            con.Open();
            int rowsAffected = command1.ExecuteNonQuery();
            Console.WriteLine($"RowsAffected = { rowsAffected}");
            MySqlDataReader reader = command2.ExecuteReader();
            Console.WriteLine("After");
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2)+" "+reader.GetInt32(3));
                }
                reader.NextResult();
            }
            con.Close();
        }*/
        /*using (var con = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("delete from student2 where Age=22",con);
            MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter("select * from student2", con);
            DataTable dt = new DataTable();
             dataAdapter2.Fill(ds);
            Console.WriteLine("Before");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine(row[0] + " " + row[1] + " " + row[2] + " " + row[3]);
            }
            dataAdapter.Fill(dt);
            ds.Clear();
            dataAdapter2.Fill(ds);
            Console.WriteLine("After");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine(row[0] + " " + row[1] + " " + row[2] + " " + row[3]);
            }
        }*/

        /*Console.WriteLine("Enter the value to insert : ");
        var items=new List<string>();
        while(true)
        {
    
            string line = Console.ReadLine();
            if (line == "exit")
            {
                break;
            }
            items.Add(line);
        }
        InsertToTable(items);*/

        /*Console.WriteLine("Enter the Student id to get details : ");
        int id = int.Parse(Console.ReadLine());
        var data = GetDataById(id);
        Console.WriteLine(data[0]+" " + data[1]+" " + data[2]+" "+data[3]);*/

        /*GetData();*/
        /*Console.WriteLine("Enter the id : ");
        int id=int.Parse(Console.ReadLine());
        GetDataById(id);*/
        /*using (var con = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
        {

            MySqlCommand cmd = new MySqlCommand("select count(*) from student2", con);
            con.Open();
            var x = cmd.ExecuteScalar();
            Console.WriteLine("No of rows in table = {0}",x);
            con.Close();
        }*/

        /*using (var con = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
        {

            MySqlDataAdapter adapter = new MySqlDataAdapter("Select * from student2", con);
            adapter.UpdateCommand = new MySqlCommand("update student2 set Fname=@name where id=@id",con);
            adapter.UpdateCommand.Parameters.Add("@name",MySqlDbType.VarChar,45,"Fname");
            MySqlParameter parameter = adapter.UpdateCommand.Parameters.Add("@id", MySqlDbType.Int32);
            parameter.SourceColumn = "Id";
            parameter.SourceVersion = DataRowVersion.Original;
            adapter.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine(row[0] + " " + row[1] + " " + row[2] + " " + row[3]);
            }
            DataRow dRow = ds.Tables[0].Rows[7];
            dRow["Fname"] = "Sujeet";
            adapter.Update(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine(row[0] + " " + row[1] + " " + row[2] + " " + row[3]);
            }

        }*/

        

        using (var con = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
        {

            MySqlDataAdapter adapter = new MySqlDataAdapter("Select * from student2", con);

            adapter.UpdateCommand = new MySqlCommand("update student2 set Fname=@name where Fname=@IName", con);

            adapter.UpdateCommand.Parameters.Add("@name", MySqlDbType.VarChar, 45, "Fname");

            MySqlParameter parameter = adapter.UpdateCommand.Parameters.Add("@IName", MySqlDbType.VarChar);
            parameter.SourceColumn = "Fname";
            parameter.SourceVersion = DataRowVersion.Original;

            adapter.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine(row[0] + " " + row[1] + " " + row[2] + " " + row[3]);
            }

            DataRow dRow = ds.Tables[0].Rows[7];
            dRow["Fname"] = "Suj";

            adapter.Update(ds);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine(row[0] + " " + row[1] + " " + row[2] + " " + row[3]);
            }

        }

        Console.ReadLine();
    }
    /*public static void InsertToTable(List<string> items) 
    {
        using(var con= new MySql.Data.MySqlClient.MySqlConnection(connectionString))
        {
            MySqlDataAdapter adapter1 = new MySqlDataAdapter("select * from student2", con);
            
            DataSet ds1 = new DataSet();
    
            adapter1.Fill(ds1);
            Console.WriteLine("Before");
            foreach (DataRow row in ds1.Tables[0].Rows)
            {
                Console.WriteLine(row[0] + " " + row[1] + " " + row[2] + " " + row[3]);
            }
            con.Open();
            MySqlCommand cmd = new MySqlCommand($"insert into student2() values({int.Parse(items[0])},'{items[1]}','{items[2]}',{int.Parse(items[3])})", con);
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            ds1.Clear();
            adapter1.Fill(ds1);
            Console.WriteLine("After");
;            foreach (DataRow row in ds1.Tables[0].Rows)
            {
                Console.WriteLine(row[0] + " " + row[1] + " " + row[2] + " " + row[3]);
            }
        }
    }*/

    /*public static List<String> GetDataById(int id)
    {
        List<String> list = new List<String>();
        using(var con = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter($"select * from student2 where id={id}", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                list.Add(row[0].ToString());
                list.Add(row[1].ToString());
                list.Add(row[2].ToString());
                list.Add(row[3].ToString());
            }
        }
        return list;
    }*/

    /*public static void GetData()
    {
        using (var con = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
        {
            DataSet ds=new DataSet();
            MySqlCommand cmd =new MySqlCommand("getData",con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine(row[0] + " " + row[1] + " " + row[2] + " " + row[3]);
            }
        }
    }*/
    /*public static void GetDataById(int id)
    {
        using (var con = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
        {
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand("getDataById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@paraid", id);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine(row[0] + " " + row[1] + " " + row[2] + " " + row[3]);
            }
        }
    }*/
}