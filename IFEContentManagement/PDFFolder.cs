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

        private void RemoveArticleWithID(int _id)
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
    }
}