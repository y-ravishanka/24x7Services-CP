namespace Services1.Client.Services
{
    internal interface ITestService
    {
        Task<bool> CheckServerConnection();
        Task<string> TestDatabase();
    }
}
