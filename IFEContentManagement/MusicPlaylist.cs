using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IFEContentManagement
{
    public enum AgeList
    {
        UNDER13,
        UNDER17,
        Uper18
    }
    public enum Languages
    {
        English = 1,
        Farsi,
        Arabic,
        Spanish,
        French,
        Russian,
        Chinese,
        Hindi,
        German
    }
    public class MusicPlaylist
    {
        List<MusicFile> tracks;

        //uniq id of each playlist that enable us to integrate different langs of one playlist
        public int id;
        //public string language;
        public string playlist;
        public int num_tracks;

        //There are main information of each playlist in English language
        public string cover;
        public int year;
        public string ageCategory;
        public string[] genre;

        //There are additional information of each playlist (could be in different langs)        
        public string title;
        public string[] artist;
        public string description;

        public MusicPlaylist(int _id)
        {
            tracks = new System.Collections.Generic.List<MusicFile>();
            id = _id;
        }

        public void SetPlaylist(string _playlistFolderPath)
        {
            this.playlist = _playlistFolderPath;
            this.tracks = DiskIO.GetMusicFiles(_playlistFolderPath);
        }

        internal void CopyTo(MusicPlaylist _p)
        {
            _p.SetPlaylist(this.playlist);
            _p.num_tracks = this.num_tracks;
            _p.cover = this.cover;
            _p.ageCategory = this.ageCategory;
            _p.genre = this.genre;
            _p.title = this.title;
            _p.artist = this.artist;
            _p.description = this.description;
            return;
        }

        internal void SaveMusicFilesInfos(string _path,string _fileName)
        {
            Dictionary<string, List<MusicFile>> toJsonItem = new Dictionary<string, List<MusicFile>>();
            toJsonItem.Add("tracks",tracks);
            DiskIO.SaveAsJSONFile(toJsonItem, _path, _fileName);
        }
        internal static List<MusicFile> DeserializeFilesFromJSON(string _fullPath, string _fileName)
        {
            Dictionary<string, List<MusicFile>> retVal = new Dictionary<string, List<MusicFile>>();
            if (DiskIO.IsFileExist(_fullPath, _fileName))
                retVal = DiskIO.DeserializeTracksFromFile(_fullPath, _fileName);
            return retVal["tracks"];
        }

        internal void LoadMusicFileInfos(string _fullPath, string _fileName)
        {
            this.tracks = MusicPlaylist.DeserializeFilesFromJSON(_fullPath, _fileName);
        }

        public List<MusicFile> GetMusicFilesInfo()
        {
            return this.tracks;
        }
    }
}