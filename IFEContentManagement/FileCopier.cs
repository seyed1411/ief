using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IFEContentManagement
{
    public class FileCopier
    {
        public string SourceFile;
        public string DestinationFile;

        public FileCopier(string _source, string _dest)
        {
            SourceFile = string.Copy(_source);
            DestinationFile = string.Copy(_dest);
        }
    }
}
