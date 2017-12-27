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

        public AudioFolder() {  }
        
        public AudioFolder(string _location, string _title)
        {
            library = new List<MusicPlaylist>();
            title = _title;
            location = _location;
            if (DiskIO.IsFileExist(ContentLocation, "index.en.json"))
            {
                // go back
                //DiskIO.DeserializeObjectFromJSONFile(this, ContentLocation, "index.en.json");
            }
        }

        private string ContentLocation
        {
            get { return location + "\\" + title; }
        }

        public void CreateNewAudioDirectory()
        {           
            DiskIO.CreateDirectory(location,title);
            DiskIO.DeleteFile(ContentLocation, "index.en.json");
        }

        internal void SavePlaylistLibrary()
        {
            DiskIO.SaveAsJSONFile(this, this.ContentLocation , "index.en.json");
        }
        internal void SavePlaylistLibrary(string _fileName)
        {
            DiskIO.SaveAsJSONFile(this, this.ContentLocation, _fileName);
        }
        
        internal static AudioFolder SerializeFromJSON(string _audioLocation,string _audioFolderName, string _fileName)
        {
            AudioFolder retVal = new AudioFolder(_audioLocation, _audioFolderName);
            if (DiskIO.IsFileExist(_audioLocation + "\\" + _audioFolderName, _fileName))
                retVal = DiskIO.DeserializeAudioFolderFromFile(_audioLocation + "\\" + _audioFolderName, _fileName);
            retVal.SetLocationTitle(_audioLocation, _audioFolderName);
            return retVal;
        }

        private void SetLocationTitle(string _audioLocation, string _audioFolderName)
        {
            this.title = _audioFolderName;
            this.location = _audioLocation;
        }

        internal void SavePlaylistNonEnglishLibrary(Dictionary<string, MusicPlaylist> _dictionary)
        {
            AudioFolder temp = new AudioFolder(this.location, this.title);
            foreach (var item in Enum.GetValues(typeof(Languages)))
            {
                if (_dictionary.ContainsKey(item.ToString()))
                {
                    string header = item.ToString().Substring(0, 2);
                    string fileName = "index." + header + ".json";
                    if (DiskIO.IsFileExist(ContentLocation, fileName))
                    {
                        temp = DiskIO.DeserializeAudioFolderFromFile(ContentLocation, fileName);
                        temp.SetLocationTitle(this.location, this.title);
                        if (temp.HasPlaylistWithID(_dictionary[item.ToString()].id))
                        {
                            temp.RemovePlaylistWithID(_dictionary[item.ToString()].id);
                        }
                        temp.library.Add(_dictionary[item.ToString()]);
                        temp.SavePlaylistLibrary(fileName);
                    }
                    else
                    {
                        temp.library = new List<MusicPlaylist>();
                        temp.library.Add(_dictionary[item.ToString()]);
                        temp.SavePlaylistLibrary(fileName);
                    }
                }
            }
        }

        private void RemovePlaylistWithID(int _id)
        {
            foreach (MusicPlaylist p in library)
                if (p.id == _id)
                {
                    library.Remove(p);
                    return;
                }
            return;
        }

        public bool HasPlaylistWithID(int _id)
        {
            foreach(MusicPlaylist p in library)
            {
                if (p.id == _id) return true;
            }
            return false;
        }
    }
}
