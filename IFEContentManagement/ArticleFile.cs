using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IFEContentManagement
{
    public class ArticleFile
    {
        //uniq id of each playlist that enable us to integrate different langs of one playlist
        public int id;
        public string language;
        public string file;
        //public int num_tracks;

        //There are main information of each playlist in English language
        public string cover;
        public int year;
        public string ageCategory;
        public string[] genre;

        //There are additional information of each playlist (could be in different langs)        
        public string title;
        public string[] writer;
        public string description;

        public ArticleFile(int _id)
        {
            id = _id;
        }

        internal void CopyTo(ArticleFile _p)
        {
            _p.id = this.id;
            _p.file = this.file;
            _p.cover = this.cover;
            _p.language = this.language;
            _p.ageCategory = this.ageCategory;
            _p.genre = this.genre;
            _p.title = this.title;
            _p.writer = this.writer;
            _p.description = this.description;
            return;
        }
    }
}
