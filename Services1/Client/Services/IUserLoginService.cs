namespace Services1.Client.Services
{
    internal interface IUserLoginService
    {
        Task<int> CheckLogin(string email, string pass);
        Task<bool> CheckUser(string email);
    }
}
