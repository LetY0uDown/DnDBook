using DnDBook.Database;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private string _username;
        private string _password;

        public LoginPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private async void LoginButtonClick(object sender, EventArgs e)
        {
            App.CurrentUser = DataManager.TryValidateUserLogin(Username, Password, out var error);

            if (App.CurrentUser is null)
            {
                await DisplayAlert("Ошибка входа", error, "Ок");
                return;
            }

            await Shell.Current.GoToAsync("//" + nameof(CharactersPage));
        }

        private async void RegisterButtonClick(object sender, EventArgs e)
        {
            App.CurrentUser = DataManager.TryAddUser(Username, Password, out var error);

            if (App.CurrentUser is null)
            {
                await DisplayAlert("*ой*", error, "ладно");
                return;
            }

            await Shell.Current.GoToAsync("//" + nameof(CharactersPage));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Username = string.Empty;
            Password = string.Empty;
        }
    }
}