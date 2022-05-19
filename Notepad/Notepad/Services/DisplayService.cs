using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Notepad.Services
{
    public class DisplayService
    {
        public async Task<bool> Alert(string title, string message, string accept, string cancel)
        {
            Page currentPage = ((NavigationPage) Application.Current.MainPage).CurrentPage;
            return await currentPage.DisplayAlert(title, message, accept, cancel);
        }
    }
}