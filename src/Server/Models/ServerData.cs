using System;

namespace BonosIndependiente.Server.Models
{
    public class ServerData
    {
        public int Id { get; set; }
        public bool IsStatusActive { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
