using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IFEContentManagement
{
    class PDFFolder
    {
        public List<ArticleFile> library;
        string title;
        string location;
        public PDFFolder(string _location, string _title)
        {
            library = new List<ArticleFile>();
            title = _title;
            location = _location;
        }

        public void CreateNewPDFDirectory()
        {
            DiskIO.CreateDirectory(location, title);
        }
    }
}
