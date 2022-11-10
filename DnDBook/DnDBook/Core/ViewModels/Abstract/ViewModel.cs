using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_Client_Library
{
    /// <summary>
    /// Base class for every ViewModel
    /// </summary>
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}