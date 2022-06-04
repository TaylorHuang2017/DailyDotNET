using System;

namespace Inheritiance_Reference
{
    class Program
    {
        static void Main(string[] args)
        {
            //多态 upcast
            Asset myAsset = new Stock { Name = "MSFT", SharesOwned = 1000 };
            Console.WriteLine(myAsset.Name); //Cannot see myAsset.SharesOwned

            //downcast
            Stock msft = (Stock)myAsset;
            Console.WriteLine(msft == myAsset); //same object
            Console.WriteLine(msft.Name + " " + msft.SharesOwned );

            House h = new House();
            Asset a = new Asset();
            //With "as", no invalid cast exception
            Stock s = a as Stock;
            if ( s != null)
            {
                Console.WriteLine(s.SharesOwned);
            }
            else
                Console.WriteLine("s is null");

            //IS Operator
            if (a is Stock)
            {
                Console.WriteLine(((Stock)a).SharesOwned);
            }

            if (a is Stock s2)
            {
                Console.WriteLine(s2.SharesOwned);
            }
        }
    }



}
