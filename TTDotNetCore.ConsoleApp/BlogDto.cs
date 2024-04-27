using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TTDotNetCore.ConsoleApp;

[Table("Tbl_Blog")]  // mapping with table and c# object < BlogDto >
public class BlogDto
{
    [Key] // primary key
    public int BlogID { get; set; }
    public string BlogTitle { get; set; }
    public string BlogAuthor { get; set; }
    public string BlogContent { get; set; }

}
// public record BlogEntity(int BlogID, string BlogTitle, string BlogAuthor, string BlogContent);
