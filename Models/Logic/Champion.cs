using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LoL1Shot.Models
{
    public class Champion
    {
        public Champion(
            string name,
            string keyName,
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
            KeyName = keyName;
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

        public Champion() { }

        [Display(Name = "Nazwa championa")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Klucz (nie to samo co numer id)
        /// </summary>
        [Display(Name = "Klucz championa")]
        [Key] public string KeyName { get; set; }
        [NotMapped] public double HPPerLevel { get; }
        [NotMapped] public double HP { get;  }
        [NotMapped] public double Armor { get; }
        [NotMapped] public double ArmorPerLevel { get; }
        [NotMapped] public double SpellBlockPerLevel { get; }
        [NotMapped] public Spell Q { get; }
        [NotMapped] public Spell W { get; }
        [NotMapped] public Spell E { get; }
        [NotMapped] public Spell R { get; }
        [NotMapped] public AutoAttack AA { get; }

        public bool IsKilled(double fullDamage)
        {
            return fullDamage > Armor ? true : false;
        }

        public double ArmorAfterAttack(double damage)
        {
            if (damage < 0) throw new ArgumentOutOfRangeException("Obrażenia nie mogą być ujemne");
            return (damage > Armor) ? 0 : Armor - damage;
        }
    }
}
