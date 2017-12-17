using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using porsche_test_4.Views;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using porsche_test_4.Models;
using porsche_test_4.Services;
using System.Threading.Tasks;
using System.Windows.Input;

namespace porsche_test_4.ViewModels
{
    public class SettingsViewModel : ContentView
    {
        public ObservableCollection<SettingsModel> Settings { get; set; } = new ObservableCollection<SettingsModel>();

        public async Task SettingsAsync()
        {
            var dataService = DataService.GetInstance();
            var rating = await dataService.SettingsAsync();

            foreach (var rat in rating)
            {
               Settings.Add(rat);
            }
        }

        private Page _page;

        public ICommand RefreshContacts { get; set; }

        public ICommand OpenProfile { get; set; }

        public ICommand OpenLog { get; set; }

        public ICommand OpenKPI { get; set; }

        public SettingsViewModel(Page page)
        {
            _page = page;
            OpenProfile = new Command(async () => {
                await _page.Navigation.PushAsync(new RatingPage());
            });
            OpenLog = new Command(WayOut);
            RefreshContacts = new Command(Refresh);
            OpenKPI = new Command(async () =>
            {
                await _page.Navigation.PushAsync(new KPIPage());
            });
        }

        private async void Refresh()
        {
            await _page.Navigation.PushAsync(new SettingsPage());
            _page.Navigation.RemovePage(_page);
        }
        private void WayOut()
        {
            var app = (App)Application.Current;
            app.MainPage = new NavigationPage(new LoginPage());
        }
    }
}
