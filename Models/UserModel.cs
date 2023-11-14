using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecc.Models
{
    [Table("users")]
    public class UserModel
    {
        public Guid Id { get; set; }
        [Required]
        public string ?FirstName { get; set; }
        [Required]
        public string ?LastName { get; set; }
        [Required]
        public string ?Email { get; set; }
        [Required]
        public string ?Password { get; set; }
        public string ?Cep {get; set;}
        public Guid? LocationId { get; set; }
        public LocationModel? LocationModel { get; set; }
    }
}
