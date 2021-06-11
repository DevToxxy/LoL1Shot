using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LoL1Shot.Models
{
    [Keyless]
    public abstract class Action
    {
        public Action() { }

        [NotMapped] public virtual double GetDamage { get; }
    }
}
