using Services1.Client.Models;
using Services1.Shared;

namespace Services1.Client.Services
{
    internal interface IDataConvertService
    {
        SignInData ConvertSignInData(UserSignInModel user);
        UserAboutData ConvertAboutData(UserBasicModel user);
    }
}
