using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneVersionSystem
{
    public abstract class Method
    {
        public string methodName { get; set; }

        public abstract void execute(string[] arguments, Clone currentClone, List<Clone> allClons);
    }

    public class MethodRollback : Method
    {        
        public MethodRollback()
        {
            this.methodName = "rollback";
        }

        public override void execute(string[] arguments, Clone currentClone, List<Clone> allClons)
        {
            currentClone.rollback();
        }
    }
    public class MethodLearn : Method
    {
        public MethodLearn()
        {
            this.methodName = "learn";
        }
        public override void execute(string[] arguments, Clone currentClone, List<Clone> allClons)
        {
            currentClone.learn(arguments[2]);
        }
    }
    public class MethodRelearn : Method
    {
        public MethodRelearn()
        {
            this.methodName = "relearn";
        }
        public override void execute(string[] arguments, Clone currentClone, List<Clone> allClons)
        {
            currentClone.relearn();
        }
    }
    public class MethodClone : Method
    {
        public MethodClone()
        {
            this.methodName = "clone";
        }

        public override void execute(string[] arguments, Clone currentClone, List<Clone> allClons)
        {            
            Clone newClone = new Clone();
       
            newClone.historyLearn = new List<string>(currentClone.historyLearn);          
            newClone.historyRollback = new List<string>(currentClone.historyRollback);
            newClone.idClone = allClons[allClons.Count - 1].idClone + 1;

            allClons.Add(newClone);
        }
    }
    public class MethodCheck : Method
    {
        public MethodCheck()
        {
            this.methodName = "check";
        }

        public override void execute(string[] arguments, Clone currentClone, List<Clone> allClons)
        {
            currentClone.check();
        }
    }
}
