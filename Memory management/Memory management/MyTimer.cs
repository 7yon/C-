using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Timers;

namespace Memory_management
{
    public class MyTimer : IDisposable
    {
        Stopwatch timer = new Stopwatch();
        bool isDispose = false;
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool fromDisposeMethod)
        {
            if (!isDispose)
            {
                if (fromDisposeMethod)
                {
                    timer.Stop();
                }
            }
        }

        public IDisposable Start()
        {
            timer.Reset();
            timer.Start();
            isDispose = false;

            return this;
        }

        public IDisposable Stop()
        {
            timer.Stop();
            isDispose = true;

            return this;
        }

        public IDisposable Continue()
        {
            timer.Start();

            return this;
        }
    }
}