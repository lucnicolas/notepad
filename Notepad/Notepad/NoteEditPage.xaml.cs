using System;
using System.IO;
using Xamarin.Forms;

namespace Notepad
{
    public partial class NoteEditPage : ContentPage
    {
        private string noteName;

        public NoteEditPage(string noteName)
        {
            this.noteName = noteName;

            InitializeComponent();

            Title = noteName;

            // Rechargement de la note sauvegardée
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filePath = Path.Combine(directory, $"{noteName}.txt");
            if (File.Exists(filePath))
            {
                noteEditor.Text = File.ReadAllText(filePath);
            }
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            // Récupérer le contenu de l'éditeur
            string content = noteEditor.Text;

            // Sauvegarder le contenu dans un fichier
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filePath = Path.Combine(directory, $"{noteName}.txt");
            File.WriteAllText(filePath, content);

            // Retour à la liste
            await Navigation.PopAsync();
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            // Confirmation
            bool deleteFile = await DisplayAlert("Suppression", "Voulez-vous vraiment supprimer cette note", "Oui", "Non");
            if (!deleteFile)
                return;

            // Suppression du texte
            noteEditor.Text = "";

            // Suppression du fichier
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filePath = Path.Combine(directory, $"{noteName}.txt");
            File.Delete(filePath);
            
            // Retour à la liste
            await Navigation.PopAsync();
        }
    }
}