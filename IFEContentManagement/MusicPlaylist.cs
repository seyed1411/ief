using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace IFEContentManagement
{
    public enum AgeList
    {
        UNDER13,
        UNDER17,
        Uper18
    }
    public enum GenereList
    {
        Pop,
        Rock
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
        List<MusicFile> musicFiles;

        //uniq id of each playlist that enable us to integrate different langs of one playlist
        public int id;
        //public string lannguage;
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
            id = _id;
        }

        internal void CopyTo(MusicPlaylist _p)
        {
            _p.playlist = this.playlist;
            _p.num_tracks = this.num_tracks;
            _p.cover = this.cover;
            _p.ageCategory = this.ageCategory;
            _p.genre = this.genre;
            _p.title = this.title;
            _p.artist = this.artist;
            _p.description = this.description;
            return;
        }
    }
}