using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace IFEContentManagement
{
    class ProjectFolder
    {
        // constant program parameters
        public const string AUDIO_FOLDER_NAME = "playlists";
        public const string VIDEO_FOLDER_NAME = "movies";
        public const string PDF_FOLDER_NAME = "articles";
        public const string ANNOUNC_FOLDER_NAME = "announcements";

        // variables and members
        AudioFolder playlists;
        VideoFolder movies;
        PDFFolder articles;
        AnnouncFolder announces;
        string title;
        string location;

        public ProjectFolder(string _title, string _location)
        {
            this.title = _title;
            this.location = _location;
            playlists = new AudioFolder(ContentLocation, AUDIO_FOLDER_NAME);
            movies = new VideoFolder(ContentLocation, VIDEO_FOLDER_NAME);
            articles = new PDFFolder(ContentLocation, PDF_FOLDER_NAME);
            announces = new AnnouncFolder(ContentLocation, ANNOUNC_FOLDER_NAME);            
        }

        public string ContentLocation
        {
            get { return location + @"\" + title + @"\files"; }
        }

        public void CreateNewProjectDirectories()
        {
            //create projet itslef files and folders
            DiskIO.CreateDirectory(location,title);
            DiskIO.CreateDirectory(ContentLocation);
            this.CreateNewProjetFiles();

            //create subfolders for contents
            playlists.CreateNewAudioDirectory();
            movies.CreateNewVideoDirectory();
            articles.CreateNewPDFDirectory();
            announces.CreateNewVideoDirectory();
        }

        private void CreateNewProjetFiles()
        {
            // create index.json file
            string path = location + @"\" + title;
            ProjectMethadata toFile = new ProjectMethadata(this.ContentLocation);
            string str = JsonConvert.SerializeObject(toFile);
            DiskIO.CreateTextFile(path, "index.json", str);
        }
    }
}
