using DnDBook.Core.Database;
using DnDBook.Core.ViewModels.Abstract;
using DnDBook.Models;
using Xamarin.Forms;

namespace DnDBook.Core.ViewModels
{
    internal sealed class SpellEditViewModel : EditItemViewModel<Spell>
    {
        public SpellEditViewModel(Spell item, bool isNew = false) : base(item, isNew)
        {
            SaveItemCommand = new Command(async () =>
            {
                if (_isEditingNewItem)
                    await DataManager.AddAsync(EditingItem);
                else
                    await DataManager.UpdateAsync(EditingItem);

                await Application.Current.MainPage.DisplayAlert("Операция завершена успешно", "Данные вашего заклинания сохранены", "ОК");

                await Shell.Current.GoToAsync("///SpellsPage");
            });

            DeleteItemCommand = new Command(async () =>
            {
                if (!_isEditingNewItem)
                    await DataManager.RemoveAsync(EditingItem);

                await Application.Current.MainPage.DisplayAlert("Операция завершена успешно", "Данные вашего заклинания удалены", "ОК");

                await Shell.Current.GoToAsync("///SpellsPage");
            });
        }

        public override Command SaveItemCommand { get; }

        public override Command DeleteItemCommand { get; }
    }
}