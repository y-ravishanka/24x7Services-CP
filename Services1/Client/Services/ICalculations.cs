namespace Services1.Client.Services
{
    internal interface ICalculations
    {
        bool ValidEmail(string email);
        bool ValidContact(string tele);
    }
}
