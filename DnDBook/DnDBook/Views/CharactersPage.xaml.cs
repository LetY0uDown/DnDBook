using DnDBook.Database;
using DnDBook.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharactersPage : ContentPage
    {
        public CharactersPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        public List<Character> Characters { get; set; }

        public Character SelectedCharacter { get; set; }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            Characters = await DataManager.GetCharactersByUserAsync(App.CurrentUser.ID);

            charactersCollection.ItemsSource = null;
            charactersCollection.ItemsSource = Characters;

            charactersCollection.SelectedItem = null;
            SelectedCharacter = null;
        }

        private async void charactersCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedCharacter is null) return;

            var navString = $"///CharactersEditPage?CharacterID={SelectedCharacter.ID}";
            await Shell.Current.GoToAsync(navString);
        }
    }
}