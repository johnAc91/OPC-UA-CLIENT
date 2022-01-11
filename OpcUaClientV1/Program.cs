using Opc.Ua;
using Opc.Ua.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcUaClientV1
{
    internal class Program
    {
        static void ShowException(string title, string body)
        {
            Console.WriteLine();
            Console.WriteLine(title);
            Console.WriteLine(body);
            Console.WriteLine();
            Console.WriteLine("Press any key to exit ");
            Console.ReadKey();
            Environment.Exit(0);
        }
        static void Main(string[] args)
        {
            try
            {
                ConfigFile configFile = new ConfigFile();
            }
            catch(Exception exc)
            {
                ShowException("Error reading XML Config file", exc.Message);
            }
            Console.ReadKey();
        }
    }
}
