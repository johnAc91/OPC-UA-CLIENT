using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcUaClient
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
            try
            {
                Console.WriteLine(data);
                StreamWriter logFile = new System.IO.StreamWriter(path, true);
                logFile.WriteLine(data);
                logFile.Close();
            }
            catch
            {
                Console.WriteLine("Unable to write stream data.");
            }
        }
        public void Write(string data)
        {
            try
            {
                Console.Write(data);
                StreamWriter logFile = new System.IO.StreamWriter(path, true);
                logFile.Write(data);
                logFile.Close();
            }
            catch
            {
                Console.WriteLine("Unable to write stream data.");
            }
        }
        public void WriteLineOnlyFile(string data)
        {
            try
            {
                StreamWriter logFile = new System.IO.StreamWriter(path, true);
                logFile.WriteLine(data);
                logFile.Close();
            }
            catch
            {
                Console.WriteLine("Unable to write stream data.");
            }
        }
        public void WriteOnlyFile(string data)
        {
            try
            {
                StreamWriter logFile = new System.IO.StreamWriter(path, true);
                logFile.Write(data);
                logFile.Close();
            }
            catch
            {
                Console.WriteLine("Unable to write stream data.");
            }
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
