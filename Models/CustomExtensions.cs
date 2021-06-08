using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoL1Shot.Models.CustomExtensions
{
    public static class IConfigurationExtensions
    {
        public static string GetSpellImagesDirPath(this IConfiguration configuration)
        {
            return configuration.GetSection("DataDragon").GetSection("SpellImagesPath").Value;
        }

        public static string GetChampionImagesDirPath(this IConfiguration configuration)
        {
            return configuration.GetSection("DataDragon").GetSection("ChampionImagesPath").Value;
        }
    }
}
