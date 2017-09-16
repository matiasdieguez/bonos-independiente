using System.Net;

namespace BonosIndependiente.Server
{
    public class BonosWebClient
    {
        public static bool IsEnabled()
        {
            using (var client = new WebClient())
            {
                var content = client.DownloadString("http://bonos.clubaindependiente.com.ar/");
                return content.Contains("DNI");
            }
        }
    }
}