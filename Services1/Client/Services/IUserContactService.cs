using Services1.Shared;

namespace Services1.Client.Services
{
    internal interface IUserContactService
    {
        Task<List<UserContactData>> GetUserContacts(int id);
        Task<bool> SetUserContact(UserContactData user);
    }
}
