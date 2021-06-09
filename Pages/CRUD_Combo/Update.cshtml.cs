using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoL1Shot.Data;
using LoL1Shot.Data_Access_Layer;
using LoL1Shot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoL1Shot.Pages.CRUD_Combo
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public Combo combo { get; set; }

        [BindProperty]
        public int id { get; set; }

        public IList<Champion> championList;
        private IComboDB _comboDB;

        public UpdateModel(IComboDB _comboDB, DataContext context)
        {
            this._comboDB = _comboDB;
            championList = context.Champions.ToList();
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
            _comboDB.Update(combo);

            return RedirectToPage("/Index");
        }
    }
}
