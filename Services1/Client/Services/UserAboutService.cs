using Services1.Shared;
using System.Net.Http.Json;

namespace Services1.Client.Services
{
    internal class UserAboutService : IUserAboutService
    {
        private readonly HttpClient http;
        private readonly string url = "api/UserAbout/";
        private UserAboutData? data;

        public UserAboutService(HttpClient _http)
        {
            http = _http;
        }

        async Task<UserAboutData> IUserAboutService.GetUserAbout(int id)
        {
            try
            {
                data = await http.GetFromJsonAsync<UserAboutData>(url + "getUserAbout/" + id);
                return data;
            }
            catch (Exception)
            {
                return data;
            }
        }
    }
}
