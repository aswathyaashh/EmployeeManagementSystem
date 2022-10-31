using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using Mini_Project_Sample;

namespace Mini_Project_Sample.Models
{
    public class DesignationMvc
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Designation is  Required")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public string? DesignationType { get; set; }
    }
}
