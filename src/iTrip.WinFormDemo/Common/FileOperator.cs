using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTrip.WinFormDemo.Dao;

namespace iTrip.WinFormDemo.Common
{
    public class FileOperator
    {
        public FileOperator(string filepath)
        {
            _filePath = filepath;
        }

        private string _filePath;


        public List<string> ReadAll()
        {
            CheckFile();
            List<string> ts = new List<string>();
            FileInfo fi = new FileInfo(_filePath);
            using (StreamReader sr = fi.OpenText())
            {
                string line = string.Empty;
                while (!string.IsNullOrEmpty(line = sr.ReadLine()))
                {
                    ts.Add(line);
                }
            }
            return ts;
        }
        private void CheckFile()
        {
            if (!File.Exists(_filePath))
            {
                FileInfo fi = new FileInfo(_filePath);
                if (!fi.Exists)
                {
                    if (!Directory.Exists(fi.DirectoryName))
                        Directory.CreateDirectory(fi.DirectoryName);
                    fi.Create().Close();
                }
            }
        }
        public void SaveOne(SuperDao dao)
        {
            CheckFile();
            using (StreamWriter sw = new StreamWriter(_filePath, true, Encoding.UTF8))
            {
                sw.WriteLine(dao.ToFileLine());
                sw.Flush();
                sw.Close();
            }
        }
    }
}
