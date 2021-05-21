using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoL1Shot.Models
{
    public class User
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Field is required")]
        [MinLength(6, ErrorMessage = "Minimum number of characters that can be entered is 6")]
        [MaxLength(50, ErrorMessage = "Maximum number of characters that can be entered is 50")]
        public string userName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Field is required")]
        [MaxLength(50, ErrorMessage = "Maximum number of characters that can be entered is 50")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Field is required")]
        [MinLength(6, ErrorMessage = "Minimum number of characters that can be entered is 6")]
        [MaxLength(50, ErrorMessage = "Maximum number of characters that can be entered is 50")]
        [DataType(DataType.Password)]
        public string password { get; set; }

    }
}
