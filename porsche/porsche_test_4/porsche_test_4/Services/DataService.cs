using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using porsche_test_4.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace porsche_test_4.Services
{
    class DataService
    {
        private static readonly DataService _dataService = new DataService();

        private  HttpClient _httpClient = new HttpClient();
       

        private readonly string _baseUrl = "http://maxim-zubarev.esy.es/porsche/api";

        protected DataService()
        {

        }

        public static DataService GetInstance()
        {
            return _dataService;
        }

        public class ResponseModel
        {
            public int Status { get; set; }
            public string Error { get; set; }
        }

        public async Task<ResponseModel> PostAsync(string path, string json)
        {
            try
            {
                var response = await _httpClient.PostAsync(($"{_baseUrl}{path}"),
                    new StringContent(json, Encoding.UTF8, "application/json"));
                var responseBody =  await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ResponseModel>(responseBody);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new ResponseModel { Status = 400};
            }
        }

        public async Task<ResponseModel> LoginAsync (string UserName, string Password)
        {
            var json = new JObject { { "UserName", UserName }, { "Password", Password } };
            return await PostAsync("/auth.php", json.ToString());
        }

        public async Task<ObservableCollection<RatingModel>> RatingAsync()
        {
            try
            {
                var response = await _httpClient.PostAsync($"{_baseUrl}/reports.php", new StringContent("", Encoding.UTF8, "application/json"));
                var responseBody = await response.Content.ReadAsStringAsync();
                var responseJson = JsonConvert.DeserializeObject<ObservableCollection<RatingModel>>(responseBody);
                return responseJson;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new ObservableCollection<RatingModel>();
            }
        }

        public async Task<ObservableCollection<ReportModel>> ReportAsync(int id_report)
        {
            try
            {
                var response = await _httpClient.PostAsync($"{_baseUrl}/report.php?id={id_report}", new StringContent("", Encoding.UTF8, "application/json"));
                var responseBody = await response.Content.ReadAsStringAsync();
                var responseJson = JsonConvert.DeserializeObject<ObservableCollection<ReportModel>>(responseBody);
                return responseJson;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new ObservableCollection<ReportModel>();
            }
        }

        public async Task<ObservableCollection<SettingsModel>> SettingsAsync()
        {
            try
            {
                var response = await _httpClient.PostAsync($"{_baseUrl}/dillers.php", new StringContent("", Encoding.UTF8, "application/json"));
                var responseBody = await response.Content.ReadAsStringAsync();
                var responseJson = JsonConvert.DeserializeObject<ObservableCollection<SettingsModel>>(responseBody);
                return responseJson;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new ObservableCollection<SettingsModel>();
            }
        }

        public async Task<ObservableCollection<KPIModel>> KPIAsync()
        {
            try
            {
                var response = await _httpClient.PostAsync($"{_baseUrl}/kpi.php", new StringContent("", Encoding.UTF8, "application/json"));
                var responseBody = await response.Content.ReadAsStringAsync();
                var responseJson = JsonConvert.DeserializeObject<ObservableCollection<KPIModel>>(responseBody);
                return responseJson;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new ObservableCollection<KPIModel>();
            }
        }
    }
}
