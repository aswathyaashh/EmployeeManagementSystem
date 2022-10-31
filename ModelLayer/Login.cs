using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class Login
    {
        [Required(ErrorMessage = "Please Enter Username")]
        public string? UserName { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}