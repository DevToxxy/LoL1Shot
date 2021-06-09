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
        public Champion damageDealer { get; set; }

        public List<Champion> defenders { get; set; }

        private readonly IActionDB _actionDB;
        public readonly IConfiguration _configuration;
        public string image;

        public ClashModel(IConfiguration configuration, IActionDB actionDB)
        {
            _actionDB = actionDB;
            _configuration = configuration;
        }

        public void OnGet()
        {
            defenders = _actionDB.GetChampions;
        }

        private bool IsOneShot(Combo combo, Champion defender)
        {
            throw new NotImplementedException();
        }
    }
}
