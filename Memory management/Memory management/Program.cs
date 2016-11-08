using System;
using System.Timers;

namespace Memory_management
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new MyTimer();
            using (timer.Start())
            {
                for(int i = 0; i < 1000000; i++)
                {

                }

                timer.Stop();
            }
            Console.WriteLine("after start " + timer.ElapsedMilliseconds);

            using (timer.Continue())
            {
                for (int i = 0; i < 2; i++)
                {
                    for(int y = 0; y < 20000000; y++)
                    {

                    }
                    Console.WriteLine("i - "+ i.ToString() + " " + timer.ElapsedMilliseconds);
                }
            }
            Console.WriteLine("after continue " + timer.ElapsedMilliseconds);

        }
    }
}
