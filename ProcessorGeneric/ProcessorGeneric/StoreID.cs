using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessorGeneric
{
    public static class StoreID
    {
        private static List<Dictionary<Guid, object>> store = new List<Dictionary<Guid, object>>();

        public static TObject Create<TObject>() where TObject : new()
        {           
            TObject currentObject = new TObject();
            bool foundCurrentType = false;

            for (int i = 0; i < store.Count; i++)
            {
                if (store[i].First().Value.GetType() == typeof(TObject))
                {
                    store[i].Add(Guid.NewGuid(), currentObject);                 
                    foundCurrentType = true;
                    break;
                }
            }

            if (!foundCurrentType) { 
                store.Add(new Dictionary<Guid, object>());
                store[store.Count - 1].Add(Guid.NewGuid(), currentObject);
            }

            return currentObject;
        }

        public static Dictionary<Guid, object> OutAllPair<TObject>()
        {
            for (int i = 0; i < store.Count; i++)
            {
                if (store[i].First().Value.GetType() == typeof(TObject))
                {
                    return store[i];
                }
            }
            return null;
        }

        public static Dictionary<Guid, object> Find<TObject>(Guid id)
        {
            for (int i = 0; i < store.Count; i++)
            {
                if ((store[i].ContainsKey(id) && store[i][id].GetType() == typeof(TObject)))
                {
                    return store[i];                  
                }
            }
            return default(Dictionary<Guid, object>);
        }
    }
}
