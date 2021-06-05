using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoL1Shot.Models
{
    public class Category
    {
        [BindProperty]
        [Display(Name = "Nazwa kategorii")]
        [Required(ErrorMessage = "Pole 'Nazwa kategorii' jest obowiązkowe")]
        public string name { get; set; }

        public Category() { }

        public Category(string name)
        {
            this.name = name;
        }
    }
}
