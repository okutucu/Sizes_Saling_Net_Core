using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace İmageLess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string picturesPath = @"C:\Users\silve\Desktop\images";

            var files = Directory.GetFiles(picturesPath);

            Parallel.ForEach(files, (item) =>
            {
                Console.WriteLine("Thread no : " + Thread.CurrentThread.ManagedThreadId);

                Image img = new Bitmap(item);
                var thumbnail = img.GetThumbnailImage(300,300,()=> false,IntPtr.Zero);

                thumbnail.Save(Path.Combine(picturesPath, "lessimages",Path.GetFileName(item)));
            });
        }
    }
}
