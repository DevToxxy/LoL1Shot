using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoL1Shot.Data;
using LoL1Shot.Data_Access_Layer;
using LoL1Shot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LoL1Shot.Models.CustomExtensions;

namespace LoL1Shot.Pages.CRUD_Combo
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public Combo combo { get; set; }

        [BindProperty]
        public int id { get; set; }

        public IList<Champion> champions;
        private IComboDB _comboDB;
        private IActionDB _actionDB;

        public UpdateModel(IComboDB comboDB, DataContext context, IActionDB actionDB)
        {
            _comboDB = comboDB;
            _actionDB = actionDB;
            champions = context.Champions.ToList();
        }

        public void OnGet(int id)
        {
            combo = _comboDB.Get(id);
            combo.id = id;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("/CRUD_Combo/Update");
            }

            combo.id = id;
            champions = _actionDB.GetChampions;

            List<Champion> killedByCombo = new List<Champion>();

            foreach (Champion champion in champions)
            {
                if (champion.IsKilled(_actionDB.GetActions(
                    champion.KeyName,
                    combo.actionsString
                    )
                    .GetFullDamage()
                    ))
                {
                    killedByCombo.Add(champion);
                }
            }

            combo.SetKilledByComboKeys(killedByCombo);
            
            _comboDB.Update(combo);

            return RedirectToPage("/Index");
        }
    }
}
