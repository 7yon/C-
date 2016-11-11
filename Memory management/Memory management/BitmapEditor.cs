using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Memory_management
{
    internal class BitmapEditor : IDisposable
    {
        private Bitmap bitmap;
        private BitmapData bmpData;

        private bool disposedValue = false;

        public BitmapEditor(Bitmap bitmap)
        {
            this.bitmap = bitmap;
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            bmpData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
        }

        ~BitmapEditor()
        {
            Dispose(false);
        }

        public void SetPixel(int x, int y, byte r, byte g, byte b)
        {
            int offset = 3 * x + y * bmpData.Stride;
            IntPtr ptr = IntPtr.Add(bmpData.Scan0, offset);        

            Marshal.Copy(new[] { b, g, r }, 0, ptr, 3);
        }
      

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    bitmap.UnlockBits(bmpData);                   
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}