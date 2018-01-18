using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IFEContentManagement
{
    public class MovieFile
    {
        //uniq id of each playlist that enable us to integrate different langs of one playlist
        public int id;
        public VideoLanguages language;
        public VideoPathQual video;
        public VideoPathQual trailer;
        public int length;

        //There are main information of each playlist in English language
        public string cover;
        public string director;
        public string ageCategory;
        public string[] genre;

        //There are additional information of each playlist (could be in different langs)        
        public string title;
        public string[] artist;
        public string description;

        public MovieFile()
        {
            language = new VideoLanguages();
            video = new VideoPathQual();
            trailer = new VideoPathQual();
        }
        public MovieFile(int _id):this()
        {            
            this.id = _id;
        }

        internal void CopyTo(MovieFile _m)
        {
            _m.id = this.id;
            _m.language.audio = this.language.audio;
            _m.video.path = this.video.path;
            _m.video.quality = this.video.quality;
            _m.trailer.path = this.trailer.path;
            _m.trailer.quality = this.trailer.quality;
            _m.cover = this.cover;
            _m.director = this.director;
            _m.ageCategory = this.ageCategory;
            _m.genre = this.genre;
            _m.title = this.title;
            _m.artist = this.artist;
            _m.description = this.description;
            return;
        }
    }
}
