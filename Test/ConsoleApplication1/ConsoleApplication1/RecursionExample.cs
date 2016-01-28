using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class RecursionExample
    {
        List<string> log = new List<string>();

        public void Recurse()
        {
            string[] drives = System.Environment.GetLogicalDrives();
            foreach (string dr in drives)
            {
                DriveInfo info = new DriveInfo(dr);
                if (!info.IsReady)
                {
                    Console.WriteLine("Not ready");
                }

                DirectoryInfo rootDir = info.RootDirectory;
                WalkDirectoryTree(rootDir);
            }
        }

        private void WalkDirectoryTree(DirectoryInfo rootDir)
        {
            FileInfo[] files = null;
            DirectoryInfo[] dirInfo = null;
            try
            {
                files = rootDir.GetFiles("*.*");

            }
            catch (Exception e)
            {
                log.Add(e.Message);
            }

            if (files != null)
            {
                foreach (FileInfo fi in files)
                {
                    Console.WriteLine(fi.FullName);

                }

                dirInfo = rootDir.GetDirectories();
                foreach (var dir in dirInfo)
                {
                    WalkDirectoryTree(dir);
                }
            }
        }
    }
}
