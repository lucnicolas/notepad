using System;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notepad
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteListPage : ContentPage
    {
        public NoteListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string[] files = Directory.GetFiles(directory, "*.txt");

            noteList.ItemsSource = files.Select(x => Path.GetFileNameWithoutExtension(x));
        }

        private async void noteList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Page page = new NoteEditPage((string)e.Item);
            await Navigation.PushAsync(page);
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            string noteName = await DisplayPromptAsync("Nouvelle note", "Nom pour la note:");
            if (string.IsNullOrEmpty(noteName))
                return;

            // Création du fichier
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filePath = Path.Combine(directory, $"{noteName}.txt");
            File.WriteAllText(filePath, "");

            // Afficher la note créée
            Page page = new NoteEditPage(noteName);
            await Navigation.PushAsync(page);
        }
    }
}