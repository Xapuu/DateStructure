using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryContentsInTree
{
    internal class Folder
    {
        private long? _size;

        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();
        }

        public string Name { get; set; }

        public IList<File> Files { get; set; }

        public IList<Folder> ChildFolders { get; set; }

        public long? Size
        {
            get
            {
                if (this._size != null)
                {
                    return this._size;
                }
                else
                {
                    this._size = 0;
                    foreach (var folder in this.ChildFolders)
                    {
                        this._size += folder.Size;
                    }

                    foreach (var file in this.Files)
                    {
                        this._size += file.Size;
                    }

                    return this._size;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder folder = new StringBuilder();
            folder.AppendFormat("FolderName {0}", this.Name);

            if (this.Files.Any())
            {
                folder.AppendLine();
                foreach (var file in this.Files)
                {
                    folder.AppendLine(file.ToString());
                }
            }

            return folder.ToString();
        }
    }
}
