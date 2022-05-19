using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Notepad.Services
{
    public class NavigationService
    {
        private static readonly Dictionary<string, Type> views = new Dictionary<string, Type>();

        public static void SetView(string name, Type type)
        {
            views[name] = type;
        }

        public async Task<Page> PopAsync()
        {
            Page currentPage = ((NavigationPage) Application.Current.MainPage).CurrentPage;
            return await currentPage.Navigation.PopAsync();
        }

        public async Task PushAsync(string viewName, params object [] args)
        {
            Page currentPage = ((NavigationPage) Application.Current.MainPage).CurrentPage;

            Type viewType = views[viewName];
            Page page = (Page) Activator.CreateInstance(viewType, args);
            
            await currentPage.Navigation.PushAsync(page);
        }
    }
}