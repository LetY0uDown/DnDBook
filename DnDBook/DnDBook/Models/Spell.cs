using DnDBook.Database;

namespace DnDBook.Models
{
    public class Spell : DBEntity
    {
        public string Title { get; set; }

        public int? Level { get; set; } = null;

        public string Description { get; set; }

        public string School { get; set; }

        public string Distance { get; set; }

        public string CastTime { get; set; }

        public string EffectTime { get; set; }

        public bool IsRitual { get; set; }

        public string Classes { get; set; }

        public string MaterialComponent { get; set; }

        public bool HaveVerbalComponent { get; set; }

        public bool HaveSomaticComponent { get; set; }

        public override string ToString()
        {
            return $"{Title}\t{Level} круг";
        }
    }
}