﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using Notepad.Services;

namespace Notepad.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected const string LoadNote = "LoadNote";
        
        protected static readonly FileNoteService noteService = new FileNoteService();
        protected static readonly DisplayService displayService = new DisplayService();
        protected static readonly NavigationService navigationService = new NavigationService();
        protected static readonly MessagingService messagingService = new MessagingService();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<T>(ref T oldValue, T newValue, [CallerMemberName] string name = "")
        {
            //TODO Vérifier l'égalité

            oldValue = newValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
