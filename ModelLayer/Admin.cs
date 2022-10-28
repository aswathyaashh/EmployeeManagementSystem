using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Admin
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        //[Required]
        //public string? Confirm_Password { get; set; }
    }
}
