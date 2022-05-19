using System;
using System.IO;
using System.Linq;
using Notepad.Models;
using Notepad.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notepad.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteListView : ContentPage
    {
        private FileNoteService noteService = new FileNoteService();
        
        public NoteListView()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            noteList.ItemsSource = await noteService.Read();
        }

        private async void noteList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (!(e.Item is NoteModel model))
                return;

            Page page = new NoteEditView(model.Id);
            await Navigation.PushAsync(page);
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            string noteName = await DisplayPromptAsync("Nouvelle note", "Nom pour la note:");
            if (string.IsNullOrEmpty(noteName))
                return;

            // Création du fichier
            NoteModel model = new NoteModel() { Name = noteName };
            model = await noteService.Create(model);

            // Afficher la note créée
            Page page = new NoteEditView(model.Id);
            await Navigation.PushAsync(page);
        }
    }
}