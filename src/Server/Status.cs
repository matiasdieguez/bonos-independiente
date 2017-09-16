namespace BonosIndependiente.Server
{
    public static class Status
    {
        public static string GetResponse()
        {
            return BonosWebClient.IsEnabled().ToString();
        }
    }
}