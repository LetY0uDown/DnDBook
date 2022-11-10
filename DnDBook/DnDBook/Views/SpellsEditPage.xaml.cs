using DnDBook.Core.Database;
using DnDBook.Core.ViewModels;
using DnDBook.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(SpellID), nameof(SpellID))]
    public partial class SpellsEditPage : ContentPage
    {
        public SpellsEditPage()
        {
            InitializeComponent();

            BindingContext = new SpellEditViewModel(new Spell(), true);
        }

        public int SpellID 
        {
            set => SetContext(value);
        }

        protected async void SetContext(int id)
        {
            var spell = await DataManager.GetAsync<Spell>(id) ?? new Spell();

            BindingContext = new SpellEditViewModel(spell, id <= 0);
        }
    }
}