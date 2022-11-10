using DnDBook.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPF_Client_Library;
using Xamarin.Forms;

namespace DnDBook.Core.ViewModels.Abstract
{
    internal abstract class ModelsListViewModel<T> : ViewModel where T : DBEntity
    {
        protected T _selectedItem;

        public ModelsListViewModel(IEnumerable<T> items)
        {
            Items = items.ToList();
        }

        public virtual T SelectedItem
        {
            get => _selectedItem;
            set 
            { 
                _selectedItem = value;

                if (value != null)
                    NavigateToEdit();
            }
        }

        public virtual List<T> Items { get; set; }

        protected virtual async void NavigateToEdit()
        {
            var className = typeof(T).Name;
            var navString = new StringBuilder("///").Append(className).Append("sEditPage?")                             // Example: T - Item
                                .Append(className).Append("ID=").Append(SelectedItem.ID).ToString();                    // Result: ///ItemsEditPage?ItemID=0

            await Shell.Current.GoToAsync(navString);
        }
    }
}