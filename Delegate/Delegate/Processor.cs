using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class Processor<TObject, TObjectRequest>
    {
        private Func<TObjectRequest, bool> Check;
        private Func<TObjectRequest, TObject> Register;
        private Action<TObject> Save;

        public Processor(Func<TObjectRequest, bool> Check, Func<TObjectRequest, TObject> Register, Action<TObject> Save)
        {
            this.Check = Check;
            this.Register = Register;
            this.Save = Save;
        }

        public TObject Process(TObjectRequest request)
        {
            if (!Check(request))
                throw new ArgumentException();
            var result = Register(request);
            Save(result);
            return result;
        }
    }
}
