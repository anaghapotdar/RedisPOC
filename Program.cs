using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RedisTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();

            //Save the data in Cache
            Console.WriteLine("Saving random data in cache");
            program.SaveBigData();

            //Add some delay just to display output properly
            Thread.Sleep(2000);

            //Read the data from Cache
            Console.WriteLine("Reading data from cache");
            program.ReadData();

            Console.ReadLine();
        }

        //Reads the data from Cache for Key FundId:N 
        public void ReadData()
        {
            var cache = RedisConnectorHelper.Connection.GetDatabase();
            var fundCount = 50;
            for (int i = 0; i < fundCount; i++)
            {
                var value = cache.StringGet($"FundId:{i}");
                Console.WriteLine($"Valor={value}");
            }
        }

        //Saves the data in key value pair - key FundId:N  
        public void SaveBigData()
        {
            var fundCount = 50;
            var rnd = new Random();
            var cache = RedisConnectorHelper.Connection.GetDatabase();

            for (int i = 1; i < fundCount; i++)
            {
                var value = rnd.Next(0, 10);
                cache.StringSet($"FundId:{i}", value);
                Console.WriteLine($"Valor={value}");
            }
        }
    }
}
