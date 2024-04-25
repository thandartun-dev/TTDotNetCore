using System;
using System.Data;
using System.Data.SqlClient;
using TTDotNetCore.ConsoleApp;

Console.WriteLine("Hello, World!");

// SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
// stringBuilder.DataSource = "localhost"; // server Name
// stringBuilder.InitialCatalog = "DotNetTrainingBatch4";  //db name
// stringBuilder.UserID = "sa";
// stringBuilder.Password = "Sasa@123";
// stringBuilder.TrustServerCertificate = true; // Set to true to trust the server's certificate
// SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);

// connection.Open();
// Console.WriteLine("Connection Open");

// string query = "SELECT * FROM Tbl_Blog";
// SqlCommand cmd = new SqlCommand(query, connection); // Associate the command with the connection
// SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
// DataTable dt = new DataTable();
// sqlDataAdapter.Fill(dt);

// connection.Close();
// Console.WriteLine("Connection Close");

// foreach (DataRow dr in dt.Rows)
// {
//     Console.WriteLine("Blog Id => " + dr["BlogID"]);
//     Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
//     Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
//     Console.WriteLine("Blog Content => " + dr["BlogContent"]);
//     Console.WriteLine("-------------------------------");
// }

// AdoDotNetExample adoDotNetExample = new AdoDotNetExample();

// adoDotNetExample.Read();

// adoDotNetExample.Create("title", "author", "content");
// adoDotNetExample.Update(1002, "test title", "test author", "test content");
// adoDotNetExample.Update(1, "adfad", "sgg", "deeaf");
// adoDotNetExample.Delete(1);
// adoDotNetExample.Edit(1);
// adoDotNetExample.Edit(2);

DapperExample dapperExample = new DapperExample();
dapperExample.Run();


Console.ReadKey();
