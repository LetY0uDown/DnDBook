using DnDBook.Core.Database;
using DnDBook.Core.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharactersPage : ContentPage
    {
        public CharactersPage()
        {
            try {
                InitializeComponent();
            } catch (Exception e)
            {
                App.Current.MainPage.DisplayAlert("", e.Message, "ok");
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var list = await DataManager.GetCharactersByUserAsync(App.CurrentUser.ID);

            BindingContext = new CharactersListViewModel(list);
        }
    }
}