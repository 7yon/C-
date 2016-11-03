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
            string directory = "D:\\C_SharpCourse\\Plugins\\DLL";
            string[] dllFileNames = null;

            if (Directory.Exists(directory))
            {
                dllFileNames = Directory.GetFiles(directory, "*.dll");
            }

            ICollection<Assembly> assemblies = new List<Assembly>(dllFileNames.Length);
            foreach (string dllFile in dllFileNames)
            {
                AssemblyName an = AssemblyName.GetAssemblyName(dllFile);
                Assembly assembly = Assembly.Load(an);
                assemblies.Add(assembly);
            }

            Type pluginType = typeof(IPlugin);
            List<IPlugin> plugins = new List<IPlugin>();

            foreach (Assembly assembly in assemblies)
            {
                if (assembly != null)
                {
                    Type[] types = assembly.GetTypes();

                    var list = from type in types
                                      where type.IsInterface != true 
                                      && type.IsAbstract != true
                                      && type.GetInterface(pluginType.FullName) != null
                                      && type.GetConstructor(Type.EmptyTypes) != null
                                      select (IPlugin)Activator.CreateInstance(type);

                    plugins.AddRange(list);            
                }
            }
        }
    }
}
