using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        IComboDB comboDB;
        public UpdateModel(IComboDB _comboDB)
        {
            comboDB = _comboDB;
        }
        public void OnGet()
        {
            combo = comboDB.Get(id);
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("/CRUD_Combo/Update");
            }
            comboDB.Update(combo);
            return RedirectToPage("/Index");
        }
    }
}
