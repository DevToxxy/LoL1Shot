using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoL1Shot.Models;

namespace LoL1Shot.Data_Access_Layer
{
    public interface IActionDB
    {
        public string GetChampionKeyByName(string name);
        public Champion GetChampionByName(string name);
        public Champion GetChampionByKey(string keyName);
        public List<Champion> GetChampions { get; }
        public Dictionary<string, string> GetChampionsKeys { get; }
        public string GetAutoAttackImageURL { get; }
        public string GetMissingImageURL { get; }
        public string GetSpellImageURL(string championKeyName, SpellKey spellKey);
        public string GetChampionImageURL(string championKeyName);
        public string GetChampionSplashURL(string championKeyName);

    }
}
