using System.ComponentModel.DataAnnotations;

namespace Services1.Client.Services
{
    internal class Calculations : ICalculations
    {
        bool ICalculations.ValidContact(string tele)
        {
            if (tele == null || tele == "")
            { return false; }
            else
            {
                try
                {
                    int t = Convert.ToInt32(tele);
                    if (tele.Length != 10)
                    { return false; }
                    else
                    {
                        if (tele[0] != 0)
                        { return false; }
                        else
                        { return true; }
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        bool ICalculations.ValidEmail(string email)
        {
            if (new EmailAddressAttribute().IsValid(email))
                return true;
            else
                return false;
        }
    }
}
