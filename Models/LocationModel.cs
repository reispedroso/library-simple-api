using System.ComponentModel.DataAnnotations.Schema;

namespace Ecc.Models;

[Table("location")]
public class LocationModel
{
    public Guid LocationId { get; set; }
    public string? Cep { get; set; }
    public string? Logradouro { get; set; }
    public string? Bairro { get; set; }
    public string? Localidade { get; set; }
    public string? Uf { get; set; }
    public string? Ddd { get; set; }
}