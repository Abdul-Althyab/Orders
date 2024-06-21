using System;

namespace OrderConsumers
{
    public interface IOrder
    {
        string Filename { get; set; }
        int Id { get; set; }
        DateTime OrderDate { get; set; }
        bool Status { get; set; }
        string XmlContent { get; set; }
    }
}