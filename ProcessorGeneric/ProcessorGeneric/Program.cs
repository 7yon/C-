using ProcessorGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessorGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = ProcessorBuilder.CreateEngine<MyEngine>().For<MyEntity>().With<MyLogger>();

            StoreID.Create<MyLogger>();
            StoreID.Create<MyEngine>();
            StoreID.Create<MyEntity>();

            var a = StoreID.Find<MyEntity>(2);
        }
    }
}
