using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcUaClientV1
{
    internal class LogFile
    {
        private string path;
        public string Path
        {
            get
            {
                return path;
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
        public LogFile(string fileName)
        {
            Console.WriteLine("Preparing log file ...");
            Console.WriteLine("");
            Console.WriteLine("    Log file name:                   " + fileName);
            Console.WriteLine();
            path = Environment.CurrentDirectory + "\\" + fileName;
            WriteLine("Log file ready!");
            WriteLine(null);
        }
    }
}
