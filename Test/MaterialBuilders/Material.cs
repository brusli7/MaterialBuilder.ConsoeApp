using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.MaterialBuilders
{
    public abstract class Material
    {
        public Position Positions { get; set; }
        public abstract void Output();
    }
}
