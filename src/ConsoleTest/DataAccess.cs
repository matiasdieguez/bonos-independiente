using LiteDB;
using System;

namespace ConsoleTest
{
    public static class DataAccess
    {
        private const string DB = "CAI.db";

        public static void SaveServerData(bool status)
        {
            using (var db = new LiteDatabase(DB))
            {
                var data = db.GetCollection<ServerData>("serverData");

                var newData = new ServerData
                {
                    IsStatusActive = status,
                    LastUpdate = DateTime.Now
                };

                data.Upsert(newData);
            }
        }

        public static ServerData GetServerData()
        {
            using (var db = new LiteDatabase(DB))
            {

                var data = db.GetCollection<ServerData>("serverData");
                data.EnsureIndex(x => x.Id);

                var result = data.FindOne(d => d.Id == 1);

                if (result == null)
                    return new ServerData { IsStatusActive = false };
                else
                    return result;
            }
        }
    }
}