using System.Threading.Tasks;
using System.Windows.Input;
using Notepad.Models;
using Xamarin.Forms;

namespace Notepad.ViewModels
{
    public class NoteEditViewModel : BaseViewModel
    {
        private NoteModel model;

        public NoteModel Model
        {
            get => model;
            set => SetProperty(ref model, value);
        }

        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public NoteEditViewModel()
        {
            SaveCommand = new Command(async () => await SaveAsync());
            DeleteCommand = new Command(async () => await DeleteAsync());
        }

        public async Task LoadAsync(int id)
        {
            Model = await noteService.Read(id);
        }

        public async Task SaveAsync()
        {
            await noteService.Update(Model.Id, Model);
            await navigationService.PopAsync();
        }

        public async Task DeleteAsync()
        {
            await noteService.Delete(Model.Id);
        }
    }
}