using System.ComponentModel.DataAnnotations.Schema;

namespace Ecc;

[Table("categories")]
public class CategoryModel 
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    
}