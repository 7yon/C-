using System;
using System.Timers;
using System.Drawing;

namespace Memory_management
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new MyTimer();
            var bitmap = (Bitmap)Bitmap.FromFile("img.jpg");

            using (timer.Start())
            {             
                using (var bitmapEditor = new BitmapEditor(bitmap))
                {
                    for(int x = 0; x < bitmap.Width; x++)
                    {
                        for(int y = 0; y < bitmap.Height; y++)
                        {
                            bitmapEditor.SetPixel(x, y, 0, 0, 0);
                        }
                    }
                }
            }
            Console.WriteLine("bitmapEditor: " + timer.ElapsedMilliseconds);

            using (timer.Start())
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        bitmap.SetPixel(x, y, Color.Black);
                    }
                }         
            }
            Console.WriteLine("bitmap: " + timer.ElapsedMilliseconds);
        }
    }
}
