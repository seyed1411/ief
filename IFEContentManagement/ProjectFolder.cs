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
        string title;
        string location;

        public ProjectFolder()
        {
            playlists = new AudioFolder();
        }

        
    }
}
