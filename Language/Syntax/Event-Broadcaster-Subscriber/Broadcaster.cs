using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Event_Broadcaster_Subscriber
{
    //委托 ****Handler
    public delegate void PriceChangedHandler(decimal oldPrice, decimal newPrice);    

    //Stock class is the broadcaster that owns an event
    public class Broadcaster
    {
        string symbol;
        decimal price;

        //事件和委托进行关联
        public event PriceChangedHandler PriceChanged;
        public Broadcaster(string symbol)
        {
            this.symbol = symbol;
        }        

        public decimal Price 
        { 
            get => price;
            set
            {
                if (price == value) return;
                decimal oldPrice = price;
                price = value;

                //什么时候触发事件，发生后调用对应的委托
                if (PriceChanged !=null)
                {
                    PriceChanged(oldPrice, price);
                }
            }
        }
    }
}
