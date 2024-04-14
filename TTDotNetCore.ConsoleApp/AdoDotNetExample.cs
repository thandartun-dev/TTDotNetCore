using System;
using System.Data;
using System.Data.SqlClient;

namespace
TTDotNetCore.ConsoleApp;

public class AdoDotNetExample
{
    private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = "localhost", // server Name
        InitialCatalog = "DotNetTrainingBatch4",  //db name
        UserID = "sa",
        Password = "Sasa@123",
        TrustServerCertificate = true, // Set to true to trust the server's certificate
    };
    public void Read()
    {
        // SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
        // stringBuilder.DataSource = "localhost"; // server Name
        // stringBuilder.InitialCatalog = "DotNetTrainingBatch4";  //db name
        // stringBuilder.UserID = "sa";
        // stringBuilder.Password = "Sasa@123";
        // stringBuilder.TrustServerCertificate = true; // Set to true to trust the server's certificate
        // SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);

        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

        connection.Open();
        Console.WriteLine("Connection Open");

        string query = "SELECT * FROM Tbl_Blog";
        SqlCommand cmd = new SqlCommand(query, connection); // Associate the command with the connection
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sqlDataAdapter.Fill(dt);

        connection.Close();
        Console.WriteLine("Connection Close");

        foreach (DataRow dr in dt.Rows)
        {
            Console.WriteLine("Blog Id => " + dr["BlogID"]);
            Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
            Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
            Console.WriteLine("Blog Content => " + dr["BlogContent"]);
            Console.WriteLine("-------------------------------");
        }
    }

    public void Create(string title, string author, string content)
    {
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

        connection.Open();
        Console.WriteLine("Connection Open");

        string query = @"INSERT INTO [dbo].[Tbl_Blog]
         (
            [BlogTitle]
            ,[BlogAuthor]
            ,[BlogContent]
         )
         VALUES
         (@BlogTitle
         ,@BlogAuthor
         ,@BlogContent)";
        SqlCommand cmd = new SqlCommand(query, connection); // Associate the command with the connection
        cmd.Parameters.AddWithValue("@BlogTitle", title);
        cmd.Parameters.AddWithValue("@BlogAuthor", author); // Correct parameter name
        cmd.Parameters.AddWithValue("@BlogContent", content); // Correct parameter name

        int result = cmd.ExecuteNonQuery();

        connection.Close();
        Console.WriteLine("Connection Close");
    }


}
