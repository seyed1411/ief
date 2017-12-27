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

        internal void SaveMoviesLibrary()
        {
            DiskIO.SaveAsJSONFile(this, this.ContentLocation, "index.en.json");
        }
        internal void SaveMoviesLibrary(string _fileName)
        {
            DiskIO.SaveAsJSONFile(this, this.ContentLocation, _fileName);
        }

        internal static VideoFolder SerializeFromJSON(string _videoLocation, string _videoFolderName, string _fileName)
        {
            VideoFolder retVal = new VideoFolder(_videoLocation, _videoFolderName);
            if (DiskIO.IsFileExist(_videoLocation + "\\" + _videoFolderName, _fileName))
                retVal = DiskIO.DeserializeVideoFolderFromFile(_videoLocation + "\\" + _videoFolderName, _fileName);
            retVal.SetLocationTitle(_videoLocation, _videoFolderName);
            return retVal;
        }

        private void SetLocationTitle(string _videoLocation, string _videoFolderName)
        {
            this.title = _videoFolderName;
            this.location = _videoLocation;
        }

        internal void SaveMoviesNonEnglishLibrary(Dictionary<string, MovieFile> _dictionary)
        {
            VideoFolder temp = new VideoFolder(this.location, this.title);
            foreach (var item in Enum.GetValues(typeof(Languages)))
            {
                if (_dictionary.ContainsKey(item.ToString()))
                {
                    string header = item.ToString().Substring(0, 2);
                    string fileName = "index." + header + ".json";
                    if (DiskIO.IsFileExist(ContentLocation, fileName))
                    {
                        temp = DiskIO.DeserializeVideoFolderFromFile(ContentLocation, fileName);
                        temp.SetLocationTitle(this.location, this.title);
                        if (temp.HasMovieWithID(_dictionary[item.ToString()].id))
                        {
                            temp.RemoveMovieWithID(_dictionary[item.ToString()].id);
                        }
                        temp.library.Add(_dictionary[item.ToString()]);
                        temp.SaveMoviesLibrary(fileName);
                    }
                    else
                    {
                        temp.library = new List<MovieFile>();
                        temp.library.Add(_dictionary[item.ToString()]);
                        temp.SaveMoviesLibrary(fileName);
                    }
                }
            }
        }

        private void RemoveMovieWithID(int _id)
        {
            foreach (MovieFile p in library)
                if (p.id == _id)
                {
                    library.Remove(p);
                    return;
                }
            return;
        }

        public bool HasMovieWithID(int _id)
        {
            foreach (MovieFile p in library)
            {
                if (p.id == _id) return true;
            }
            return false;
        }
    }

}
