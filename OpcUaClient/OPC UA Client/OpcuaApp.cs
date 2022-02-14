using Opc.Ua;
using Opc.Ua.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcUaClient
{
    internal class OpcuaApp
    {
        private ApplicationInstance _applicationInstance;
        public ApplicationInstance applicationInstance
        {
            get
            {
                return _applicationInstance;
            }
        }
        public OpcuaApp(string configFileName)
        {
            Global.logFile.WriteLine("Preparing OPC UA Client application ...");
            Global.logFile.WriteLine(null);
            _applicationInstance = new ApplicationInstance();
            Global.logFile.WriteLine("    Application type:                " + ApplicationType.Client);
            _applicationInstance.ApplicationType = ApplicationType.Client;
            Global.logFile.WriteLine("    Application config file name:    " + configFileName);
            _applicationInstance.LoadApplicationConfiguration(Environment.CurrentDirectory + "\\" + configFileName, false).Wait();
            Global.logFile.WriteLine("    Application certificate:         " + "Disabled");
            // Validate certificate
            Global.logFile.WriteLine(null);
            Global.logFile.WriteLine("OPC UA Client application ready!");
            Global.logFile.WriteLine(null);
            Global.logFile.WriteLine(null);
        }
    }
}
