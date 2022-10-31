using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    public class Designation
    {
        [Key]
        public string? Id { get; set; }

        [Required(ErrorMessage = "Designation is  Required")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public string? DesignationType { get; set; }
    }
}
