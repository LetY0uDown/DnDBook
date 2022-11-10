using DnDBook.Core.Database;
using DnDBook.Core.ViewModels;
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
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (DatabaseContext db = new DatabaseContext())
            {
                BindingContext = new SpellsListViewModel(db.Spells);
            }
        }
    }
}