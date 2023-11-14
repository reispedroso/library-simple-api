using System.ComponentModel.DataAnnotations.Schema;

namespace Ecc;

[Table("authors")]
public class AuthorModel {
    public Guid AuthorId { get; set; }   
    public string? Name { get; set; }
}