using System;
using Notepad.ViewModels;
using Xamarin.Forms;

namespace Notepad.Views
{
    public partial class NoteEditView : ContentPage
    {
        public NoteEditView(int id)
        {
            InitializeComponent();

            (BindingContext as NoteEditViewModel).LoadAsync(id);
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            // Confirmation
            bool deleteFile = await DisplayAlert("Suppression", "Voulez-vous vraiment supprimer cette note", "Oui", "Non");
            if (!deleteFile)
                return;

            await (BindingContext as NoteEditViewModel).DeleteAsync();
            await Navigation.PopAsync();
        }
    }
}