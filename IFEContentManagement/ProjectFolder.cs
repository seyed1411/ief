using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IFEContentManagement
{
    class ProjectFolder
    {
        AudioFolder playlists;
        VideoFolder movies;
        PDFFolder articles;
        AnnouncFolder announces;
        string title;
        string location;

        public ProjectFolder(string _title, string _location)
        {
            playlists = new AudioFolder();
            movies = new VideoFolder();
            articles = new PDFFolder();
            this.title = _title;
            this.location = _location;
        }

        
    }
}
