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

namespace LoL1Shot.Pages.CRUD_Combo
{
    public class AddModel : PageModel
    {
        private IActionDB _actionDB;
        private readonly DataContext _context;

        [BindProperty]
        public Combo newCombo { get; set; }

        IComboDB comboDB;

        public IList<Champion> championList = new List<Champion>(); 

        public AddModel(IComboDB _comboDB, IActionDB actionDB, DataContext context)
        {
            comboDB = _comboDB;
            _actionDB = actionDB;
            _context = context;
        }

        public void OnGet()
        {
            championList = _context.Champions.ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("/CRUD_Combo/Add");
            }
            comboDB.Add(newCombo);
            return RedirectToPage("/Index");
        }
    }
}
