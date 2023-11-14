using System.ComponentModel.DataAnnotations.Schema;

namespace Ecc;

[Table("books")]
public class BookModel
{
    public Guid BookId { get; set; }
    public string? Name { get; set; }
    public DateTime PublishDate { get; set; } 

    [ForeignKey("CategoryId")]
    public Guid CategoryId { get; set; }
    public CategoryModel? CategoryModel { get; set; }
    [ForeignKey("AuthorId")]
    public Guid AuthorId { get; set; }
    public AuthorModel? AuthorModel { get; set; }
}
