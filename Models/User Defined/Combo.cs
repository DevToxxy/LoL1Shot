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
        [Display(Name = "Id")]
        public int id { get; set; }

        [BindProperty]
        [Display(Name = "Nazwa kombinacji")]
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
        //nie dziala, a nawet jakby dzialalo to przepuszcza wiecej niz 8 liter
        //[RegularExpression(@"^(?!.*?([QWERA])*?\1)[QWERA](?:,[QWERA])*$", ErrorMessage = "Tylko: Q,W,E,R,A. Separacja przecinkami. MAX 8 akcji.")]

        public string actionsString { get; set; }

        [BindProperty]
        [Display(Name = "Imię bohatera")]
        [Required(ErrorMessage = "Pole 'Imię bohatera' jest obowiązkowe")]
        public string championKey { get; set; }

        [NotMapped]
        [Display(Name = "1Shots")]
        public string killedByComboKeys { get; set; }

        public Combo() { }

        public Combo(int id, string name, string actionsString, string championKey, string killedByComboKeys)
        {
            this.id = id;
            this.name = name;
            this.actionsString = actionsString;
            this.championKey = championKey;
            this.killedByComboKeys = killedByComboKeys;
        }

        public void SetKilledByComboKeys(List<Champion> champions)
        {
            killedByComboKeys = "";
            foreach (Champion champion in champions)
            {
                killedByComboKeys += champion.KeyName + ",";
            }
        }
    }
}
