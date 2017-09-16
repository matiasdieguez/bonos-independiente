using System;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using BonosIndependiente.Server.Models;

namespace BonosIndependiente.Server
{
    public class ServiceTicker
    {
        private static readonly Lazy<ServiceTicker> InstanceField =
            new Lazy<ServiceTicker>(() => new ServiceTicker(GlobalHost.ConnectionManager.GetHubContext<NotificationHub>().Clients));

        public Timer Timer;

        public static ServiceTicker Instance => InstanceField.Value;

        private IHubConnectionContext<dynamic> Clients { get; }

        private ServiceTicker(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
            Timer = new Timer(BroadcastNotifications, null, TimeSpan.FromMinutes(0), TimeSpan.FromMinutes(1));
        }

        private void BroadcastNotifications(object state)
        {
            var lastStatus = DataAccess.GetServerData().IsStatusActive;
            var newStatus = BonosWebClient.IsEnabled();

            if (lastStatus == false && newStatus == true)
                Clients.All.notify(NotificationHub.Notify());

            DataAccess.SaveServerData(newStatus);
        }
    }
}