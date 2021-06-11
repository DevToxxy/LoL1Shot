using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoL1Shot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LoL1Shot.Data_Access_Layer;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace LoL1Shot.Pages.Main
{
    public class ClashModel : PageModel
    {
        [BindProperty]
        public Combo Combo { get; set; }

        public readonly IActionDB _actionDB;
        public readonly IComboDB _comboDB;
        public readonly IConfiguration _configuration;
        public string[] killedByComboKeys;

        public ClashModel(IConfiguration configuration, IActionDB actionDB, IComboDB comboDB)
        {
            _actionDB = actionDB;
            _configuration = configuration;
            _comboDB = comboDB;
            killedByComboKeys = null;
        }

        public void OnGet(int id)
        {
            Combo = _comboDB.Get(id);
            Combo.id = id;
            
            if(Combo.killedByComboKeys.Split(',').Length > 0)
                killedByComboKeys = Combo.killedByComboKeys.Split(',');
        }
    }
}
