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
            //dostęp do danych championa poprzez
            //championStatic.Stats.MpPerLevel;
            //championStatic.Spells[0].EffectBurns;

            Spell q = new Spell(championStatic.Spells[0].Name, SpellKey.Q);
            Spell w = new Spell(championStatic.Spells[1].Name, SpellKey.W);
            Spell e = new Spell(championStatic.Spells[2].Name, SpellKey.E);
            Spell r = new Spell(championStatic.Spells[3].Name, SpellKey.R);

            return new Champion(
                    championStatic.Name,
                    championStatic.Key,
                    championStatic.Stats.HpPerLevel,
                    championStatic.Stats.Hp,
                    championStatic.Stats.Armor,
                    championStatic.Stats.ArmorPerLevel,
                    championStatic.Stats.SpellBlockPerLevel,
                    q, 
                    w, 
                    e, 
                    r,
                    new AutoAttack(
                        championStatic.Stats.AttackDamage,
                        championStatic.Stats.AttackDamagePerLevel)
                );
        }

        public List<Champion> GetChampions
        {
            get
            {
                List<Champion> champions = new List<Champion>();

                try
                {
                    foreach (var champion in 
                        _riotApi.StaticData.Champions.GetAllAsync(_latestVersion).Result.Champions)
                    {
                        champions.Add(ConvertFromDataDragon(champion.Value));
                    }
                }
                catch (RiotSharpException)
                {
                    throw new Exception("Odmowa dostępu do danych API (powodem może być błędny parametr" +
                        " lub odwołanie do nieistniejącej strony URL)");
                }

                return champions;
            }
        }


        public Dictionary<string, string> GetChamionsKeys
        {
            get
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

                try
                {
                    foreach (var champion in
                        _riotApi.StaticData.Champions.GetAllAsync(_latestVersion).Result.Champions)
                    {
                        keyValuePairs.Add(champion.Value.Key,champion.Value.Name);
                    }
                }
                catch (RiotSharpException)
                {
                    throw new Exception("Odmowa dostępu do danych API (powodem może być błędny parametr" +
                        " lub odwołanie do nieistniejącej strony URL)");
                }

                return keyValuePairs;
            }
        }

        public ActionApiDB(IConfiguration configuration)
        {
            _configuration = configuration;
            _riotApi = RiotApi.GetDevelopmentInstance(configuration.GetValue<string>("RiotAPIKey"));
            _latestVersion = _riotApi.StaticData.Versions.GetAllAsync().Result[0];
        }

        /// <summary>
        /// Zwraca klucz championa o danej nazwie (klucz, nie numer id)
        /// </summary>
        /// <param name="name">Imię championa</param>
        /// <returns>Klucz championa lub null jeżeli imię championa nie występuje w bazie</returns>
        public string GetChampionKeyByName(string name)
        {
            try
            {
                foreach (var champion in _riotApi.StaticData.Champions.GetAllAsync(_latestVersion).Result.Champions)
                {
                    if (champion.Value.Name == name) return champion.Value.Key;
                }
            }
            catch (RiotSharpException)
            {
                throw new Exception("Odmowa dostępu do danych API (powodem może być błędny parametr" +
                    " lub odwołanie do nieistniejącej strony URL)");
            }

            return null;
        }

        public Champion GetChampionByName(string name)
        {
            try
            {
                return ConvertFromDataDragon(
                    _riotApi.StaticData.Champions.GetByKeyAsync(GetChampionKeyByName(name), _latestVersion).Result);
            }
            catch (RiotSharpException)
            {
                throw new Exception("Odmowa dostępu do danych API (powodem może być błędny parametr" +
                    " lub odwołanie do nieistniejącej strony URL)");
            }
        }

        public Champion GetChampionByKey(string key)
        {
            try
            {
                return ConvertFromDataDragon(
                    _riotApi.StaticData.Champions.GetByKeyAsync(key, _latestVersion).Result);
            }
            catch (RiotSharpException)
            {
                throw new Exception("Odmowa dostępu do danych API (powodem może być błędny parametr" +
                    " lub odwołanie do nieistniejącej strony URL)");
            }
        }
    }
}
