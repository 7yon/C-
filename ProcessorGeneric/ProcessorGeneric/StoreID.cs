using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessorGeneric
{
    public static class StoreID
    {
        private static List<Dictionary<int, object>> store = new List<Dictionary<int, object>>();
        private static int currentId = 0;

        public static TObject Create<TObject>() where TObject : new()
        {           
            TObject currentObject = new TObject();
            bool foundCurrentType = false;

            for (int i = 0; i < store.Count; i++)
            {
                if (store[i].First().Value is TObject)
                {
                    store[i].Add(currentId, currentObject);                 
                    foundCurrentType = true;
                    break;
                }
            }

            if (!foundCurrentType) { 
                store.Add(new Dictionary<int, object>());
                store[store.Count - 1].Add(currentId, currentObject);
            }

            ++currentId;
            return currentObject;
        }

        public static Dictionary<int, object> OutAllPair<TObject>()
        {
            for (int i = 0; i < store.Count; i++)
            {
                if (store[i].First().Value is TObject)
                {
                    return store[i];
                }
            }
            return null;
        }

        public static TObject Find<TObject>(int id)
        {
            for (int i = 0; i < store.Count; i++)
            {
                if ((store[i].ContainsKey(id) && store[i][id] is TObject)) 
                {
                    return (TObject)store[i][id];                  
                }
            }
            return default(TObject);
        }
    }
}
