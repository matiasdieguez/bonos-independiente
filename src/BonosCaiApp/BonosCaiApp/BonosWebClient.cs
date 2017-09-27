using System.Net.Http;
using System.Threading.Tasks;

namespace BonosCaiApp
{
    public static class BonosWebClient
    {
        public static bool GetStatus()
        {
            using (var client = new HttpClient())
            {
                var result = client.GetAsync("http://bonos.clubaindependiente.com.ar").Result;
                var response = result.Content.ReadAsStringAsync().Result;
                return response.Contains("DNI");
            }
        }
    }
}
