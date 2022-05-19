using System.Threading.Tasks;
using Xamarin.Forms;

namespace Notepad.Services
{
    public class NavigationService
    {
        public async Task<Page> PopAsync()
        {
            Page currentPage = (Application.Current.MainPage as NavigationPage).CurrentPage;
            return await currentPage.Navigation.PopAsync();
        }
    }
}