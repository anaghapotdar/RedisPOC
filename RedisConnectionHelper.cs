using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace RedisTestApp
{
    public class RedisConnectorHelper
    {
        //
        static RedisConnectorHelper()
        {
            RedisConnectorHelper.lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("localhost"); //Can be replaced by appropriate ip of redis server
                //return ConnectionMultiplexer.Connect("10.78.29.54");
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
    }
}
