using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LoL1Shot.Models
{
    [Keyless]
    public class Combo
    {
        [BindProperty]
        [Display(Name = "Nazwa combo")]
        [Required(ErrorMessage = "Pole 'Nazwa combo' jest obowiązkowe")]
        public string name { get; set; }

        //[NotMapped]
        //[BindProperty]
        //[Display(Name = "Kategoria")]
        //[Required(ErrorMessage = "Pole 'Kategoria' jest obowiązkowe")]
        //public List<Category> categories { get; set; }

        [BindProperty]
        [Display(Name = "Lista akcji - string")]
        [Required(ErrorMessage = "Pole 'Lista akcji - string' jest obowiązkowe")]
        public string actionsString { get; set; }

        [BindProperty]
        [Display(Name = "Nazwa Championa")]
        [Required(ErrorMessage = "Pole 'Nazwa Championa' jest obowiązkowe")]
        public string championKey { get; set; }


        [BindProperty]
        [NotMapped]
        [Display(Name = "Lista akcji")]
        public List<Action> actions { get; set; }

        public Combo() { }

        public Combo(string name, /*List<Category> categories,*/ string actionsString,string championKey/*, List<Action> actions*/)
        {
            this.name = name;
            //this.categories = categories;
            this.actionsString = actionsString;
            this.championKey = championKey;
            //this.actions = actions; //liste akcji inicjalizujemy pozniej, na podstawie stringa z bazy danych
                                      //pobieramy informacje o championie i umieszczamy odpowiednie wartosci z json'a do listy

        }
    }
}
