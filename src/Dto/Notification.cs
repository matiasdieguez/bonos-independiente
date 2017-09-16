using System;

namespace BonosIndependiente.Dto
{
    public class Notification
    {
        public string Id { get; set; }
        public NotificationType Type { get; set; }
        public DateTime NotificatioDateTime { get; set; }
        public string Message { get; set; }
        public string Url { get; set; }
    }
}