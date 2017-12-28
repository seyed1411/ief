using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IFEContentManagement
{
    public class MusicFile
    {
        public string file;
        public string title;
        public int length; // to second

        public MusicFile() { }
        public MusicFile(string _fileName, string _fileTitle, int _length)
        {
            file = _fileName;
            title = _fileTitle;
            length = _length;
        }
    }
}
