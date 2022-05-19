using System.Threading.Tasks;
using Xamarin.Forms;

namespace Notepad.Services
{
    public class DisplayService
    {
        public async Task<bool> AlertAsync(string title, string message, string accept, string cancel)
        {
            Page currentPage = ((NavigationPage) Application.Current.MainPage).CurrentPage;
            return await currentPage.DisplayAlert(title, message, accept, cancel);
        }

        public async Task<string> PromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel", string placeholder = null, int maxLength = -1, Keyboard keyboard = default(Keyboard), string initialValue = "")
        {
            Page currentPage = ((NavigationPage) Application.Current.MainPage).CurrentPage;
            return await currentPage.DisplayPromptAsync(title, message, accept, cancel, placeholder, maxLength,
                keyboard, initialValue);
        }
    }
}