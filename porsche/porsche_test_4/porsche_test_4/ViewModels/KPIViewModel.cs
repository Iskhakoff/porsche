using porsche_test_4.Models;
using porsche_test_4.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace porsche_test_4.ViewModels
{
    public class KPIViewModel : ContentPage
    {
        public ObservableCollection<KPIModel> KPI { get; set; } = new ObservableCollection<KPIModel>();
        public KPIViewModel()
        {

        }
        public async Task KPIAsync()
        {
            var dataService = DataService.GetInstance();
            var rating = await dataService.KPIAsync();

            foreach (var rat in rating)
            {
                KPI.Add(rat);
            }
        }
    }
}