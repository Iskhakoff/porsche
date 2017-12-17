using porsche_test_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace porsche_test_4.Views
{
    public partial class ReportPage : ContentPage
    {
        private ReportViewModel _viewModel;

        private bool report = false;

        public ReportPage(int id_report)
        {
            InitializeComponent();
            _viewModel = new ReportViewModel(id_report);
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            if (report == false)
            {
                base.OnAppearing();
                await _viewModel.ReportAsync();
                report = true;
            }
        }
    }
}
