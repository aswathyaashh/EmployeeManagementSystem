using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Mini_Project_Sample.Models
{
    public class TempClass
    {

        [Required]
        [Display(Name = "Title")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Please enter First Name"), MaxLength(20)]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Please enter Last Name"), MaxLength(20)]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string? Gender { get; set; }
       
        [Required(ErrorMessage = "Please enter User Name")]
        [Display(Name = "User Name")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Please enter Password"), MinLength(10)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
        [Display(Name = "Email Id")]

        //[RegularExpression(@"^\w+([-+.']\w+)@\w+([-.]\w+)\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid")]
        public string? EmailId { get; set; }
        [Display(Name = "Mobile number")]

        public string? Mobile { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string? Address { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string? Country { get; set; }
        [Required]
        [Display(Name = "Salary")]
        public int Salary { get; set; }
        [Required]
        [Display(Name = "Designation")]
        public string? Designation { get; set; }
        [Display(Name = "Upload image")]
        public string? UploadImage { get; set; }
    }
}
