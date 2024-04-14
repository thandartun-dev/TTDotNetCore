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

    public void Edit(int id)
    {
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();

        string query = "select * from Tbl_Blog where BlogId = @BlogId";
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", id);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sqlDataAdapter.Fill(dt);


        connection.Close();

        if (dt.Rows.Count == 0)
        {
            Console.WriteLine("No data found");
            return;
        }

        DataRow dr = dt.Rows[0];

        Console.WriteLine("Blog ID => " + dr["BlogId"]);
        Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
        Console.WriteLine("Blog Authour => " + dr["BlogAuthor"]);
        Console.WriteLine("Blog Content => " + dr["BlogContent"]);
        Console.WriteLine("--------------------------------------");

    }

    public void Create(string title, string author, string content)
    {
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

        connection.Open();

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

        string message = result > 0 ? "Saving Successful" : "Saving Failed";
        Console.WriteLine(message);
    }

    public void Update(int id, string title, string author, string content)
    {
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();

        string query = @"UPDATE [dbo].[Tbl_Blog]
                    SET
                        [BlogTitle] = @BlogTitle,
                        [BlogAuthor] = @BlogAuthor,
                        [BlogContent] = @BlogContent
                    WHERE
                        BlogId = @BlogId";
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", id);
        cmd.Parameters.AddWithValue("@BlogTitle", title);
        cmd.Parameters.AddWithValue("@BlogAuthor", author);
        cmd.Parameters.AddWithValue("@BlogContent", content);
        int result = cmd.ExecuteNonQuery();

        connection.Close();

        string message = result > 0 ? "Updating Successful." : "Updating Failed.";
        Console.WriteLine(message);
    }

    public void Delete(int id)
    {
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();

        string query = @"delete from Tbl_Blog where BlogId = @BlogId";
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", id);
        int result = cmd.ExecuteNonQuery();

        connection.Close();

        string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
        Console.WriteLine(message);
    }




}
