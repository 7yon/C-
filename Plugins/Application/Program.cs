using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Framework;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory = "D:\\C_Sharp\\Plugins\\DLL";

            Type pluginType = typeof(IPlugin);

            if (Directory.Exists(directory))
            {
                foreach(string dllFile in Directory.GetFiles(directory, "*.dll"))
                {
                    Type[] types = Assembly.LoadFile(dllFile).GetTypes();                   
                    foreach (Type type in types)
                    {
                        if ((type.GetConstructor(Type.EmptyTypes) != null) && (!type.IsInterface)
                            && (!type.IsAbstract) && (type.GetInterface(pluginType.FullName) != null))
                        {
                            var instanceOfMyType = Activator.CreateInstance(type) as IPlugin;
                            Console.WriteLine(instanceOfMyType.Name);
                        }
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
