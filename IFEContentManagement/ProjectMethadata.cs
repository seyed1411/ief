using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IFEContentManagement
{
    class ProjectMethadata
    {
        string mainLocation;

        public ProjectMethadata(string _mainLoc)
        {
            mainLocation = _mainLoc;
        }

        public String Music
        {
            get { return mainLocation + @"\" + "playlists"; }
        }
        public String Videos
        {
            get { return mainLocation + @"\" + "movies"; }
        }
        public String pdf
        {
            get { return mainLocation + @"\" + "Articles"; }
        }
        public String announc
        {
            get { return mainLocation + @"\" + "Announcements"; }
        }
    }
}
