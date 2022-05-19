using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Notepad.Models;
using Xamarin.Forms;

namespace Notepad.ViewModels
{
    public class NoteListViewModel : BaseViewModel
    {
        private NoteModel selected { get; set; }

        public NoteModel Selected
        {
            get => selected;
            set
            {
                selected = value;
                if (selected != null)
                    OpenCommand.Execute(selected.Id);
            }
        }
        
        public Command OpenCommand { get; }
        public ICommand AddCommand { get; set; }
        public ObservableCollection<NoteModel> Items { get; } = new ObservableCollection<NoteModel>();

        public NoteListViewModel()
        {
            OpenCommand = new Command<int>(async (id) => await OpenAsync(id));
            AddCommand = new Command(async () => await AddAsync());
        }
        public async Task RefreshAsync()
        {
            Items.Clear();
            
            foreach (var item in await noteService.Read())
                Items.Add(item);
        }

        public async Task OpenAsync(int id)
        {
            await navigationService.PushAsync("NoteEditView", id);
        }

        public async Task AddAsync()
        {
            string noteName = await Application.Current.MainPage.DisplayPromptAsync("Nouvelle note", "Nom pour la note :");
            if (string.IsNullOrEmpty(noteName))
                return;

            // Création du fichier
            NoteModel model = new NoteModel() { Name = noteName };
            model = await noteService.Create(model);

            // Afficher la note créée
            await OpenAsync(model.Id);
        }
    }
}