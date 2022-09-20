using Services1.Shared;

namespace Services1.Client.Services
{
    internal interface IUserAboutService
    {
        Task<UserAboutData> GetUserAbout(int id);
    }
}
