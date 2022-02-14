using Opc.Ua;
using Opc.Ua.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcUaClient
{
    internal class OpcuaSession
    {
        private Session _session;
        public Session session
        {
            get
            {
                return _session;
            }
        }
        public OpcuaSession(ApplicationConfiguration applicationConfiguration, ConfiguredEndpoint configuredEndpoint, string sessionName, uint sessionTimeout, UserIdentity userIdentity)
        {
            Global.logFile.WriteLine("Preparing OPC UA session ...");
            Global.logFile.WriteLine(null);
            Global.logFile.WriteLine("    Application name:                " + applicationConfiguration.ApplicationName);
            Global.logFile.WriteLine("    Configured endpoint:             " + configuredEndpoint.EndpointUrl);
            Global.logFile.WriteLine("    Update before connect:           " + false);
            Global.logFile.WriteLine("    Check domain   :                 " + false);
            Global.logFile.WriteLine("    Session name:                    " + sessionName);
            Global.logFile.WriteLine("    Session timeout:                 " + (sessionTimeout/1000) + "s");
            Global.logFile.WriteLine("    User identity:                   " + userIdentity);
            Global.logFile.WriteLine(null);
            _session = Session.Create(applicationConfiguration,
                                      configuredEndpoint,
                                      false,
                                      false,
                                      sessionName,
                                      sessionTimeout,
                                      userIdentity,
                                      null).Result;
            Global.logFile.WriteLine("OPC UA Session ready!");
            Global.logFile.WriteLine(null);
            Global.logFile.WriteLine(null);
        }
    }
}
