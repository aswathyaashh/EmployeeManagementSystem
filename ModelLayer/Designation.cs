using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class Designation
    {
        [Key]
        public string? Id { get; set; }
        public string? DesignationType { get; set; }
    }
}
