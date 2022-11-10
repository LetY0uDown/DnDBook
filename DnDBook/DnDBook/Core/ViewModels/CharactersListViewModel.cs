using DnDBook.Core.ViewModels.Abstract;
using DnDBook.Models;
using System.Collections.Generic;

namespace DnDBook.Core.ViewModels
{
    internal sealed class CharactersListViewModel : ModelsListViewModel<Character>
    {
        public CharactersListViewModel(IEnumerable<Character> characters) : base(characters) { }

        // ну тут пока пусто, всё в базовом классе
    }
}