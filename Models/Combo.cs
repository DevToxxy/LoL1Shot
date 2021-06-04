using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoL1Shot.Models
{
    public class Combo
    {
        [Display(Name = "Nazwa combo")]
        public string name { get; set; }

        [Display(Name = "Kategorie")]
        public List<Category> categories { get; set; }

        public Combo(string name, List<Category> categories)
        {
            this.categories = categories;
            this.name = name;
        }
    }
}
