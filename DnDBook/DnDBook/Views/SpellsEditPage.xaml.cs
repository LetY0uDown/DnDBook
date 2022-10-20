using DnDBook.Database;
using DnDBook.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(SpellID), nameof(SpellID))]
    public partial class SpellsEditPage : ContentPage
    {
        private bool _isCreatingNew;

        public SpellsEditPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        public int SpellID { get; set; }

        private Spell _spell;
        public Spell Spell
        {
            get => _spell;
            set
            {
                _spell = value;
                OnPropertyChanged();
            }
        }

        protected override async void OnAppearing()
        {
            _isCreatingNew = SpellID <= 0;

            Spell = await DataManager.Spells.GetAsync(SpellID) ?? new Spell();

            base.OnAppearing();
        }

        private async void OnSaveButtonClick(object sender, System.EventArgs e)
        {
            if (_isCreatingNew)
            {
                await DataManager.Spells.AddAsync(Spell);
            }

            await DisplayAlert("Операция завершена успешно", "Данные вашего заклинания сохранены", "ОК");

            await Shell.Current.GoToAsync("///SpellsPage");
        }

        private async void OnDeleteButtonClick(object sender, System.EventArgs e)
        {
            if (!_isCreatingNew)
                await DataManager.Spells.RemoveAsync(Spell);

            Spell = new Spell();

            await DisplayAlert("Операция завершена успешно", "Данные вашего заклинания удалены", "ОК");

            await Shell.Current.GoToAsync("///SpellsPage");
        }
    }
}