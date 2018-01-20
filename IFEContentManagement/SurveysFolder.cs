using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IFEContentManagement
{
    public class SurveyFolder
    {
        public List<Dictionary<string,QuestionCollection>> surveys;
        string title;
        string location;

        public SurveyFolder()
        {
            surveys = new List<Dictionary<string, QuestionCollection>>();
        }
        public SurveyFolder(string _location, string _title)
        {
            surveys = new List<Dictionary<string, QuestionCollection>>();
            title = _title;
            location = _location;
        }

        private string ContentLocation
        {
            get { return location + "\\" + title; }
        }

        internal static SurveyFolder SerializeFromJSON(string _surLocation, string _surFolderName, string _fileName)
        {
            SurveyFolder retVal = new SurveyFolder(_surLocation, _surFolderName);
            if (DiskIO.IsFileExist(_surLocation + "\\" + _surFolderName, _fileName))
                retVal = DiskIO.DeserializeSurveyFolderFromFile(_surLocation + "\\" + _surFolderName, _fileName);
            retVal.SetLocationTitle(_surLocation, _surFolderName);
            return retVal;
        }

        private void SetLocationTitle(string _surLocation, string _surFolderName)
        {
            title = _surFolderName;
            location = _surLocation;
        }

        internal void CreateNewSurveyDirectory()
        {
            DiskIO.CreateDirectory(location, title);
            //DiskIO.DeleteFile(ContentLocation, "index.en.json");
        }

        internal void SaveSurveysLibrary()
        {
            DiskIO.SaveAsJSONFile(this, this.ContentLocation, "index.en.json");
        }

        internal void ExportFilesTo(string contentLoc)
        {
            string newWorkArea = contentLoc + "\\" + title;
            DiskIO.CreateDirectory(newWorkArea);
            DiskIO.SaveAsJSONFile(this, newWorkArea, "index.en.json");
        }
    }
}
