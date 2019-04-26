using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HLIMS.Entities;

namespace HLIMS.Services
{
    public class CacheManager
    {
        static CacheManager()
        {
            CacheManager.lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("localhost");
            });
        }
        private static Lazy<ConnectionMultiplexer> lazyConnection;
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
        public static IDatabase OpenCache()
        {
            return CacheManager.Connection.GetDatabase();
        }
    }
}
