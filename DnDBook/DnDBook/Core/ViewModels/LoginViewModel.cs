using DnDBook.Core.Database;
using DnDBook.Views;
using System;
using WPF_Client_Library;
using Xamarin.Forms;

namespace DnDBook.Core.ViewModels
{
    internal sealed class LoginViewModel : ViewModel
    {
        private string _username;
        private string _password;

        public LoginViewModel()
        {
            Username = string.Empty;
            Password = string.Empty;

            LoginCommand = new Command(async () =>
            {
                if (string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(Username)) return;

                App.CurrentUser = DataManager.TryValidateUserLogin(Username, Password, out var error);

                if (App.CurrentUser is null)
                {
                    await Application.Current.MainPage.DisplayAlert("Ошибка входа", error, "Ок");
                    return;
                }

                await Shell.Current.GoToAsync("//" + nameof(CharactersPage));
            });

            RegisterCommand = new Command(async () =>
            {
                if (string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(Username)) return;

                App.CurrentUser = DataManager.TryAddUser(Username, Password, out var error);

                if (App.CurrentUser is null)
                {
                    await Application.Current.MainPage.DisplayAlert("*ой*", error, "ладно");
                    return;
                }

                await Shell.Current.GoToAsync("//" + nameof(CharactersPage));
            });
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

        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }
    }
}