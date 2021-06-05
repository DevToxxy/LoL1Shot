using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoL1Shot.Models;

namespace LoL1Shot.Data_Access_Layer
{
    public interface IActionDB
    {
        public string GetChampionId(string name);
        public Champion GetChampion(string name);
        public List<Champion> GetChampions { get; }
    }
}
