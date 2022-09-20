using Services1.Shared;
using System.Net.Http.Json;

namespace Services1.Client.Services
{
    internal class ReportService : IReportService
    {
        private readonly HttpClient http;
        private Reports? rep;
        private readonly string url = "api/Report/";

        public ReportService(HttpClient _http)
        {
            http = _http;
        }

        async Task<Reports> IReportService.GetReportById(int id)
        {
            return await http.GetFromJsonAsync<Reports>(url + "getReportById/" + id);
        }

        async Task<List<Reports>> IReportService.GetReportsByMark(int id, int value)
        {
            return await http.GetFromJsonAsync<List<Reports>>(url + "getReportByMark/" + id + "/" + value);
        }

        async Task<bool> IReportService.SetReport(Reports report)
        {
            try
            {
                var t = await http.PostAsJsonAsync<Reports>(url + "setReport", report);
                return await t.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception)
            {
                return false;
            }
        }

        async Task<bool> IReportService.UpdateReport(int id, int value)
        {
            try
            {
                return await http.GetFromJsonAsync<bool>(url + "updateReport/" + id + "/" + value);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
