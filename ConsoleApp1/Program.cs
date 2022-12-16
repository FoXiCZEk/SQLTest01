using System;
using System.Data;
using System.Data.SqlClient;

var wStopwatch = new System.Diagnostics.Stopwatch();
var conn = new SqlConnection ("Server=localhost;User=sa;Password=Ostrava123;database=master");
var query = "SELECT name, database_id, create_date FROM sys.databases; "; 
var myCommand = new SqlCommand(query, conn);
wStopwatch.Start();
try
{
    conn.Open();
    myCommand.ExecuteNonQuery();
    using (SqlDataReader reader = myCommand.ExecuteReader())
    {
        while (reader.Read())
        {
            Console.WriteLine(String.Format("{0} {1} {2}",reader["database_id"], reader["name"], reader["create_date"]));
        }
    }

}
catch (System.Exception err)
{
    err.ToString();
}finally
{
    if (conn.State == ConnectionState.Open)
    {
        conn.Close();
    }
}

wStopwatch.Stop();

Console.WriteLine($"Execution Time: {wStopwatch.ElapsedMilliseconds} ms");
