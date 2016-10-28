using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public interface IObserver
    {
        void Update(IReadOnlyList<IReadOnlyList<int>> table);
    }
}
