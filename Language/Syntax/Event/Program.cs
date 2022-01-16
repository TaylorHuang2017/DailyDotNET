using System;
using System.Threading;

namespace Event
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            customer.Order += waiter.Action;
            customer.Action();
            customer.PayTheBill();
        }
    }

    public class OrderEventArgs:EventArgs
    {
        public string DishName { get; set; }
        public string Size { get; set; }
    }

    //定义委托
    public delegate void OrderEventHandler(Customer customer, OrderEventArgs e); 

    public class Customer
    {
        //关联自定义的委托 
        private OrderEventHandler orderEventHandler;  

        //事件的本质是委托字段的一个包装器
        //事件使用委托存储对应的事件处理器（方法）
        
        public event OrderEventHandler Order //OnOrder
        {
            add
            {
                this.orderEventHandler += value;
            }
            remove
            {
                this.orderEventHandler -= value; 
            }
        }

        /*事件的简化声明 
         * 无需再声明一个委托类型的字段
         * 只声明事件，由编译器自动生成委托类型的字段
          public event EventHandler Order;

        this.Order != null

         this.Order.Invoke(this, e)
         */

        public double Bill { get; set; }
        public void PayTheBill()
        {
            Console.WriteLine("I will pay ${0}.", this.Bill);
        }

        public void WalkIn()
        {
            Console.WriteLine("Walk into the restaurant");
        }
        public void SitDown()
        {
            Console.WriteLine("Sit down");
        }
        public void Think()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Let me Think...");
                Thread.Sleep(1000);
            }
            this.OnOrder("Kongpao Chicken", "large"); //触发事件
        }

        //触发事件的方法
        protected void OnOrder(string dishName, string size)
        {
            
            if (this.orderEventHandler != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = dishName;
                e.Size = size;
                this.orderEventHandler.Invoke(this, e);
            }
        }
        

        public void Action()
        {
            Console.ReadLine();
            this.WalkIn();
            this.SitDown();
            this.Think();
        }
    }


    public class Waiter
    {
        public void Action(Customer customer, OrderEventArgs e)
        {
            Console.WriteLine("I will serve you the dish - {0}", e.DishName);
            double price = 10.0;
            switch (e.Size)
            {
                case "small":
                    price = price * 0.5;
                    break;
                case "large":
                    price = price * 1.5;
                    break; 
                default:
                    break;
            }
            customer.Bill += price; 
        }
    }
}
