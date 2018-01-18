using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IFEContentManagement
{
    class PDFFolder
    {
        public List<ArticleFile> library;

        string title;
        string location;

        public PDFFolder() { }

        public PDFFolder(string _location, string _title)
        {
            library = new List<ArticleFile>();
            title = _title;
            location = _location;
        }

        private string ContentLocation
        {
            get { return location + "\\" + title; }
        }

        public void CreateNewPDFDirectory()
        {
            DiskIO.CreateDirectory(location, title);
            DiskIO.DeleteFile(ContentLocation, "index.en.json");
        }

        internal void SaveArticleLibrary()
        {
            DiskIO.SaveAsJSONFile(this, this.ContentLocation, "index.en.json");
        }
        internal void SaveArticleLibrary(string _fileName)
        {
            DiskIO.SaveAsJSONFile(this, this.ContentLocation, _fileName);
        }
        private void SaveArticleLibraryAtLocation(string _fullPath, string _fileName)
        {
            DiskIO.SaveAsJSONFile(this, _fullPath, _fileName);
        }

        internal static PDFFolder SerializeFromJSON(string _pdfLocation, string _pdfFolderName, string _fileName)
        {
            PDFFolder retVal = new PDFFolder(_pdfLocation, _pdfFolderName);
            if (DiskIO.IsFileExist(_pdfLocation + "\\" + _pdfFolderName, _fileName))
                retVal = DiskIO.DeserializePDFFolderFromFile(_pdfLocation + "\\" + _pdfFolderName, _fileName);
            retVal.SetLocationTitle(_pdfLocation, _pdfFolderName);
            return retVal;
        }

        private void SetLocationTitle(string _pdfLocation, string _pdfFolderName)
        {
            this.title = _pdfFolderName;
            this.location = _pdfLocation;
        }

        internal void SaveArticlesNonEnglishData(Dictionary<string, ArticleFile> _dictionary)
        {
            PDFFolder temp = new PDFFolder(this.location, this.title);
            foreach (var item in Enum.GetValues(typeof(Languages)))
            {
                if (_dictionary.ContainsKey(item.ToString()))
                {
                    string header = item.ToString().Substring(0, 2);
                    string fileName = "index." + header + ".json";
                    if (DiskIO.IsFileExist(ContentLocation, fileName))
                    {
                        temp = DiskIO.DeserializePDFFolderFromFile(ContentLocation, fileName);
                        temp.SetLocationTitle(this.location, this.title);
                        if (temp.HasArticleWithID(_dictionary[item.ToString()].id))
                        {
                            temp.RemoveArticleWithID(_dictionary[item.ToString()].id);
                        }
                        temp.library.Add(_dictionary[item.ToString()]);
                        temp.SaveArticleLibrary(fileName);
                    }
                    else
                    {
                        temp.library = new List<ArticleFile>();
                        temp.library.Add(_dictionary[item.ToString()]);
                        temp.SaveArticleLibrary(fileName);
                    }
                }
            }
        }

        public void RemoveArticleWithID(int _id)
        {
            foreach (ArticleFile p in library)
                if (p.id == _id)
                {
                    library.Remove(p);
                    return;
                }
            return;
        }

        public bool HasArticleWithID(int _id)
        {
            foreach (ArticleFile p in library)
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
            DiskIO.DeleteAllFiles(newWorkArea);
            foreach (ArticleFile p in this.library)
            {
                // create each pdf folder
                string pdfNewLocation = newWorkArea + "\\" + p.id;
                DiskIO.CreateDirectory(pdfNewLocation);
                // add pdf files to copy                
                allFilesToCopy.Add(new FileCopier(p.file, pdfNewLocation + "\\" + DiskIO.GetFileName(p.file)));
                // change the file path to the new path for further library json saving
                p.file = DiskIO.GetFileName(p.file);

                if (!string.IsNullOrEmpty(p.cover))
                {
                    // add video cover to copy
                    allFilesToCopy.Add(new FileCopier(p.cover, pdfNewLocation + "\\cover.jpg"));
                    // change the cover path to the new path for further library json saving
                    p.cover = "\\cover.jpg";
                }
            }
            // save changed paths and music files into exported location
            this.SaveArticleLibraryAtLocation(newWorkArea, "index.en.json");

            // copy all requested non-English langs
            foreach (string lang in _languages)
            {
                string abbriv = "index." + lang.Substring(0, 2).ToLower() + ".json";
                if (DiskIO.IsFileExist(ContentLocation, abbriv))
                {
                    PDFFolder temp = DiskIO.DeserializePDFFolderFromFile(ContentLocation, abbriv);
                    foreach (ArticleFile p in temp.library)
                    {
                        p.file = DiskIO.GetFileName(p.file);
                        if (!string.IsNullOrEmpty(p.cover))
                            p.cover = "\\cover.jpg";

                    }
                    DiskIO.SaveAsJSONFile(temp, newWorkArea, abbriv);
                }
            }
            return allFilesToCopy.ToArray();
        }

        internal long GetFilesVolume(out int _numOfFiles)
        {
            long retval = 0;
            int numFiles=0;
            foreach (ArticleFile a in this.library)
            {
                retval += DiskIO.GetFileSize(a.file);
                numFiles++;
                if (!string.IsNullOrEmpty(a.cover))
                {
                    retval += DiskIO.GetFileSize(a.cover);
                    numFiles++;
                }
            }
            _numOfFiles = numFiles;
            return retval;

        }

        internal Dictionary<string, ArticleFile> ReadNonEnglishDataLibrary(int _id)
        {
            Dictionary<string, ArticleFile> retVal = new Dictionary<string, ArticleFile>();
            PDFFolder temp = new PDFFolder(this.location, this.title);
            foreach (var item in Enum.GetValues(typeof(Languages)))
            {
                string header = item.ToString().Substring(0, 2);
                string fileName = "index." + header + ".json";
                if (DiskIO.IsFileExist(ContentLocation, fileName))
                {
                    temp = DiskIO.DeserializePDFFolderFromFile(ContentLocation, fileName);
                    temp.SetLocationTitle(this.location, this.title);
                    if (temp.HasArticleWithID(_id))
                    {
                        retVal.Add(item.ToString(), temp.FindArticleWithID(_id));
                    }
                }
            }
            return retVal;
        }

        private ArticleFile FindArticleWithID(int _id)
        {
            ArticleFile retval = null;
            foreach (ArticleFile x in this.library)
            {
                if (x.id == _id)
                {
                    retval = x;
                    break;
                }
            }
            return retval;
        }

        internal void RemoveArticleNonEnglishData(int _id)
        {
            PDFFolder temp = new PDFFolder(this.location, this.title);
            foreach (var item in Enum.GetValues(typeof(Languages)))
            {
                string header = item.ToString().Substring(0, 2);
                string fileName = "index." + header + ".json";
                if (DiskIO.IsFileExist(ContentLocation, fileName))
                {
                    temp = DiskIO.DeserializePDFFolderFromFile(ContentLocation, fileName);
                    temp.SetLocationTitle(this.location, this.title);
                    if (temp.HasArticleWithID(_id))
                    {
                        temp.RemoveArticleWithID(_id);
                    }
                    DiskIO.SaveAsJSONFile(temp, this.ContentLocation, fileName);
                }
            }
        }
    }
}