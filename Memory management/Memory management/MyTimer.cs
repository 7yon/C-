using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Timers;

namespace Memory_management
{
    public class MyTimer : IDisposable
    {
        Stopwatch timer = new Stopwatch();
        public long ElapsedMilliseconds
        {
            get
            {
                return timer.ElapsedMilliseconds;
            }
        }

        public MyTimer()
        {
        }

        ~MyTimer()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool fromDisposeMethod)
        {
            if (fromDisposeMethod)
            {
                timer.Stop();
            }

        }

        public MyTimer Start()
        {
            timer.Restart();

            return this;
        }

        public MyTimer Continue()
        {
            timer.Start();

            return this;
        }
    }
}