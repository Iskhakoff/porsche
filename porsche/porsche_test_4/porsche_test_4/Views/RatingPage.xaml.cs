using porsche_test_4.Models;
using porsche_test_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace porsche_test_4.Views
{
    public partial class RatingPage : ContentPage
    {
        private readonly RatingViewModel _viewModel;

        private bool report = false;

        public RatingPage()
        {
            InitializeComponent();
            _viewModel = new RatingViewModel(this);
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            if (report == false)
            {
                base.OnAppearing();
                await _viewModel.RatingAsync();
                report = true;
            }
        }

        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var id = ((RatingModel)e.Item).id_report;
            await _viewModel.OpenReport(id);
        }
    }

}
