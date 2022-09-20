using Services1.Shared;
using System.Net.Http.Json;

namespace Services1.Client.Services
{
    internal class AdminService : IAdminService
    {
        private readonly HttpClient http;
        private readonly string url = "api/Admin/";

        public AdminService(HttpClient _http)
        {
            http = _http;
        }

        async Task<bool> IAdminService.ActiveAdmins(int id)
        {
            return await http.GetFromJsonAsync<bool>(url + "activeAdmins/" + id);
        }

        async Task<bool> IAdminService.ChackAdmin(string email)
        {
            try
            {
                return await http.GetFromJsonAsync<bool>(url + "checkAdmin/" + email);
            }
            catch (Exception)
            {
                return false;
            }
        }

        async Task<AdminData> IAdminService.GetAdminData(int id)
        {
            return await http.GetFromJsonAsync<AdminData>(url + "getAdminData/" + id);
        }

        async Task<UsersData> IAdminService.GetAdminLogin(string email)
        {
            return await http.GetFromJsonAsync<UsersData>(url + "getAdminLogin/" + email);
        }

        async Task<List<UsersData>> IAdminService.GetInactiveAdmins()
        {
            return await http.GetFromJsonAsync<List<UsersData>>(url + "getInactiveAdmins");
        }

        async Task<bool> IAdminService.SetAdmin(UsersData admin)
        {
            try
            {
                var t = await http.PostAsJsonAsync<UsersData>(url + "setAdmin", admin);
                return await t.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception)
            {
                return false;
            }
        }

        async Task<bool> IAdminService.SetAdminData(AdminData admin)
        {
            try
            {
                var t = await http.PostAsJsonAsync<AdminData>(url + "setAdminData", admin);
                return await t.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
