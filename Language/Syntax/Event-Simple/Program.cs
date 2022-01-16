using System;

namespace Event_Simple
{
    //delegate void Handler(); 示例中使用了.net类库中定义的标准委托类型： EventHandler
    //它有两个参数，一个是触发事件的对象的引用 sender 另一个是状态信息 EventArgs

    class Incrementer
    {
        public event EventHandler CountedADozen;

        public void DoCount(int n)
        {
            for (int i = 1; i < n; i++)
            {
                if (i % 12 == 0 && CountedADozen != null)
                {
                    CountedADozen(this, null);
                }
            }
        
        }
    }

    class Dozens
    {
        public int DozensCount { get; private set; }

        public Dozens(Incrementer incrementer)
        {
            DozensCount = 0;
            incrementer.CountedADozen += IncrementDonzesCount; 
        }

        private void IncrementDonzesCount(object source, EventArgs e)
        {
            DozensCount++; 
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Incrementer incrementer = new Incrementer();
            Dozens dozensCounter = new Dozens(incrementer);

            incrementer.DoCount(170);
            Console.WriteLine($"Number of dozens: {dozensCounter.DozensCount}");
            
        }
    }
}
