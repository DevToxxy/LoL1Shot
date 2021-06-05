using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoL1Shot.Models
{
    public class Spell : Action
    {
        public SpellKey SpellKey { get; }

        public Spell(string name, SpellKey spellKey) : base()
        {
            SpellKey = spellKey;
        }
    }
}
