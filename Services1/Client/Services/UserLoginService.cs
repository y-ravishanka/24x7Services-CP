using Services1.Shared;
using System.Net.Http.Json;

namespace Services1.Client.Services
{
    internal class UserLoginService : IUserLoginService
    {
        private readonly HttpClient http;
        private UsersData? user;

        public UserLoginService(HttpClient _http)
        {
            http = _http;
        }

        async Task<int> IUserLoginService.CheckLogin(string email, string pass)
        {
            try
            {
                user = await http.GetFromJsonAsync<UsersData>("api/UserLogin/getLoginDetails/" + email);
                if (user.email == null)
                { return 0; }
                else
                { return user.id; }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        async Task<bool> IUserLoginService.CheckUser(string email)
        {
            try
            {
                return await http.GetFromJsonAsync<bool>("api/UserLogin/checkUser/" + email);
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
