using Notepad.ViewModels;
using Xamarin.Forms.Xaml;

namespace Notepad.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteListView
    {
        public NoteListView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ((NoteListViewModel) BindingContext).RefreshAsync();
        }
    }
}