using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoL1Shot.Data_Access_Layer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoL1Shot.Pages.CRUD_Combo
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public int id { get; set; }
        IComboDB comboDB;
        public DeleteModel(IComboDB _comboDB)
        {
            comboDB = _comboDB;
        }
        public void OnGet(int _id)
        {
            comboDB.Delete(_id);

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("/CRUD_Combo/Delete");
            }
            return RedirectToPage("/Index");
        }
    }
}
