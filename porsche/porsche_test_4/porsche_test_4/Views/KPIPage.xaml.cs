using porsche_test_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace porsche_test_4.Views
{
    public partial class KPIPage : ContentPage
    {
        private readonly KPIViewModel _KPIviewModel;
        private bool kpi = false;
        public KPIPage()
        {
            InitializeComponent();
            _KPIviewModel = new KPIViewModel();
            this.BindingContext = _KPIviewModel;
        }

        protected override async void OnAppearing()
        {
            if (kpi == false)
            {
                base.OnAppearing();
                await _KPIviewModel.KPIAsync();
                kpi = true;
            }
        }
    }
}
