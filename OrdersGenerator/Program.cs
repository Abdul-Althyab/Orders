using System;
using System.IO;
using System.Threading;
using System.Xml.Serialization;

namespace OrdersGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string directory = @"C:\Orders";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            OrdersWegShrijven(directory);
        }

        private static void OrdersWegShrijven(string directory)
        {
            bool status = true;
            while (true)
            {
                Order order = new Order { Status = status };
                string filename = Path.Combine(directory, $"order_{Guid.NewGuid()}.xml"); // unieke naam

                XmlSerializer serializer = new XmlSerializer(typeof(Order));
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    serializer.Serialize(writer, order);
                }
                Console.WriteLine("Order created successfully.");
                status = !status;
                Thread.Sleep(5000);
            }
        }
    }
}
