using DnDBook.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void LogoutButtonClick(object sender, EventArgs e)
        {
            App.CurrentUser = null;
            await Current.GoToAsync("//" + nameof(LoginPage));
        }
    }
}