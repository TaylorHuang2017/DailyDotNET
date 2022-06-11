using System;

namespace Event_Broadcaster_Subscriber  //Subscriber class
{
    
    class Program
    {
        static void Main(string[] args)
        {
            //v1
            Console.WriteLine("=====V1 Custom Event====");
            Broadcaster stock = new Broadcaster("MSFT");//broadcaster
            stock.PriceChanged += ReportPriceChange; //订阅事件、关联委托对应的方法
            stock.Price = 113;
            stock.Price = 456;
            stock.Price = 456;

            //v2 Standard Event Pattern
            Console.WriteLine("=====V2 Standard Event Pattern====");
            Broadcaster_v2 stockT = new Broadcaster_v2("THPW");
            stockT.Price = 27.1M;
            stockT.PriceChanged += Stock_PriceChanged;
            stockT.Price = 31.59M;


        }

        static void Stock_PriceChanged(object sender, PriceChangedEventArgs e)
        {
            if ((e.NewPrice - e.LastPrice) / e.LastPrice > 0.1M)
            {
                Console.WriteLine("Alert, 10% stock price increase!");
            }
        }

        static void ReportPriceChange(decimal oldPrice, decimal newPrice)
        {
            Console.WriteLine($"Price changed from {oldPrice}  to {newPrice}"); 
        }
    }
}
