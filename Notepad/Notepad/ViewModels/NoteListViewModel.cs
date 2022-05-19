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
        public bool isRefreshing { get; set; }

        public NoteModel Selected
        {
            get => selected;
            set
            {
                selected = value;
                NoteModel noteModel = selected;
                if (noteModel != null)
                    OpenCommand.Execute(noteModel.Id);
                SetProperty(ref noteModel, null);
            }
        }

        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                bool oldValue = isRefreshing;
                SetProperty(ref oldValue, value);
            }
        }

        public Command OpenCommand { get; }
        public ICommand RefreshCommand { get; }
        public ICommand AddCommand { get; }
        public ObservableCollection<NoteModel> Items { get; } = new ObservableCollection<NoteModel>();

        public NoteListViewModel()
        {
            OpenCommand = new Command<int>(async (id) => await OpenAsync(id));
            RefreshCommand = new Command(async () => await RefreshAsync());
            AddCommand = new Command(async () => await AddAsync());
            
            messagingService.Subscribe<NoteModel>(this, NoteUpdated, (model) =>
            {
                Items.Remove(model);
                Items.Add(model);
            });
            messagingService.Subscribe<NoteModel>(this, NoteDeleted, (model) => Items.Remove(model));
            
            RefreshCommand.Execute(null);
        }
        public async Task RefreshAsync()
        {
            IsRefreshing = true;
            
            Items.Clear();
            
            foreach (var item in await noteService.Read())
                Items.Add(item);
            
            IsRefreshing = false;
        }

        public async Task AddAsync()
        {
            string noteName = await displayService.PromptAsync("Nouvelle note", "Nom pour la note :");
            if (string.IsNullOrEmpty(noteName))
                return;

            // Création du fichier
            NoteModel model = new NoteModel() { Name = noteName };
            model = await noteService.Create(model);
            
            Items.Add(model);

            // Afficher la note créée
            await navigationService.PushAsync("NoteEditView");
            messagingService.Send(LoadNote, model.Id);
        }
        
        public async Task OpenAsync(int id)
        {
            await navigationService.PushAsync("NoteEditView");
            messagingService.Send(LoadNote, id);
        }
    }
}