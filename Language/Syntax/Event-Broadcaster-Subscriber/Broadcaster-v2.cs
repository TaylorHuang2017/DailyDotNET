using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Broadcaster_Subscriber
{
    public class Broadcaster_v2
    {
        string symbol;
        decimal price;
        public Broadcaster_v2(string symbol)
        {
            this.symbol = symbol;
        }

        //定义事件
        //框架自带泛型委托： System.EventHandler<>，，无需声明
        public event EventHandler<PriceChangedEventArgs> PriceChanged;

        //定义事件触发方法 On+事件名称
        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        {
            PriceChanged?.Invoke(this, e);
        }

        public decimal Price
        {
            get => price;
            set
            {
                if (price == value) return;
                decimal oldPrice = price;
                price = value;
                OnPriceChanged(new PriceChangedEventArgs(oldPrice, price));
            }
        }
     }

    //事件额外信息： 继承 System.EventArgs
    public class PriceChangedEventArgs : System.EventArgs
    {
        public readonly decimal LastPrice;
        public readonly decimal NewPrice;

        public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
        {
            this.LastPrice = lastPrice;
            this.NewPrice = newPrice;
        }
    }
}
