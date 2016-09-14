using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_ConsoleDrill
{
    class autoPathy
    {
        internal string fileName { get; set; }
        internal string destFile { get; set; }
        internal DateTime dt; 

        internal void autoTransfer()
        {
            DateTime now = DateTime.Now;
            TimeSpan Span = new TimeSpan(now.Hour, now.Minute, now.Second);

            Console.WriteLine("Time: {0}", now);            
            
            combtrans();
                              
        }
       
        internal void combtrans()
        {
            string source = @"C:\Users\matt\Desktop\Fold1";
            string dest = @"C:\Users\matt\Desktop\Fold2";
            
            string[] files = System.IO.Directory.GetFiles(source);

            Console.WriteLine("Automated daily file transfer initiated. . .\n");
            Console.WriteLine("Files transferred from\n{0}\nto\n{1}  . . .\n", source, dest);

            if (System.IO.Directory.Exists(source))
            {
                foreach (string s in files)
                {
                    dt = System.IO.File.GetLastWriteTime(s);                   
                    if (dt > DateTime.Now.AddHours(-24))
                    {
                        fileName = System.IO.Path.GetFileName(s);
                        destFile = System.IO.Path.Combine(dest, fileName);
                        System.IO.File.Copy(s, destFile, true);
                        Console.WriteLine(s);
                        try
                        {
                            System.IO.File.Delete(s);
                        }
                        catch (System.IO.IOException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
                       

        }
    }
}
