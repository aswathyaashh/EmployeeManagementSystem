using System.ComponentModel.DataAnnotations;

namespace Mini_Project_Sample.Models
{
    public class AdminMvc
    {
        [Required(ErrorMessage = "Please Enter Username")]
        public string? UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
