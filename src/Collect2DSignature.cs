using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONExtractor
{
    internal class Collect2DSignature 
    {
        public Type type;
        public Type subtype;
        public int count;
        public string name;

        public override string ToString() => $"<< type {type} name {name} (subtype {subtype}[cnt {count}]) >>";
    }
}
