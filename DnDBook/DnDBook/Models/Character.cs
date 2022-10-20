using DnDBook.Database;
using System.Collections.Generic;

namespace DnDBook.Models
{
    public class Character : DBEntity
    {
        public int OwnerID { get; set; }

        public string Name { get; set; }

        public int? Age { get; set; } = null;

        public string Race { get; set; }

        public string Class { get; set; }

        public int? Level { get; set; } = null; 

        public int? HP { get; set; } = null;

        public int? AC { get; set; } = null;

        public List<Spell> Spells { get; set; } = new List <Spell>();
    }
}