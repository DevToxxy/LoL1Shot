using LoL1Shot.Models;
using Microsoft.Extensions.Configuration;
using RiotSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace LoL1Shot.Data_Access_Layer
{
    public class ActionApiDB : IActionDB
    {
        private IConfiguration _configuration;
        private RiotApi _riotApi;
        private string _latestVersion;

        private Champion ConvertFromDataDragon(
            RiotSharp.Endpoints.StaticDataEndpoint.Champion.ChampionStatic championStatic)
        {
            return new Champion(
                    championStatic.Name,
                    championStatic.Id,
                    championStatic.Stats.HpPerLevel,
                    championStatic.Stats.Hp,
                    championStatic.Stats.Armor,
                    championStatic.Stats.ArmorPerLevel,
                    championStatic.Stats.SpellBlockPerLevel,
                    championStatic.Stats.AttackDamage,
                    championStatic.Stats.AttackDamagePerLevel,
                    new Models.Action(championStatic.Spells[0].Name, ActionType.Q),
                    new Models.Action(championStatic.Spells[1].Name, ActionType.W),
                    new Models.Action(championStatic.Spells[2].Name, ActionType.E),
                    new Models.Action(championStatic.Spells[3].Name, ActionType.R),
                    new Models.Action("SKĄD POBRAĆ TĘ WARTOŚĆ?", ActionType.AA)
                );
        }

        public List<Champion> GetChampions
        {
            get
            {
                List<Champion> champions = new List<Champion>();

                foreach (var champion in 
                    _riotApi.StaticData.Champions.GetAllAsync(_latestVersion).Result.Champions)
                {
                    champions.Add(ConvertFromDataDragon(champion.Value));
                }

                return champions;
            }
        }

        public ActionApiDB(IConfiguration configuration)
        {
            _configuration = configuration;
            _riotApi = RiotApi.GetDevelopmentInstance(configuration.GetValue<string>("RiotAPIKey"));
            _latestVersion = _riotApi.StaticData.Versions.GetAllAsync().Result[0];
        }

        /// <summary>
        /// Zwraca klucz championa o danej nazwie
        /// </summary>
        /// <param name="name">Imię championa</param>
        /// <returns>Klucz championa lub null jeżeli imię championa nie występuje w bazie</returns>
        public string GetChampionId(string name)
        {
            try
            {
                foreach (var champion in _riotApi.StaticData.Champions.GetAllAsync(_latestVersion).Result.Champions)
                {
                    if (champion.Value.Name == name) return champion.Value.Key;
                }
            }
            catch(RiotSharpException)
            {
                
            }

            return null;
        }

        public Champion GetChampion(string name)
        {
            try
            {
                return ConvertFromDataDragon(
                    _riotApi.StaticData.Champions.GetByKeyAsync(GetChampionId(name), _latestVersion).Result);
            }
            catch(RiotSharpException)
            {
                return null;
            }
        }
    }
}
