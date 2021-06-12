using LoL1Shot.Models;
using LoL1Shot.Models.CustomExtensions;
using Microsoft.Extensions.Configuration;
using RiotSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace LoL1Shot.Data_Access_Layer
{
    public class ActionApiDB : IActionDB
    {
        private IConfiguration _configuration;
        private RiotApi _riotApi;
        private string _latestVersion;
        private readonly string _autoAttackImageURL = "images/autoAttackIcon.png";
        private readonly string _missingImageURL = "images/missingImage.jpg";

        public string GetMissingImageURL => _missingImageURL;

        public string GetAutoAttackImageURL => _autoAttackImageURL;

        private Champion ConvertFromDataDragon(
            RiotSharp.Endpoints.StaticDataEndpoint.Champion.ChampionStatic championStatic)
        {
            //dostęp do danych championa poprzez
            //championStatic.Stats.MpPerLevel;
            //championStatic.Spells[0].EffectBurns;

            Spell[] spells = new Spell[4];
            for (int i = 0; i < 4; i++)
            {
                SpellKey spellKey;
                switch (i)
                {
                    case 0:
                        spellKey = SpellKey.Q;
                        break;
                    case 1:
                        spellKey = SpellKey.W;
                        break;
                    case 2:
                        spellKey = SpellKey.E;
                        break;
                    case 3:
                        spellKey = SpellKey.R;
                        break;
                    default:
                        spellKey = SpellKey.Q; 
                        break;
                }

                string[] values = championStatic.Spells[i].EffectBurns[1].Split('/');

                double damage = 0;

                try
                {
                    if (double.Parse(values[values.Length - 1]) > 0)
                    {
                        damage = double.Parse(values[values.Length - 1]);
                    }
                }
                catch
                {
                    //totalnie poprawna obsługa wyjątków
                }

                spells[i] = new Spell(
                    championStatic.Spells[i].Name,
                    spellKey,
                    damage
                    );
            }

            return new Champion(
                    championStatic.Name,
                    championStatic.Key,
                    championStatic.Stats.HpPerLevel,
                    championStatic.Stats.Hp,
                    championStatic.Stats.Armor,
                    championStatic.Stats.ArmorPerLevel,
                    championStatic.Stats.SpellBlockPerLevel,
                    spells[0],
                    spells[1], 
                    spells[2],
                    spells[3],
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

        public Dictionary<string, string> GetChampionsKeys
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

        public List<Models.Action> GetActions(string championKey, string actionString)
        {
            var championStatic = _riotApi.StaticData.Champions.GetByKeyAsync(
                championKey, _latestVersion).Result;

            List<Models.Action> actions = new List<Models.Action>();


            string[] actionStrings = actionString.Split(',');

            for (int i = 0; i < actionStrings.Length; i++)
            {
                int spellIndex = -1;
                SpellKey spellKey = SpellKey.Q;
                switch (actionStrings[i])
                {
                    case "A":
                        spellIndex = -1;
                        break;
                    case "Q":
                        spellIndex = 0;
                        spellKey = SpellKey.Q;
                        break;
                    case "W":
                        spellIndex = 1;
                        spellKey = SpellKey.W;
                        break;
                    case "E":
                        spellIndex = 2;
                        spellKey = SpellKey.E;
                        break;
                    case "R":
                        spellIndex = 3;
                        spellKey = SpellKey.R;
                        break;
                    default:
                        throw new ArgumentException("ActionString zawiera niedozwolone znaki");
                }

                if(spellIndex >= 0) //akcja jest zaklęciem
                {
                    string[] values = championStatic.Spells[spellIndex].EffectBurns[1].Split('/');

                    double damage = double.Parse(values[values.Length - 1]) > 0
                        ? double.Parse(values[values.Length - 1]) : 0;

                    actions.Add(
                        new Spell(
                            championStatic.Spells[spellIndex].Name,
                            spellKey,
                            damage
                            )
                        );
                }
                else //akcja jest auto atakiem
                {
                    actions.Add(
                        new AutoAttack(
                            championStatic.Stats.AttackDamage,
                            championStatic.Stats.AttackDamagePerLevel
                            )
                        );
                }
            }

            return actions;
        }

        public string GetSpellImageURL(string championKeyName, SpellKey spellKey)
        {
            int index = 0;
            switch (spellKey)
            {
                case SpellKey.Q:
                    index = 0;
                    break;
                case SpellKey.W:
                    index = 1;
                    break;
                case SpellKey.E:
                    index = 2;
                    break;
                case SpellKey.R:
                    index = 3;
                    break;
            }

            string url;
            bool exist = false;

            try
            {
                string imageName = _riotApi.StaticData.Champions.GetByKeyAsync(
                championKeyName, _latestVersion).Result.Spells[index].Image.Full;

                url = _configuration.GetSpellImagesURL() + imageName;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    exist = response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (RiotSharpException e)
            {
                throw new Exception("Odmowa dostępu do danych API (powodem może być błędny parametr" +
                    " lub odwołanie do nieistniejącej strony URL):"+e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (exist)
                return url;
            else
                return null;
        }

        public string GetChampionImageURL(string championKeyName)
        {
            string url = "";
            bool exist = false;

            try
            {
                string imageName = _riotApi.StaticData.Champions.GetByKeyAsync(
                    championKeyName, _latestVersion).Result.Image.Full;

                url = _configuration.GetChampionImagesURL() + imageName;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    exist = response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (RiotSharpException e)
            {
                throw new Exception("Odmowa dostępu do danych API (powodem może być błędny parametr" +
                    " lub odwołanie do nieistniejącej strony URL):" + e.Message);
            }
            catch
            {

            }

            if (exist)
                return url;
            else
                return null;
        }

        public string GetChampionSplashURL(string championKeyName)
        {
            string url;
            bool exist = false;

            try
            {
                url = _configuration.GetChampionSplashesURL() + championKeyName + "_0.jpg";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    exist = response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (RiotSharpException e)
            {
                throw new Exception("Odmowa dostępu do danych API (powodem może być błędny parametr" +
                    " lub odwołanie do nieistniejącej strony URL):" + e.Message);
            }

            if (exist)
                return url;
            else
                return null;
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

        public List<Models.Action> ConverActionStringToList(string championKey, string actionString)
        {
            List<Models.Action> actions = new List<Models.Action>();
            Champion champion = GetChampionByKey(championKey);

            string[] actionStrings = actionString.Split(',');
            for (int i = 0; i < actionStrings.Length; i++)
            {
                actionStrings[i] = actionStrings[i].Replace(" ", "");

                Models.Action actionObject;

                if (actionStrings[i] == "A")
                    actionObject = new AutoAttack();
                else
                    switch (actionStrings[i])
                    {
                        case "Q":
                            actionObject = champion.Q;
                            break;
                        case "W":
                            actionObject = champion.W;
                            break;
                        case "E":
                            actionObject = champion.E;
                            break;
                        case "R":
                            actionObject = champion.R;
                            break;
                        default:
                            throw new Exception("Nieprawidłowy symbol w actionString");
                    }

                actions.Add(actionObject);
            }

            return actions;
        }
    }
}
