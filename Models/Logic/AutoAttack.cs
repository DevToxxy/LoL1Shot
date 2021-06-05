using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoL1Shot.Models
{
    public class AutoAttack : Action
    {
        public AutoAttack(double attackDamage, double attackDamagePerLevel) : base()
        {
            AttackDamage = attackDamage;
            AttackDamagePerLevel = attackDamagePerLevel;
        }

        public double AttackDamage { get; }
        public double AttackDamagePerLevel { get; }
    }
}
