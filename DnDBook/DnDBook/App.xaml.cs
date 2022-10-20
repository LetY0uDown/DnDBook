using DnDBook.Models;
using DnDBook.Views;
using Xamarin.Forms;

namespace DnDBook
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            Routing.RegisterRoute(nameof(CharactersEditPage), typeof(CharactersEditPage));
        }

        public static User CurrentUser { get; set; }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}