using DnDBook.Database;
using DnDBook.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpellsPage : ContentPage
    {
        public SpellsPage()
        {
            InitializeComponent();

            BindingContext = this;

            spellsCollection.ItemsSource = null;
            spellsCollection.ItemsSource = Spells;
        }

        public List<Spell> Spells { get; set; }

        private Spell _selectedSpell;
        public Spell SelectedSpell
        {
            get => _selectedSpell;
            set
            {
                _selectedSpell = value;
                OnPropertyChanged();
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Spells = DataManager.Spells.Values;

            spellsCollection.ItemsSource = null;
            spellsCollection.ItemsSource = Spells;

            spellsCollection.SelectedItem = null;
            SelectedSpell = null;
        }

        private async void spellsCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedSpell is null) return;
            
            try
            {
                var navString = $"///SpellsEditPage?SpellID={SelectedSpell.ID}";
                await Shell.Current.GoToAsync(navString);
            }
            catch (Exception error)
            {
                await DisplayAlert("error", error.Message, "ok");
            }
        }
    }
}