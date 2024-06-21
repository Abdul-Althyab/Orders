using System;

namespace OrderConsumers
{
    public class Order : IOrder
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Status { get; set; }
        public string Filename { get; set; }
        public string XmlContent { get; set; }
    }
}
