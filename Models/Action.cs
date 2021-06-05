using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoL1Shot.Models
{
    public class Action
    {
        public Action(string name, ActionType actionType)
        {
            this.name = name;
            this.actionType = actionType;
        }

        public string name { get; }
        public ActionType actionType { get; }
    }
}
