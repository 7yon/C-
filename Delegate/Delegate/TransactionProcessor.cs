using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class TransactionProcessor
    {
        private Func<TransactionRequest, bool> Check;
        private Func<TransactionRequest, Transaction> Register;
        private Action<Transaction> Save;

        public TransactionProcessor(Func<TransactionRequest, bool> Check, Func<TransactionRequest, Transaction> Register, Action<Transaction> Save)
        {
            this.Check = Check;
            this.Register = Register;
            this.Save = Save;
        }

        public Transaction Process(TransactionRequest request)
        {
            if (!Check(request))
                throw new ArgumentException();
            var result = Register(request);
            Save(result);
            return result;
        }
    }
}
