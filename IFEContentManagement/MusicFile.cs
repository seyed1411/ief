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
        public string length; // as timespan

        public MusicFile() { }
        public MusicFile(string _fileName, string _fileTitle, string _length)
        {
            file = _fileName;
            title = _fileTitle;
            length = _length;
        }
    }
}
