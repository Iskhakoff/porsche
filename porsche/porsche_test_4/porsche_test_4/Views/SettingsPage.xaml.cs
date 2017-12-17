using porsche_test_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace porsche_test_4.Views
{
    public partial class SettingsPage : ContentPage
    {
        private readonly SettingsViewModel _viewModel;

        private bool report = false;

        public SettingsPage()
        {
            InitializeComponent();
            _viewModel = new SettingsViewModel(this);
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            if (report == false)
            {
                base.OnAppearing();
                await _viewModel.SettingsAsync();
                report = true;
            }
        }
    }
}
