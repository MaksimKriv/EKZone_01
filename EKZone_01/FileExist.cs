using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKZone_01
{
    public class FileExist
    {
        enum ststus { Ready, Deleted, Download};
        public int id { get; set; }
        public string fileName { get; set; }
        public string filePath { get; set; }
        public string linkDownload { get; set; }
        public string statusFile { get; set; }
        public string fileExtension { get; set; }

        public FileExist(int id, string fileName, string filePath, string linkDownload)
        {
            this.id = id;
            this.fileName = examinationFileName(fileName);
            this.filePath = filePath;
            this.linkDownload = linkDownload;
        }

        public FileInfo fileInf;

        public void DeleteFile()
        {
            if (fileInf != null && fileInf.Exists)
            {
                fileInf.Delete();
            }
        }

        public void FileMoveTo()
        {
            fileInf.MoveTo(filePath + fileName + '.' + fileExtension);
        }
        public void Download()
        {
            fileInf = new FileInfo(filePath + fileName + '.' + fileExtension);
        }

        string examinationFileName(string _obj)
        {
            string badChar = "#%&{}\\<>*?/$!`\":@+|=";
            foreach (var text in _obj)
            {
                foreach (var bad in badChar)
                {
                    if (text == bad)
                    {
                        return "Bad string";
                    }
                }
            }
            return _obj;
        }
    }
}
