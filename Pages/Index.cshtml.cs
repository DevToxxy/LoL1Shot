using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RiotSharp;
using RiotSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoL1Shot.Data_Access_Layer;
using LoL1Shot.Models;
using LoL1Shot.Utils;
namespace Projekt.NET.Pages
{
       [CustomFilterAttributes]
       public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;
        public readonly IActionDB _actionDB;
        IComboDB comboDB;
        public List<Combo> comboList = new List<Combo>();

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, IActionDB actionDB,IComboDB _comboDB)
        {
            _logger = logger;
            _configuration = configuration;
            _actionDB = actionDB;
            comboDB = _comboDB;
        }

        public void OnGet()
        {
            comboList = comboDB.List;
        }
    }
}
