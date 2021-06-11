using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LoL1Shot.Models;
using LoL1Shot.Data_Access_Layer;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using LoL1Shot.Data;
using LoL1Shot.Models.CustomExtensions;

namespace LoL1Shot.Pages.CRUD_Combo
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public Combo newCombo { get; set; }
        public IList<Champion> champions;

        private IActionDB _actionDB;
        private IComboDB comboDB;
        private readonly DataContext _context;

        public AddModel(IComboDB _comboDB, IActionDB actionDB, DataContext context)
        {
            comboDB = _comboDB;
            _actionDB = actionDB;
            _context = context;
        }

        public void OnGet()
        {
            champions = _context.Champions.ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("/CRUD_Combo/Add");
            }

            champions = _actionDB.GetChampions;

            List<Champion> killedByCombo = new List<Champion>();

            foreach (Champion champion in champions)
            {
                if(champion.IsKilled(_actionDB.GetActions(
                    champion.KeyName, 
                    newCombo.actionsString
                    )
                    .GetFullDamage()
                    ))
                {
                    killedByCombo.Add(champion);
                }
            }

            newCombo.SetKilledByComboKeys(killedByCombo);
            comboDB.Add(newCombo);
            return RedirectToPage("/Index");
        }
    }
}
