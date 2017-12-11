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
        English,
        Persian,
        French,
        Arabic
    }
    public class MusicPlaylist
    {
        List<MusicFile> musicFiles;
        string directoryPath;

        //uniq id of each playlist that enable us to integrate different langs of one playlist
        public string id;
        Languages lannguage;
        public string playlist;
        public int num_tracks;

        //There are main information of each playlist in English language
        public string cover;
        public int year;
        //public AgeList ageCategory;
        public string[] genre;

        //There are additional information of each playlist (could be in different langs)        
        public string title;
        public string[] artist;
        public string description;

        public MusicPlaylist()
        {
            id = "0";
        }


    }
}