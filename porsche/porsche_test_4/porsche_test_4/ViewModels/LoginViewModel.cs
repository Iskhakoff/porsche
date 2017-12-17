using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using porsche_test_4.Services;
using porsche_test_4.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace porsche_test_4.ViewModels
{
    public class LoginViewModel : ContentView
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        private Page _page;
        public ICommand LoginCommand { get; set; }

        public LoginViewModel(Page page)
        {
            _page = page;
            LoginCommand = new Command(OpenRating);
        }

        private async void OpenRating()
        {
            var dataService = DataService.GetInstance();
            var response = await dataService.LoginAsync(UserName, Password);
            if (response.Status == 200)
            {
                await _page.Navigation.PushAsync(new RatingPage());
                _page.Navigation.RemovePage(_page);
            }
            else if (response.Status == 101)
            {
                await _page.DisplayAlert("Error", "Wrong username or password", "Exit");
            }
            else if (response.Status == 400)
            {
                await _page.DisplayAlert("Error", "Bad Request", "Exit");
            }
        }
    }
}
