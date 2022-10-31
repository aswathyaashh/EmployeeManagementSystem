using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    public class EmployeeDetails
    {
        [Required(ErrorMessage = "Please select the Title")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(5)]
        public string? Title { get; set; }


        [Required(ErrorMessage = "Please enter your First Name"), MaxLength(20)]
        [RegularExpression("^[A-Za-z]+$")]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }


        [Required(ErrorMessage = "Please enter your Last Name"), MaxLength(20)]
        [RegularExpression("^[A-Za-z]+$")]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }


        [Required(ErrorMessage = "Please select the Gender")]
        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string? Gender { get; set; }


        [Key]
        [Required(ErrorMessage = "User Name is required")]
        [RegularExpression("^[A-Za-z0-9]+$")]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "User Name")]
        public string? UserName { get; set; }


        [Required(ErrorMessage = "Password is required"), MinLength(10)]
        [DataType(DataType.Password)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Password")]
        public string? Password { get; set; }


        [Compare("Password")]
        [Required(ErrorMessage = "Confirm Password is required"), MinLength(10)]
        [Display(Name = "Confirm Password")]
        [Column(TypeName = "VARCHAR")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }


        [Display(Name = "Email Id")]
        [RegularExpression(@"^\w+(@gmail\.com)$")]
        [Column(TypeName = "VARCHAR")]
        public string? EmailId { get; set; }


        [Display(Name = "Mobile number")]
        [RegularExpression("^[0-9]{10}$")]
        [StringLength(10)]
        public string? Mobile { get; set; }


        [Required(ErrorMessage = "Please enter your Address")]
        [Display(Name = "Address")]
        [StringLength(50)]
        public string? Address { get; set; }


        [Required(ErrorMessage = "Please select your country")]
        [Display(Name = "Country")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(60)]
        public string? Country { get; set; }


        [Required(ErrorMessage = "Please enter your salary")]
        [Display(Name = "Salary")]
        [Range(10000, 2500000)]
        public int Salary { get; set; }


        [Required(ErrorMessage = "Please enter your designation")]
        [StringLength(30)]
        [Column(TypeName = "VARCHAR")]
        public string? Designation { get; set; }


        [Display(Name = "Upload image")]
        public string? UploadImage { get; set; }
    }
}
