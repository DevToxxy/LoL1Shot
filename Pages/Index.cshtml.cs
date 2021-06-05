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
namespace Projekt.NET.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;
        private IActionDB _actionDB;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, IActionDB actionDB)
        {
            _logger = logger;
            _configuration = configuration;
            _actionDB = actionDB;
        }

        public void OnGet()
        {
        }
    }
}
