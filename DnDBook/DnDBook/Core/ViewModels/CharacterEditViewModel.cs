using DnDBook.Core.Database;
using DnDBook.Core.ViewModels.Abstract;
using DnDBook.Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DnDBook.Core.ViewModels
{
    internal class CharacterEditViewModel : EditItemViewModel<Character>
    {
        public CharacterEditViewModel(Character item, bool isNew = false) : base(item, isNew)
        {
            SaveItemCommand = new Command(async () =>
            {
                if (_isEditingNewItem)
                {
                    EditingItem.OwnerID = App.CurrentUser.ID;

                    await DataManager.AddAsync(EditingItem);
                }
                else
                {
                    await DataManager.UpdateAsync(EditingItem);
                }

                await Application.Current.MainPage.DisplayAlert("Операция завершена успешно", "Данные вашего персонажа сохранены", "ОК");

                await Shell.Current.GoToAsync("///CharactersPage");
            });

            DeleteItemCommand = new Command(async () =>
            {
                if (!_isEditingNewItem)
                    await DataManager.RemoveAsync(EditingItem);

                await Application.Current.MainPage.DisplayAlert("Операция завершена успешно", "Данные вашего персонажа удалены", "ОК");

                await Shell.Current.GoToAsync("///CharactersPage");
            });
        }

        public List<Spell> Spells { get; }

        public Spell SelectedSpell
        {
            get => null;
            set
            {
                if (!EditingItem.Spells.Contains(value))
                {
                    EditingItem.Spells.Add(value);

                    DataManager.UpdateAsync(EditingItem);
                }
            }
        }

        public override Command SaveItemCommand { get; }

        public override Command DeleteItemCommand { get; }
    }
}