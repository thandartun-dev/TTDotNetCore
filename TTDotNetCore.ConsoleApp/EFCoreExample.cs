using System;
using System.Linq;

namespace TTDotNetCore.ConsoleApp;

internal class EFCoreExample
{
    private readonly AppDbContext db = new AppDbContext();
    public void Run()
    {
        // Read();
        // Edit(1);
        // Edit(11);
        // Create("title", "author", "content");
        // Update(19, "title1", "author1", "content1");
        Delete(21);

    }

    private void Read()
    {
        var lst = db.Blogs.ToList();

        foreach (BlogDto item in lst)
        {
            Console.WriteLine(item.BlogID);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("-------------------------------");
        }
    }

    private void Edit(int id)
    {
        var item = db.Blogs.FirstOrDefault(x => x.BlogID == id);
        if (item is null)
        {
            Console.WriteLine("No data found.");
            return;
        }

        Console.WriteLine(item.BlogID);
        Console.WriteLine(item.BlogTitle);
        Console.WriteLine(item.BlogAuthor);
        Console.WriteLine(item.BlogContent);

        // foreach(BlogDto x in db.Blogs)
        // {
        //     if(x.BlogID == id) return;
        // }
    }

    public void Create(string title, string author, string content)
    {
        var item = new BlogDto
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content,

        };

        db.Blogs.Add(item); // insert query
        int result = db.SaveChanges(); //execute query

        string message = result > 0 ? "Saving Successful" : "Saving Failed";
        Console.WriteLine(message);

    }

    public void Update(int id, string title, string author, string content)
    {
        var item = db.Blogs.FirstOrDefault(x => x.BlogID == id);
        if (item is null)
        {
            Console.WriteLine("No data found.");
            return;
        }

        item.BlogTitle = title;
        item.BlogAuthor = author;
        item.BlogContent = content;

        int result = db.SaveChanges();

        string message = result > 0 ? "Updating Successful." : "Updating Failed.";
        Console.WriteLine(message);
    }

    public void Delete(int id)
    {
        var item = db.Blogs.FirstOrDefault(x => x.BlogID == id);
        if (item is null)
        {
            Console.WriteLine("No data found.");
            return;
        }

        db.Blogs.Remove(item);
        int result = db.SaveChanges();

        string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
        Console.WriteLine(message);
    }

}
