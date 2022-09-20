using Services1.Shared;
using System.Net.Http.Json;

namespace Services1.Client.Services
{
    internal class TestService : ITestService
    {
        private readonly HttpClient http;
        private TestData t = new();

        public TestService(HttpClient _http)
        {
            http = _http;
        }

        async Task<bool> ITestService.CheckServerConnection()
        {
            try
            {
                t = await http.GetFromJsonAsync<TestData>("api/Test/testConnection");
                if (t.test2 == true)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        async Task<string> ITestService.TestDatabase()
        {
            try
            {
                int t = 1;
                return await http.GetStringAsync("api/Test/testdatabase/" + t);
                //string s1 = s.ToString();
                //Console.WriteLine("return value of the api to service - \n"+s);
                //return s1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
