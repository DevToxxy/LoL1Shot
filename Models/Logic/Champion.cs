using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoL1Shot.Models
{
    public class Champion
    {
        public Champion(
            string name,
            double id,
            double hPPerLevel,
            double hP,
            double armor,
            double armorPerLevel,
            double spellBlockPerLevel,
            Spell q,
            Spell w,
            Spell e,
            Spell r,
            AutoAttack aA)
        {
            Name = name;
            Id = id;
            HPPerLevel = hPPerLevel;
            HP = hP;
            Armor = armor;
            ArmorPerLevel = armorPerLevel;
            SpellBlockPerLevel = spellBlockPerLevel;
            Q = q;
            W = w;
            E = e;
            R = r;
            AA = aA;
        }

        public string Name { get; }
        public double Id { get; }
        public double HPPerLevel { get; }
        public double HP { get; }
        public double Armor { get; }
        public double ArmorPerLevel { get; }
        public double SpellBlockPerLevel { get; }
        public Spell Q { get; }
        public Spell W { get; }
        public Spell E { get; }
        public Spell R { get; }
        public AutoAttack AA { get; }
    }
}
