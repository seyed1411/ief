using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace IFEContentManagement
{
    public static class DiskIO
    {
        internal static void CreateDirectory(string _path, string _name)
        {            
            Directory.CreateDirectory(_path + "\\" + _name);
        }
        internal static void CreateDirectory(string _fullPath)
        {
            Directory.CreateDirectory(_fullPath);
        }
        internal static bool IsValidPath(string _path)
        {
            return Directory.Exists(_path);
        }

        internal static void SaveAsJSONFile(object obj, string _path, string _name)
        {
            string str = JsonConvert.SerializeObject(obj);
            File.WriteAllText(_path + "\\" + _name, str);
        }
        internal static string GetDirectoryName(string _filePath)
        {
            return Path.GetDirectoryName(_filePath);
        }
        internal static bool IsDirectoryExist(string _path, string _name)
        {
            return Directory.Exists(_path + "\\" + _name);
        }

        internal static bool IsFileExist(string _pathTodirectory, string _name)
        {
            return File.Exists(_pathTodirectory + "\\" + _name);
        }

        internal static void SaveAsTextFile(string _content, string _path, string _name)
        {
            File.WriteAllText(_path + "\\" + _name, _content);
        }
        internal static string ReadTextFile(string _filePath)
        {
            return File.ReadAllText(_filePath);
        }
        internal static void DeserializeObjectFromJSONFile(ref Object _obj, string _path, string _name)
        {
            
        }

        internal static AudioFolder DeserializeAudioFolderFromFile(string _path, string _name)
        {
            string content = File.ReadAllText(_path + "\\" + _name);
            AudioFolder obj = JsonConvert.DeserializeObject<AudioFolder>(content);
            return obj;
        }

        internal static void DeleteFile(string _path, string _name)
        {
            File.Delete(_path + "\\" + _name);
        }

        internal static bool DirectoryHasMusicFile(string _dirPath)
        {
            string[] fileEntries = Directory.GetFiles(_dirPath,@"*.mp3");
            if (fileEntries.Length == 0)
                return false;
            return true;

        }

        internal static int GetFilesNumber(string _dirPath, string _searchString)
        {
            string[] fileEntries = Directory.GetFiles(_dirPath, _searchString);
            return fileEntries.Length;
        }

        internal static bool IsImageFile(string _filePath)
        {
            FileInfo info = new FileInfo(_filePath);
            string extension = info.Extension.ToLower();
            if (extension == ".jpg" || extension == ".png" ||
                extension == ".bmp" || extension == ".gif" ||
                extension == ".tif")
                return true;
            return false;
        }

        internal static bool IsVideoFile(string _filePath)
        {
            FileInfo info = new FileInfo(_filePath);
            string extension = info.Extension.ToLower();
            if (extension == ".mp4" || extension == ".wmv" ||
                extension == ".mkv" || extension == ".avi" ||
                extension == ".mov")
                return true;
            return false;
        }

        internal static VideoFolder DeserializeVideoFolderFromFile(string _path, string _name)
        {
            string content = File.ReadAllText(_path + "\\" + _name);
            VideoFolder obj = JsonConvert.DeserializeObject<VideoFolder>(content);
            return obj;
        }
    }
}
