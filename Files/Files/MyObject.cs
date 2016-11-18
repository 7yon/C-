using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    public class MyObject
    {
        public string Name { get; private set; }
        public int? Ozone { get; private set; }
        public int? SolarR { get; private set; }
        public double Wind { get; private set; }
        public int Temp { get; private set; }
        public int Month { get; private set; }
        public int Day { get; private set; }

        public MyObject() { }
    }
}
