using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin2
{
    public class PluginClass2 : IPlugin
    {
        public PluginClass2() { }
        public string Name
        {
            get
            {
                return "PluginClass2";
            }
        }
    }
}
