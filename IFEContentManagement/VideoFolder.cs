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
        private void SaveMovieLibraryAtLocation(string _fullPath, string _fileName)
        {
            DiskIO.SaveAsJSONFile(this, _fullPath, _fileName);
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

        internal FileCopier[] ExportFilesTo(string contentLoc, string[] _languages)
        {
            string newWorkArea = contentLoc + "\\" + title;
            List<FileCopier> allFilesToCopy = new List<FileCopier>();

            // create root folder
            DiskIO.CreateDirectory(newWorkArea);
            foreach (MovieFile p in this.library)
            {
                // create each movie folder
                string movieNewLocation = newWorkArea + "\\" + p.id;
                DiskIO.CreateDirectory(movieNewLocation);
                // add video files to copy                
                allFilesToCopy.Add(new FileCopier(p.video.path, movieNewLocation + "\\" + DiskIO.GetFileTitle(p.video.path)));
                // change the file path to the new path for further library json saving
                p.video.path = p.id + "\\" + DiskIO.GetFileTitle(p.video.path);
                // add trailer if exist
                if (!string.IsNullOrEmpty(p.trailer.path))
                {
                    allFilesToCopy.Add(new FileCopier(p.trailer.path, movieNewLocation + "\\" + DiskIO.GetFileTitle(p.trailer.path)));
                    p.trailer.path = p.id + "\\" + DiskIO.GetFileTitle(p.trailer.path);
                }
                if (!string.IsNullOrEmpty(p.cover))
                {
                    // add video cover to copy
                    allFilesToCopy.Add(new FileCopier(p.cover, movieNewLocation + "\\cover.jpg"));
                    // change the cover path to the new path for further library json saving
                    p.cover = p.id + "\\cover.jpg";
                }
            }
            // save changed paths and music files into exported location
            this.SaveMovieLibraryAtLocation(newWorkArea, "index.en.json");

            // copy all requested non-English langs
            foreach (string lang in _languages)
            {
                string abbriv = "index." + lang.Substring(0, 2).ToLower() + ".json";
                if (DiskIO.IsFileExist(ContentLocation, abbriv))
                {
                    VideoFolder temp = DiskIO.DeserializeVideoFolderFromFile(ContentLocation, abbriv);
                    foreach (MovieFile p in temp.library)
                    {
                        p.video.path = p.id + "\\" + DiskIO.GetFileTitle(p.video.path);
                        if (!string.IsNullOrEmpty(p.trailer.path))
                            p.trailer.path = p.id + "\\" + DiskIO.GetFileTitle(p.trailer.path);
                        if (!string.IsNullOrEmpty(p.cover))
                            p.cover = p.id + "\\cover.jpg";

                    }
                    DiskIO.SaveAsJSONFile(temp, newWorkArea, abbriv);
                }
            }
            return allFilesToCopy.ToArray();
        }

        internal long GetFilesVolume(out int _numOfFiles)
        {
            long retval = 0;
            int numFiles = 0;
            foreach (MovieFile m in this.library)
            {
                retval += DiskIO.GetFileSize(m.video.path);
                numFiles++;
                if (!string.IsNullOrEmpty(m.trailer.path))
                { retval += DiskIO.GetFileSize(m.trailer.path); numFiles++; }
                if (!string.IsNullOrEmpty(m.cover))
                { retval += DiskIO.GetFileSize(m.cover); numFiles++; }
            }
            _numOfFiles = numFiles;
            return retval;
        }

        internal Dictionary<string, MovieFile> ReadNonEnglishDataLibrary(int _id)
        {
            Dictionary<string, MovieFile> retVal = new Dictionary<string, MovieFile>();
            VideoFolder temp = new VideoFolder(this.location, this.title);
            foreach (var item in Enum.GetValues(typeof(Languages)))
            {
                string header = item.ToString().Substring(0, 2);
                string fileName = "index." + header + ".json";
                if (DiskIO.IsFileExist(ContentLocation, fileName))
                {
                    temp = DiskIO.DeserializeVideoFolderFromFile(ContentLocation, fileName);
                    temp.SetLocationTitle(this.location, this.title);
                    if (temp.HasMovieWithID(_id))
                    {
                        retVal.Add(item.ToString(), temp.FindMovieWithID(_id));
                    }
                }
            }
            return retVal;
        }

        private MovieFile FindMovieWithID(int _id)
        {
            MovieFile retval = null;
            foreach (MovieFile x in this.library)
            {
                if (x.id == _id)
                {
                    retval = x;
                    break;
                }
            }
            return retval;
        }
    }
}
