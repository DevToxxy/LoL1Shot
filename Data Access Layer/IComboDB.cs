using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoL1Shot.Models;

namespace LoL1Shot.Data_Access_Layer
{
    public interface IComboDB
    {
        public List<Combo> List { get; }
        public Combo Get(int id);
        public void Update(Combo combo);
        public void Delete(int id);
        public void Add(Combo combo);
    }
}
