using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryContentsInTree
{
    internal class DirectoryTest
    {
        private const string StartingFolder = "D:\\Others";

        private static void Main(string[] args)
        {
            Folder rootFolder = new Folder(StartingFolder);
            DirercorySearch(rootFolder);

            Console.WriteLine(rootFolder);
            Console.WriteLine(rootFolder.Size);
        }

        static void DirercorySearch(Folder folder)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(folder.Name);

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                folder.Files.Add(new File(file.FullName, file.Length));
            }

            foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
            {
                Folder newFolder = new Folder(directory.FullName);

                folder.ChildFolders.Add(newFolder);

                DirercorySearch(newFolder);
            }
        }

    }
}

