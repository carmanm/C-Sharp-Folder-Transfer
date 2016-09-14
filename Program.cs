using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Windows.Input;


namespace CS_ConsoleDrill
{

    class Program
    {
        

        static void Main(string[] args)
        {
            pathy P = new pathy();
            autoPathy ap = new autoPathy();
            ap.autoTransfer();
            P.dirSearchInit();                                          
            Console.Read();
        }
        
    }
    class pathy
    {
        internal string source;
        internal string dest;

        internal void dirSearchInit()
        {
            string mutPath = @"C:\";
            DirectoryInfo _dir = new DirectoryInfo(mutPath);
            DirectoryInfo[] _dirInfo = _dir.GetDirectories();

            Console.WriteLine("\nMANUAL MODE ACTIVE:\nBrowse for directory to be transferred, press enter to begin:");
            string s = Console.ReadLine();

            if(s == "")
            {
                foreach (DirectoryInfo item in _dirInfo)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                Console.WriteLine("Press enter to begin. . .");
                dirSearchInit();
            }

            string s1 = Console.ReadLine();

            try
            {
                if (s1 == "-r")
                {
                    dirSearchInit();
                }

                foreach (DirectoryInfo item in _dirInfo)
                {
                    if (s1 == "cd " + item.Name)
                    {
                        string _mutPath = Path.Combine(mutPath, item.Name);
                        Console.WriteLine(mutPath);
                        dirSearch(_mutPath);
                    }


                }
            }
            catch
            {
                Console.WriteLine("Invalid directory name or syntax, use cd before directory name. Press enter to retry...");
                string ss = Console.ReadLine();
                if (ss == "")
                {
                    dirSearch(mutPath);
                }
            }


            //    if (s1 != "-r" || s1 != "-s" || s1.StartsWith("cd ") == false)
            //{
            //    Console.WriteLine("Invalid directory name or syntax, use cd before directory name. Press enter to retry...");
            //    string ss = Console.ReadLine();
            //    if (ss == "")
            //    {
            //        dirSearch(mutPath);
            //    }
            //}



        }
       
        internal void dirSearch(string stringPath)
        {            

            Console.WriteLine("___________________________________________________________________________");

            DirectoryInfo _dir = new DirectoryInfo(stringPath);
            DirectoryInfo[] _dirInfo = _dir.GetDirectories();

            foreach (DirectoryInfo item in _dirInfo)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("Press \'-r\' to restart process or \'-s\' to select source folder. . . ");
            string s2 = Console.ReadLine();
            
            
            foreach(DirectoryInfo item in _dirInfo)
            {

                if (s2 == "cd " + item.Name)
                {
                    stringPath = Path.Combine(stringPath, item.Name);
                    Console.WriteLine(stringPath);
                    dirSearch(stringPath);
                }                                       
            }
            
            if (s2 == "cd .." || s2 == "cd . ." || s2 == "CD.." || s2 == "CD . ." || s2 =="cd..")
            {
                
                Console.WriteLine(stringPath);
                try
                {
                    dirSearch(Directory.GetParent(stringPath).ToString());
                }
                catch
                {
                    dirSearch(stringPath);
                    Console.WriteLine("Select a directory from the C drive above. . .");
                }

                
            }
            else if (s2 == "-r")
            {
                dirSearchInit();
            }
            else if (s2 == "-s")
            {
                Console.WriteLine("Marker");
                source = stringPath;                
                destSearchInit();                
            }
            if (s2 != "-r" || s2 != "-s" || s2.StartsWith("cd ") == false)
            {              
                Console.WriteLine("Invalid directory name or syntax, use cd before directory name and try again. . . ");
                dirSearch(stringPath);
            }
        }
        
        internal void destSearchInit()
        {
            string mutPath = @"C:\";
            DirectoryInfo _dir = new DirectoryInfo(mutPath);
            DirectoryInfo[] _dirInfo = _dir.GetDirectories();

            Console.WriteLine("Browse for destination directory, press enter to begin:");
            string s = Console.ReadLine();

            if (s == "")
            {
                foreach (DirectoryInfo item in _dirInfo)
                {
                    Console.WriteLine(item.Name);
                }
            }

            string s1 = Console.ReadLine();


            foreach (DirectoryInfo item in _dirInfo)
            {
                if (s1 == "cd " + item.Name)
                {
                    string _mutPath = Path.Combine(mutPath, item.Name);
                    Console.WriteLine(mutPath);
                    destSearch(_mutPath);
                }



            }
            if (s1 == "-r")
            {
                destSearchInit();
            }
            if (s1 != "-r" || s1 != "-s" || s1.StartsWith("cd ") == false)
            {
                Console.WriteLine("Invalid directory name or syntax, use cd before directory name. Press enter to retry...");
                string ss = Console.ReadLine();
                if (ss == "")
                {
                    destSearch(mutPath);
                }
            }
        }

        internal void destSearch(string stringPath)
        {
            Console.WriteLine("___________________________________________________________________________");

            DirectoryInfo _dir = new DirectoryInfo(stringPath);
            DirectoryInfo[] _dirInfo = _dir.GetDirectories();

            foreach (DirectoryInfo item in _dirInfo)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("Press \'-r\' to restart process or \'-s\' to select source folder. . . ");
            string s2 = Console.ReadLine();


            foreach (DirectoryInfo item in _dirInfo)
            {

                if (s2 == "cd " + item.Name)
                {
                    stringPath = Path.Combine(stringPath, item.Name);
                    Console.WriteLine(stringPath);
                    destSearch(stringPath);
                }
            }

            if (s2 == "cd .." || s2 == "cd . ." || s2 == "CD.." || s2 == "CD . .")
            {
                Console.WriteLine(stringPath);
                destSearch(stringPath);
            }
            else if (s2 == "-r")
            {
                destSearchInit();
            }
            else if (s2 == "-s")
            {
                Console.WriteLine("Marker");
                dest = stringPath;
                combtrans();
                
            }
            if (s2 != "-r" || s2 != "-s" || s2.StartsWith("cd") == false)
            {
                Console.WriteLine("Invalid directory name or syntax, use cd before directory name and try again. . . ");
                
            }
        }

        internal string fileName;
        internal string destFile;

        internal void combtrans()
        {
            Console.WriteLine(source);
            Console.WriteLine(dest);
            string[] files = System.IO.Directory.GetFiles(source);

            if (System.IO.Directory.Exists(source))
            {                            
                foreach (string s in files)
                {                    
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(dest, fileName);
                    System.IO.File.Copy(s, destFile, true);
                    try
                    {
                        System.IO.File.Delete(s);
                    }
                    catch(System.IO.IOException e)
                    {
                       Console.WriteLine(e.Message);
                    }
                }
                
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }

            Console.WriteLine("Files transferred:");
            foreach (string s in files)
            {

                Console.WriteLine(s);
            }

        }

        

    }
}
