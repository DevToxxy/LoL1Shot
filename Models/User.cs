using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoL1Shot.Models
{
    public class User
    {
        [Display(Name = "Nazwa Użytkownika")]
        [Required(ErrorMessage = "Pole 'Nazwa Użytkownika' jest obowiązkowe")]
        [MinLength(6, ErrorMessage = "Minimum number of characters that can be entered is 6")]
        [MaxLength(50, ErrorMessage = "Maximum number of characters that can be entered is 50")]
        public string userName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Pole 'Email; jest obowiązkowe")]
        [MaxLength(50, ErrorMessage = "Maximum number of characters that can be entered is 50")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Pole 'Hasło' jest obowiązkowe")]
        [MinLength(6, ErrorMessage = "Minimum number of characters that can be entered is 6")]
        [MaxLength(50, ErrorMessage = "Maximum number of characters that can be entered is 50")]
        [DataType(DataType.Password)]
        public string password { get; set; }

    }
}
