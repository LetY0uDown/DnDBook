using DnDBook.Core.Database;
using DnDBook.Core.ViewModels;
using DnDBook.Models;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDBook.Views
{
    [QueryProperty(nameof(CharacterID), nameof(CharacterID))]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharactersEditPage : ContentPage
    {
        public CharactersEditPage()
        {
            InitializeComponent();

            BindingContext = new CharacterEditViewModel(new Character(), true);
        }

        public int CharacterID
        {
            set => SetContext(value);
        }

        private async void SetContext(int id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var character = await db.Characters.FindAsync(id) ?? new Character();

                spellsPicker.ItemsSource = db.Spells.ToList();

                BindingContext = new CharacterEditViewModel(character, id <= 0);
            }
        }
    }
}