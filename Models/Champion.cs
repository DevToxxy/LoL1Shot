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
            double attackDamage,
            double attackDamagePerLevel,
            Action q,
            Action w,
            Action e,
            Action r,
            Action aA)
        {
            Name = name;
            Id = id;
            HPPerLevel = hPPerLevel;
            HP = hP;
            Armor = armor;
            ArmorPerLevel = armorPerLevel;
            SpellBlockPerLevel = spellBlockPerLevel;
            AttackDamage = attackDamage;
            AttackDamagePerLevel = attackDamagePerLevel;
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
        public double AttackDamage { get; }
        public double AttackDamagePerLevel { get; }
        public Action Q { get; }
        public Action W { get; }
        public Action E { get; }
        public Action R { get; }
        public Action AA { get; }
    }
}
