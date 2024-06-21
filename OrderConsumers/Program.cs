using System;
using System.Data.Entity;
using System.IO;
using System.Xml.Serialization;


namespace OrderConsumers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<OrderContext>());  // chatgpt oplossing

            using (var context = new OrderContext())
            {
                context.Database.Initialize(force: true);
                Console.WriteLine("Data inserted into database successfully");
            }

            string directoryPath = @"C:\Orders";

            while (true)
            {
                foreach (var file in Directory.GetFiles(directoryPath, "*.xml"))
                {
                    using (var context = new OrderContext())
                    {
                        var order = DeserializeOrder(file);
                        order.OrderDate = DateTime.Now;
                        order.Filename = Path.GetFileName(file);
                        order.XmlContent = File.ReadAllText(file);
                        context.Orders.Add(order);
                        context.SaveChanges();
                    }

                    File.Delete(file);
                }

                System.Threading.Thread.Sleep(5000);
            }
        }

        private static Order DeserializeOrder(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Order));
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                return (Order)serializer.Deserialize(stream);
            }
        }
    }
}

