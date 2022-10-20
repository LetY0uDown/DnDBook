using DnDBook.Database;
using DnDBook.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDBook.Views
{
    [QueryProperty(nameof(CharacterID), nameof(CharacterID))]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharactersEditPage : ContentPage
    {
        private bool _isCreatingNew;

        public CharactersEditPage()
        {
            InitializeComponent();          
            
            BindingContext = this;
        }

        public int CharacterID { get; set; }

        private Spell _selectedSpell;
        public Spell SelectedSpell
        {
            get => _selectedSpell;
            set
            {
                if (!CurrentCharacter.Spells.Contains(value))
                    CurrentCharacter.Spells.Add(value);

                _selectedSpell = value;
            }
        }

        private Character _currentCharacter;
        public Character CurrentCharacter
        {
            get => _currentCharacter;
            set
            {
                _currentCharacter = value;
                OnPropertyChanged();
            }
        }
        
        protected override async void OnAppearing()
        {
            _isCreatingNew = CharacterID <= 0;
            CurrentCharacter = await DataManager.Characters.GetAsync(CharacterID) ?? new Character();

            spellsPicker.ItemsSource = DataManager.Spells.Values;

            base.OnAppearing();
        }

        private async void OnSaveButtonClick(object sender, System.EventArgs e)
        {
            if (_isCreatingNew)
            {
                CurrentCharacter.OwnerID = App.CurrentUser.ID;

                await DataManager.Characters.AddAsync(CurrentCharacter);
            }

            await DisplayAlert("Операция завершена успешно", "Данные вашего персонажа сохранены", "ОК");

            await Shell.Current.GoToAsync("///CharactersPage");
        }

        private async void OnDeleteButtonClick(object sender, System.EventArgs e)
        {
            if (!_isCreatingNew)
                await DataManager.Characters.RemoveAsync(CurrentCharacter);

            CurrentCharacter = new Character();

            await DisplayAlert("Операция завершена успешно", "Данные вашего персонажа удалены", "ОК");

            await Shell.Current.GoToAsync("///CharactersPage");
        }
    }
}