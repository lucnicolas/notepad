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
    }
}