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
        public const string SURVEY_FOLDER_NAME = "surveys";

        // variables and members
        AudioFolder playlists;
        VideoFolder movies;
        PDFFolder articles;
        VideoFolder announces;
        SurveyFolder questions;
        string title;
        string location;

        public ProjectFolder(string _title, string _location)
        {
            this.title = _title;
            this.location = _location;
            playlists = new AudioFolder(ContentLocation, AUDIO_FOLDER_NAME);
            movies = new VideoFolder(ContentLocation, VIDEO_FOLDER_NAME);
            articles = new PDFFolder(ContentLocation, PDF_FOLDER_NAME);
            announces = new VideoFolder(ContentLocation, ANNOUNC_FOLDER_NAME);
            questions = new SurveyFolder(ContentLocation,SURVEY_FOLDER_NAME);
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
            movies = VideoFolder.SerializeFromJSON(ContentLocation, VIDEO_FOLDER_NAME, "index.en.json");
            announces = new VideoFolder(ContentLocation, ANNOUNC_FOLDER_NAME);
            announces = VideoFolder.SerializeFromJSON(ContentLocation, ANNOUNC_FOLDER_NAME, "index.en.json");
            articles = new PDFFolder(ContentLocation, PDF_FOLDER_NAME);
            articles = PDFFolder.SerializeFromJSON(ContentLocation, PDF_FOLDER_NAME, "index.en.json");
            questions = new SurveyFolder(ContentLocation, SURVEY_FOLDER_NAME);
            questions = SurveyFolder.SerializeFromJSON(ContentLocation, SURVEY_FOLDER_NAME, "index.en.json");
            
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
            questions.CreateNewSurveyDirectory();

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

            // save current state of movies
            this.movies.SaveMoviesLibrary();

            // save current state of announces
            this.announces.SaveMoviesLibrary();

            // save current state of articles and pdfs
            this.articles.SaveArticleLibrary();

            // save current state of surveys
            this.questions.SaveSurveysLibrary();
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

        internal int FindLastMovieID()
        {
            return this.movies.library.Count + 1;
        }

        internal void AddMovie(MovieFile _newMovie)
        {
            this.movies.library.Add(_newMovie);
        }

        internal void SaveMoviesNonEnglishData(Dictionary<string, MovieFile> _dictionary)
        {
            this.movies.SaveMoviesNonEnglishLibrary(_dictionary);
        }

        internal MovieFile[] GetMoviesCollection()
        {
            MovieFile[] retVal = new  MovieFile[this.movies.library.Count];
            this.movies.library.CopyTo(retVal);
            return retVal;
        }

        internal MovieFile FindMovieWithID(int _id)
        {
            MovieFile retval = null;
            foreach (MovieFile x in this.movies.library)
            {
                if (x.id == _id)
                {
                    retval = x;
                    break;
                }
            }
            return retval;
        }

        internal int FindLastAnnouncID()
        {
            return this.announces.library.Count + 1;
        }

        internal void AddAnnouncement(MovieFile _newMovie)
        {
            this.announces.library.Add(_newMovie);
        }

        internal void SaveAnnouncesNonEnglishData(Dictionary<string, MovieFile> _dictionary)
        {
            this.announces.SaveMoviesNonEnglishLibrary(_dictionary);
        }

        internal MovieFile[] GetAnnouncesCollection()
        {
            MovieFile[] retVal = new MovieFile[this.announces.library.Count];
            this.announces.library.CopyTo(retVal);
            return retVal;
        }

        internal MovieFile FindAnnouncWithID(int _id)
        {
            MovieFile retval = null;
            foreach (MovieFile x in this.announces.library)
            {
                if (x.id == _id)
                {
                    retval = x;
                    break;
                }
            }
            return retval;
        }

        // Article Methodes

        internal int FindLastArticleID()
        {
            return this.articles.library.Count + 1;
        }

        internal void AddArticle(ArticleFile _newArticle)
        {
            this.articles.library.Add(_newArticle);
        }

        internal void SaveArticlesNonEnglishData(Dictionary<string, ArticleFile> _dictionary)
        {
            this.articles.SaveArticlesNonEnglishData(_dictionary);
        }

        internal ArticleFile[] GetArticlesCollection()
        {
            ArticleFile[] retVal = new ArticleFile[this.articles.library.Count];
            this.articles.library.CopyTo(retVal);
            return retVal;
        }

        internal ArticleFile FindArticleWithID(int _id)
        {
            ArticleFile retval = null;
            foreach (ArticleFile x in this.articles.library)
            {
                if (x.id == _id)
                {
                    retval = x;
                    break;
                }
            }
            return retval;
        }

        internal void AddSurvey(Dictionary<string, QuestionCollection> _dictionary)
        {
            this.questions.surveys.Add(_dictionary);
        }

        internal Dictionary<string, QuestionCollection>[] GetSurveysCollection()
        {
            return this.questions.surveys.ToArray();
        }

        internal Dictionary<string, QuestionCollection> GetSurvey(int index)
        {
            return this.questions.surveys[index];
        }
    }
}
