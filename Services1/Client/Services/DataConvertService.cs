using Services1.Client.Models;
using Services1.Shared;

namespace Services1.Client.Services
{
    internal class DataConvertService : IDataConvertService
    {
        UserAboutData IDataConvertService.ConvertAboutData(UserBasicModel user)
        {
            return new UserAboutData
            {
                fname = user.fname,
                dname = user.dname,
                lname = user.lname,
                nic = user.nic
            };
        }

        SignInData IDataConvertService.ConvertSignInData(UserSignInModel user)
        {
            return new SignInData
            {
                password = user.password,
                username = user.username
            };
        }
    }
}
