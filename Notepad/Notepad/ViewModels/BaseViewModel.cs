using System.ComponentModel;
using System.Runtime.CompilerServices;
using Notepad.Services;

namespace Notepad.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected static readonly FileNoteService noteService = new FileNoteService();
        protected static readonly NavigationService navigationService = new NavigationService();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<T>(ref T oldValue, T newValue, [CallerMemberName] string name = "")
        {
            //TODO Vérifier l'égalité

            oldValue = newValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
