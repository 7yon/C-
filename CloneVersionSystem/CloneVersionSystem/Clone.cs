using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneVersionSystem
{
    public class Clone
    {
        public int idClone { get; set; }

        public List<string> historyRollback { get; set; }
        public List<string> historyLearn { get; set; }

        public Clone()
        {
            historyLearn = new List<string>();
            historyRollback = new List<string>();
        }

        public void learn(string program)
        {
            string foundValue = historyLearn.Find(x => x == program);

            if (foundValue == null)
            {
                historyLearn.Add(program);
                historyRollback.Clear();
            }          
        }
        public void rollback()
        {
            if (historyLearn.Count > 1)
            {
                string currentProgram;

                currentProgram = historyLearn[historyLearn.Count - 1];
                historyRollback.Add(currentProgram);
                historyLearn.RemoveAt(historyLearn.Count - 1);
            }
        }
        public void relearn()
        {
            historyLearn.Add(historyRollback[historyRollback.Count - 1]);
            historyRollback.RemoveAt(historyRollback.Count - 1);
        }
        public void check()
        {
            Console.Write("Current program: " + historyLearn[historyLearn.Count - 1]);
            Console.Write("\n");
        }
    }

    public class CloneVersionSystem
    {
        public List<Clone> allClons { get; set; }
        public List <Method> allMethods { get; set; }    

        public CloneVersionSystem()
        {
            allClons = new List<Clone>();
            allMethods = new List<Method>();

            Clone newClone = new Clone();
            newClone.idClone = 1;
            newClone.learn("basic");
            allClons.Add(newClone);

            MethodCheck check = new MethodCheck();
            MethodClone clone = new MethodClone();
            MethodLearn learn = new MethodLearn();
            MethodRelearn relearn = new MethodRelearn();
            MethodRollback rollback = new MethodRollback();

            allMethods.Add(check);
            allMethods.Add(clone);
            allMethods.Add(learn);
            allMethods.Add(relearn);
            allMethods.Add(rollback);
        }     
        public void reader()
        {
            int queryCount, programCount;

            queryCount = int.Parse(Console.ReadLine());
            programCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < queryCount; i++)
            {
                string currentQuery = Console.ReadLine();
                executeQuery(currentQuery);
            }
        }
        void executeQuery(string currentQuery)
        {
            Clone currentClone;

            String[] query = currentQuery.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            currentClone = allClons.Find(x => x.idClone == Convert.ToInt32(query[1]));

            for  (int i = 0; i < allMethods.Count; i++)
            {
                if (allMethods[i].methodName == query[0])
                    allMethods[i].execute(query, currentClone, allClons);
            }                      
        }
    }
}
