using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoL1Shot.Models
{
    public class Combo
    {
        [BindProperty]
        [Display(Name = "Nazwa combo")]
        [Required(ErrorMessage = "Pole 'Nazwa combo' jest obowiązkowe")]
        public string name { get; set; }

        //[BindProperty]
        //[Display(Name = "Kategoria")]
        //[Required(ErrorMessage = "Pole 'Kategoria' jest obowiązkowe")]
        //public List<Category> categories { get; set; }

        [BindProperty]
        [Display(Name = "Lista akcji")]
        [Required(ErrorMessage = "Pole 'Lista akcji' jest obowiązkowe")]
        public List<Action> actions { get; set; }

        [BindProperty]
        [Display(Name = "Nazwa Championa")]
        [Required(ErrorMessage = "Pole 'Nazwa Championa' jest obowiązkowe")]
        public List<Action> actions { get; set; }

        public Combo() { }

        public Combo(string name, /*List<Category> categories,*/ List<Action> actions)
        {
            this.name = name;
            //this.categories = categories;
            this.actions = actions;
        }
    }
}
