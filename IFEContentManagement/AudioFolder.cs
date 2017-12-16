using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IFEContentManagement
{
    class AudioFolder
    {
        public List<MusicPlaylist> library;
        string title;
        string location;
        
        public AudioFolder(string _location, string _title)
        {
            library = new List<MusicPlaylist>();
            title = _title;
            location = _location;
        }

        public void CreateNewAudioDirectory()
        {           
            DiskIO.CreateDirectory(location,title);
        }
    }
}
