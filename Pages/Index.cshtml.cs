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

namespace Projekt.NET.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void OnGet()
        {
            RiotApi api = RiotApi.GetDevelopmentInstance(_configuration.GetValue<string>("RiotAPIKey"));

            var versions = api.StaticData.Versions.GetAllAsync().Result;

            foreach (var item in api.StaticData.Items.GetAllAsync(versions[0]).Result.Items)
            {
                string g = item.Value.Name;
            }
        }
    }
}
