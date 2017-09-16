using System;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using BonosIndependiente.Dto;

namespace BonosIndependiente.Server
{
    [HubName("notificationHub")]
    public class NotificationHub : Hub
    {
        public readonly ServiceTicker Ticker;

        public NotificationHub() : this(ServiceTicker.Instance)
        {
        }

        public NotificationHub(ServiceTicker ticker)
        {
            Ticker = ticker;
        }

        public static IEnumerable<Notification> Notify()
        {
            return new List<Notification>
            {
                new Notification
                {
                    Id = Guid.NewGuid().ToString(),
                    Type = NotificationType.ReservaBonoHabilitada,
                    Url = "http://bonos.clubaindependiente.com.ar/",
                    NotificatioDateTime = DateTime.Now,
                    Message = "Reserva de bono habilitada"
                }
            };
        }
    }
}