using Opc.Ua;
using Opc.Ua.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcUaClientV1
{
    internal class OpcuaApp
    {
        private ApplicationInstance application;
        public ApplicationInstance Application
        {
            get
            {
                return application;
            }
        }
        public OpcuaApp(string configFileName)
        {
            Global.logFile.WriteLine("Preparing OPC UA Client application ...");
            Global.logFile.WriteLine(null);
            application = new ApplicationInstance();
            Global.logFile.WriteLine("    Application type:                " + ApplicationType.Client);
            application.ApplicationType = ApplicationType.Client;
            Global.logFile.WriteLine("    Application config file name:    " + configFileName);
            application.LoadApplicationConfiguration(Environment.CurrentDirectory + "\\" + configFileName, false).Wait();
            Global.logFile.WriteLine("    Application certificate:         " + "Disabled");
            // Validate certificate
            Global.logFile.WriteLine(null);
            Global.logFile.WriteLine("OPC UA Client application ready!");
            Global.logFile.WriteLine(null);
            Global.logFile.WriteLine(null);
        }
    }
}
