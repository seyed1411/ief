using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IFEContentManagement
{
    class VideoFolder
    {
        public List<MovieFile> library;
        string title;
        string location;

        public VideoFolder(string _location, string _title)
        {
            library = new List<MovieFile>();
            title = _title;
            location = _location;            
        }

        private string ContentLocation
        {
            get { return location + "\\" + title; }
        }

        public void CreateNewVideoDirectory()
        {
            DiskIO.CreateDirectory(location, title);
            DiskIO.DeleteFile(ContentLocation, "index.en.json");
        }
    }
}
