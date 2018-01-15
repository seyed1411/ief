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
            int retval = 0;
            for (int i = 1; i < int.MaxValue; i++)
                if (!this.playlists.HasPlaylistWithID(i))
                { retval = i; break; }
            return retval;
        }

        internal void AddPlaylist(MusicPlaylist _newPlaylist)
        {
            this.playlists.library.Add(_newPlaylist);
        }

        internal void ApplyChangesOnHardDrive()
        {
            
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
            int retval = 0;
            for (int i = 1; i < int.MaxValue; i++)
                if (!this.movies.HasMovieWithID(i))
                { retval = i; break; } return retval;
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
            int retval = 0;
            for (int i = 1; i < int.MaxValue; i++)
                if (!this.announces.HasMovieWithID(i))
                { retval = i; break; } return retval;
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
            int retval = 0;
            for (int i = 1; i < int.MaxValue; i++)
                if (!this.articles.HasArticleWithID(i))
                { retval = i; break; } return retval;
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

        internal FileCopier[] ExportTo(string _selectedExportPath, string[] _languages)
        {
            List<FileCopier> allFilesToCopy = new List<FileCopier>();
            DiskIO.CreateDirectory(_selectedExportPath + "\\output");
            DiskIO.CreateDirectory(_selectedExportPath + "\\output"+"\\files");
            string contentLoc = _selectedExportPath + "\\output"+"\\files";
            allFilesToCopy.AddRange(this.playlists.ExportFilesTo(contentLoc, _languages));
            allFilesToCopy.AddRange(this.movies.ExportFilesTo(contentLoc, _languages));
            allFilesToCopy.AddRange(this.announces.ExportFilesTo(contentLoc, _languages));
            allFilesToCopy.AddRange(this.articles.ExportFilesTo(contentLoc, _languages));
            this.questions.ExportFilesTo(contentLoc);


            return allFilesToCopy.ToArray();
        }

        internal void SavePlaylistData()
        {
            // save current state of playlists
            this.playlists.SavePlaylistLibrary();
        }

        internal void SaveMoviesData()
        {
            // save current state of movies
            this.movies.SaveMoviesLibrary();

        }

        internal void SaveAnnouncData()
        {
            // save current state of announces
            this.announces.SaveMoviesLibrary();
        }

        internal void SaveArticleData()
        {
            // save current state of articles and pdfs
            this.articles.SaveArticleLibrary();
        }

        internal void SaveSurveyData()
        {
            // save current state of surveys
            this.questions.SaveSurveysLibrary();
        }

        internal long GetAllFilesVolume(out int _numberOfFiles)
        {
            long retVal=0;
            int numFiles = 0;
            _numberOfFiles = 0;
            retVal += playlists.GetFilesVolume(out numFiles);
            _numberOfFiles += numFiles;
            retVal += movies.GetFilesVolume(out numFiles);
            _numberOfFiles += numFiles;
            retVal += announces.GetFilesVolume(out numFiles);
            _numberOfFiles += numFiles;
            retVal += articles.GetFilesVolume(out numFiles);
            _numberOfFiles += numFiles;

            return retVal;
        }

        internal Dictionary<string, MusicPlaylist> ReadPlaylistNonEnglishData(int _id)
        {
            return this.playlists.ReadNonEnglishDataLibrary(_id);
        }

        internal Dictionary<string, MovieFile> ReadMovieNonEnglishData(int _id)
        {
            return this.movies.ReadNonEnglishDataLibrary(_id);
        }

        internal Dictionary<string, MovieFile> ReadAnnouncNonEnglishData(int _id)
        {
            return this.announces.ReadNonEnglishDataLibrary(_id);
        }

        internal Dictionary<string, ArticleFile> ReadArticleNonEnglishData(int _id)
        {
            return this.articles.ReadNonEnglishDataLibrary(_id);
        }

        internal bool IsEmpty()
        {
            if (this.playlists.library.Count == 0 &&
                this.movies.library.Count == 0 &&
                this.announces.library.Count == 0 &&
                this.articles.library.Count == 0 &&
                this.questions.surveys.Count == 0)
                return true;
            return false;
        }

        internal void RemovePlaylistWithID(int _id)
        {
            this.playlists.RemovePlaylistWithID(_id);
            this.playlists.RemovePlaylistNonEnglishData(_id);
        }

        internal void RemoveMovietWithID(int _id)
        {
            this.movies.RemoveMovieWithID(_id);
            this.movies.RemoveMovieNonEnglishData(_id);
        }

        internal void RemoveAnnouncWithID(int _id)
        {
            this.announces.RemoveMovieWithID(_id);
            this.announces.RemoveMovieNonEnglishData(_id);
        }

        internal void RemoveArticleWithID(int _id)
        {
            this.articles.RemoveArticleWithID(_id);
            this.articles.RemoveArticleNonEnglishData(_id);
        }

        internal void RemoveSurveyWithIndex(int _index)
        {
            this.questions.surveys.RemoveAt(_index);
        }
    }
}
