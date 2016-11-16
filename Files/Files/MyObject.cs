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
        public int? Solar { get; private set; }
        public double Wind { get; private set; }
        public int Temp { get; private set; }
        public int Month { get; private set; }
        public int Day { get; private set; }

        public MyObject(string Name, int? Ozone, int? Solar, double Wind, int Month, int Day)
        {
            this.Name = Name;
            this.Ozone = Ozone;
            this.Solar = Solar;
            this.Wind = Wind;
            this.Month = Month;
            this.Day = Day;
        }

        public MyObject() { Name = "fsf"; }
    }
}
