using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcUaClient
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
        public static ArrayList dataChangeList = new ArrayList();
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
        public static void DataChangeListToCsv()
        {
            logFile.WriteLine(DateTime.Now.ToString());
            if (Global.dataChangeList.Count > 0)
            {
                logFile.WriteLine("Writing " + dataChangeList.Count + " elements into CSV file ...");
                for (int i = 0; i < dataChangeList.Count; i++)
                {
                    Global.csvFile.WriteLine(dataChangeList[i].ToString());
                }
                Global.dataChangeList.Clear();
                logFile.WriteLine("Data wrote into CSV!");
                logFile.WriteLine(null);
            }
            else
            {
                logFile.WriteLine("No data to be written into CSV!");
                logFile.WriteLine(null);
            }
        }
    }
}
