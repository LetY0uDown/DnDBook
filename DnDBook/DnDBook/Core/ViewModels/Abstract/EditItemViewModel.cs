using DnDBook.Models;
using WPF_Client_Library;
using Xamarin.Forms;

namespace DnDBook.Core.ViewModels.Abstract
{
    internal abstract class EditItemViewModel<T> : ViewModel where T : DBEntity
    {
        protected bool _isEditingNewItem;

        protected T _editingItem;

        public EditItemViewModel(T item, bool isNew = false)
        {
            EditingItem = item;
            _isEditingNewItem = isNew;
        }

        public virtual T EditingItem
        {
            get => _editingItem;
            set
            {
                _editingItem = value;
                OnPropertyChanged();
            }
        }

        public abstract Command SaveItemCommand { get; }
        public abstract Command DeleteItemCommand { get; }
    }
}