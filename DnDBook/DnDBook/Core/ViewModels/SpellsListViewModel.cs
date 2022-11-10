using DnDBook.Core.ViewModels.Abstract;
using DnDBook.Models;
using System.Collections.Generic;

namespace DnDBook.Core.ViewModels
{
    internal sealed class SpellsListViewModel : ModelsListViewModel<Spell>
    {
        public SpellsListViewModel(IEnumerable<Spell> spells) : base(spells) { }

        // ну тут пока пусто, всё в базовом классе
    }
}