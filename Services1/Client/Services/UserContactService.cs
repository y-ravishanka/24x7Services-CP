using Services1.Shared;
using System.Net.Http.Json;

namespace Services1.Client.Services
{
    internal class UserContactService : IUserContactService
    {
        private readonly HttpClient http;
        private readonly string url = "api/UserContact/";

        public UserContactService(HttpClient _http)
        {
            http = _http;
        }

        async Task<List<UserContactData>> IUserContactService.GetUserContacts(int id)
        {
            return await http.GetFromJsonAsync<List<UserContactData>>(url + "getUserContacts/" + id);
        }

        async Task<bool> IUserContactService.SetUserContact(UserContactData user)
        {
            try
            {
                var t = await http.PostAsJsonAsync<UserContactData>(url + "setUserContact", user);
                var t1 = await t.Content.ReadFromJsonAsync<bool>();
                return t1;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
