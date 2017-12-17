using porsche_test_4.Models;
using porsche_test_4.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace porsche_test_4.ViewModels
{
    class ReportViewModel
    {
        public ReportViewModel(int id_report)
        {
            this.id_report = id_report;
        }

        private int id_report { get; set; }

        public ObservableCollection<ReportModel> Report { get; set; } = new ObservableCollection<ReportModel>();

        public async Task ReportAsync()
        {
            var dataService = DataService.GetInstance();
            var reports = await dataService.ReportAsync(id_report);

            foreach (var rep in reports)
            {
                Report.Add(rep);
            }
        }
    }
}
