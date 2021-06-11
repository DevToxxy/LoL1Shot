using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoL1Shot.Models.CustomExtensions
{
    public static class IConfigurationExtensions
    {
        public static string GetSpellImagesURL(this IConfiguration configuration)
        {
            return configuration.GetSection("DataDragonURLs").GetSection("SpellImages").Value;
        }

        public static string GetChampionImagesURL(this IConfiguration configuration)
        {
            return configuration.GetSection("DataDragonURLs").GetSection("ChampionImages").Value;
        }

        public static string GetChampionSplashesURL(this IConfiguration configuration)
        {
            return configuration.GetSection("DataDragonURLs").GetSection("ChampionSplash").Value;
        }
    }

    public static class ActionListExtensions
    {
        public static double GetFullDamage(this List<Action> actions)
        {
            double fullDamage = 0;
            foreach (Action action in actions)
            {
                fullDamage += action.GetDamage;
            }
            return fullDamage;
        }
    } 
        
}
