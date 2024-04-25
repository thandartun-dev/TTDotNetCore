using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace TTDotNetCore.ConsoleApp;

public class DapperExample
{
    public void Run()
    {
        Read();
        // Edit(14);
        // Edit(15);
        // Create("title", "author", "content");
        // Update(3, "title1", "author1", "content1");
        // Delete(20);
    }

    private void Read()
    {
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        List<BlogDto> lst = db.Query<BlogDto>("select * from tbl_blog").ToList(); //.ToList is execute

        foreach (BlogDto item in lst)
        {
            Console.WriteLine(item.BlogID);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("-------------------------------");
        }

        // using (IDbConnection db1 = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString))
        // {
        //     db1.
        // }

    }

    private void Edit(int id)
    {
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        var item = db.Query<BlogDto>("select * from tbl_blog where blogid = @BlogID", new BlogDto { BlogID = id }).FirstOrDefault(); //default of obj = null
        if (item is null)
        {
            Console.WriteLine("No data found.");
            return;
        }
    }

    public void Create(string title, string author, string content)
    {
        var item = new BlogDto
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content,

        };
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

        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, item);


        string message = result > 0 ? "Saving Successful" : "Saving Failed";
        Console.WriteLine(message);
    }

    public void Update(int id, string title, string author, string content)
    {
        var item = new BlogDto
        {
            BlogID = id,
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content,

        };
        string query = @"UPDATE [dbo].[Tbl_Blog]
                    SET
                        [BlogTitle] = @BlogTitle,
                        [BlogAuthor] = @BlogAuthor,
                        [BlogContent] = @BlogContent
                    WHERE
                        BlogId = @BlogId";

        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, item);

        string message = result > 0 ? "Updating Successful." : "Updating Failed.";
        Console.WriteLine(message);
    }

    public void Delete(int id)
    {
        var item = new BlogDto
        {
            BlogID = id,

        };
        string query = @"delete from Tbl_Blog where BlogId = @BlogId";

        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, item);

        string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
        Console.WriteLine(message);
    }


}
