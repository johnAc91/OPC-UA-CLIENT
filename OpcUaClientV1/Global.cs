using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcUaClientV1
{
    internal static class Global
    {
        public static DateTime initTimeStamp;
        public static TextFile logFile, csvFile;
        public static ServerParams serverParams;
        public static OpcuaApp opcuaApp;
        public static OpcuaEndpoint opcuaEndpoint;
        public static OpcuaSession opcuaSession;
        public static OpcuaSubscription opcuaSubscription;
        public static NodesSubscription nodesSubscription;
        public static void ConsoleException(string title, string body)
        {
            Console.WriteLine();
            Console.WriteLine(title);
            Console.WriteLine(body);
            Console.WriteLine();
            Console.WriteLine("Press any key to exit ");
            Console.ReadKey();
            Environment.Exit(0);
        }
        public static void ConsoleAndLogException(string title, string body)
        {
            logFile.WriteLine(null);
            logFile.WriteLine(title);
            logFile.WriteLine(body);
            logFile.WriteLine(null);
            logFile.WriteLine("Press any key to exit ");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
