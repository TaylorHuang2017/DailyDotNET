using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritiance_Reference
{
    public class House : Asset
    {
        public decimal Mortgage;
        public override decimal Liability => Mortgage;
    }
}
