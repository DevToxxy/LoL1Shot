using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoL1Shot.Models
{
    public class Spell : Action
    {
        public SpellKey SpellKey { get; }
        public string Name { get; }
        public double Damage { get; }

        public Spell(string name, SpellKey spellKey, double damage) : base()
        {
            SpellKey = spellKey;
            Name = name;
            Damage = damage;
        }

        public Spell(SpellKey spellKey) : base()
        {
            SpellKey = spellKey;
            Name = null;
            Damage = 0;
        }

        public Spell() : base() { }

        public override double GetDamage => Damage;
    }
}
