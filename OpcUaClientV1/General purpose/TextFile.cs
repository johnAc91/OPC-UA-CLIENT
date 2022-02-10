using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcUaClientV1
{
    internal class TextFile
    {
        private string _path;
        public string path
        {
            get
            {
                return _path;
            }
        }
        public void WriteLine(string data)
        {
            StreamWriter logFile = new System.IO.StreamWriter(path, true);
            logFile.WriteLine(data);
            logFile.Close();
            Console.WriteLine(data);
        }
        public void Write(string data)
        {
            StreamWriter logFile = new System.IO.StreamWriter(path, true);
            logFile.Write(data);
            logFile.Close();
            Console.Write(data);
        }
        public void WriteLineOnlyFile(string data)
        {
            StreamWriter logFile = new System.IO.StreamWriter(path, true);
            logFile.WriteLine(data);
            logFile.Close();
        }
        public void WriteOnlyFile(string data)
        {
            StreamWriter logFile = new System.IO.StreamWriter(path, true);
            logFile.Write(data);
            logFile.Close();
        }
        public TextFile(string fileName)
        {
            Console.WriteLine("Preparing " + fileName + " file ...");
            Console.WriteLine("");
            Console.WriteLine("    File name:                       " + fileName);
            Console.WriteLine();
            //path = Environment.CurrentDirectory + "\\" + fileName;
            _path = fileName;
            Console.WriteLine(fileName + " ready!");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
