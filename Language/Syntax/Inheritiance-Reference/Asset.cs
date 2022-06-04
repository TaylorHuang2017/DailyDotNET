using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritiance_Reference
{
    public class Asset
    {
        public string Name; 
        public virtual decimal Liability { get { return 0; } }

        public int Counter = 1;
    }
}
