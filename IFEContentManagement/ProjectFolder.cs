using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public ProjectFolder(string _mcmFilePath)
        {
            string mcmContent = DiskIO.ReadTextFile(_mcmFilePath);
            string[] tempArr = mcmContent.Split(';');
            this.title = tempArr[0];
            this.location = tempArr[1];
            playlists = new AudioFolder(ContentLocation, AUDIO_FOLDER_NAME);
            playlists = AudioFolder.SerializeFromJSON(ContentLocation,AUDIO_FOLDER_NAME, "index.en.json");
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
            DiskIO.SaveAsJSONFile(toFile, path, "index.json");
            string mcmFileContent = string.Join(";",new string[2]{title,location});
            DiskIO.SaveAsTextFile(mcmFileContent, path, title + ".mcm");
        }

        internal int FindLastPlaylistID()
        {
            return this.playlists.library.Count + 1;
        }

        internal void AddPlaylist(MusicPlaylist _newPlaylist)
        {
            this.playlists.library.Add(_newPlaylist);
        }

        internal void ApplyChangesOnHardDrive()
        {
            // save current state of playlists
            this.playlists.SavePlaylistLibrary();
        }

        internal MusicPlaylist[] GetPlaylistsCollection()
        {
            MusicPlaylist[] retVal = new MusicPlaylist[this.playlists.library.Count];
            this.playlists.library.CopyTo(retVal);
            return retVal;
        }

        internal static bool IsValidProjectDirectory(string _pathTodirectory)
        {
            bool retVal = DiskIO.IsDirectoryExist(_pathTodirectory, "files") &&
                DiskIO.IsFileExist(_pathTodirectory, "index.json") &&
                DiskIO.IsDirectoryExist(_pathTodirectory + "\\" + "files", AUDIO_FOLDER_NAME) &&
                DiskIO.IsDirectoryExist(_pathTodirectory + "\\" + "files", VIDEO_FOLDER_NAME) &&
                DiskIO.IsDirectoryExist(_pathTodirectory + "\\" + "files", PDF_FOLDER_NAME) &&
                DiskIO.IsDirectoryExist(_pathTodirectory + "\\" + "files", ANNOUNC_FOLDER_NAME);
            return retVal;

        }

        internal void SavePlaylistsNonEnglishData(Dictionary<string, MusicPlaylist> _dictionary)
        {
            this.playlists.SavePlaylistNonEnglishLibrary(_dictionary);
        }

        internal MusicPlaylist FindPlaylistWithID(int _id)
        {
            MusicPlaylist retval = null;
            foreach(MusicPlaylist x in this.playlists.library)
            {
                if (x.id == _id)
                { retval = x;
                    break;
                }
            }
            return retval;
        }

        internal string GetTitle()
        {
            return string.Copy(this.title);
        }
    }
}
