using Services1.Shared;

namespace Services1.Client.Services
{
    internal interface IAdminService
    {
        Task<UsersData> GetAdminLogin(string email);
        Task<bool> ChackAdmin(string email);
        Task<bool> SetAdmin(UsersData admin);
        Task<bool> SetAdminData(AdminData admin);
        Task<AdminData> GetAdminData(int id);
        Task<bool> ActiveAdmins(int id);
        Task<List<UsersData>> GetInactiveAdmins();
    }
}
