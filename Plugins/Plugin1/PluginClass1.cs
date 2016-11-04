using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin1
{
    public class PluginClass1 : IPlugin
    {
        public PluginClass1() { }
        public string Name
        {
            get
            {
                return "PluginClass1";
            }
        }
    }
}
