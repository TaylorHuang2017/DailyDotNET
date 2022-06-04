using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritiance_Reference
{
    public class Stock : Asset
    {
        public long SharesOwned;
        public new int Counter = 2; // hide the Counter property in base class
    }
}
