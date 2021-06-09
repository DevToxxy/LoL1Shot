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

        [NotMapped]
        [Display(Name = "Lista akcji")]
        public List<Action> actions { get; set; }

        private static List<Action> ConverActionStringToList(string actionString)
        {
            List<Action> actions = new List<Action>();

            string[] actionStrings = actionString.Split(',');
            for (int i = 0; i < actionStrings.Count(); i++)
            {
                actionStrings[i] = actionStrings[i].Replace(" ", "");

                Action actionObject;

                if (actionStrings[i] == "A")
                    actionObject = new AutoAttack();
                else
                    switch (actionStrings[i])
                    {
                        case "Q":
                            actionObject = new Spell(SpellKey.Q);
                            break;
                        case "W":
                            actionObject = new Spell(SpellKey.W);
                            break;
                        case "E":
                            actionObject = new Spell(SpellKey.E);
                            break;
                        case "R":
                            actionObject = new Spell(SpellKey.R);
                            break;
                        default:
                            throw new Exception("Nieprawidłowy symbol w actionString");
                    }

                actions.Add(actionObject);
            }

            return actions;
        }

        public Combo() { }

        public Combo(int id, string name, string actionsString, string championKey)
        {
            this.id = id;
            this.name = name;
            //this.categories = categories;
            this.actionsString = actionsString;
            this.championKey = championKey;
            //this.actions = actions; //liste akcji inicjalizujemy pozniej, na podstawie stringa z bazy danych
            //pobieramy informacje o championie i wpierdalamy odpowiednie wartosci z json'a do listy

            actions = ConverActionStringToList(actionsString);
        }
    }
}
