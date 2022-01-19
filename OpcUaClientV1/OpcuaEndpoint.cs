using Opc.Ua;
using Opc.Ua.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcUaClientV1
{
    internal class OpcuaEndpoint
    {
        private ConfiguredEndpoint endPoint;
        public ConfiguredEndpoint EndPoint
        {
            get
            {
                return endPoint;
            }
        }
        private EndpointDescription endPointParams;
        public EndpointDescription EndPointParams
        {
            get
            {
                return endPointParams;
            }
        }
        private EndpointConfiguration endpointConfig;
        public EndpointConfiguration EndpointConfig
        {
            get
            {
                return endpointConfig;
            }
        }
        public OpcuaEndpoint(string serverUrl, ApplicationConfiguration applicationConfiguration, bool security = false)
        {
            Global.logFile.WriteLine("Preparing OPC UA Server endpoint connection ...");
            Global.logFile.WriteLine(null);
            Global.logFile.WriteLine("    Server url:                      " + serverUrl);
            Global.logFile.WriteLine("    Endpoint security:               " + false);
            endPointParams = CoreClientUtils.SelectEndpoint(serverUrl, security);
            Global.logFile.WriteLine("    Application name:                " + applicationConfiguration.ApplicationName);
            endpointConfig = EndpointConfiguration.Create(applicationConfiguration);
            endPoint = new ConfiguredEndpoint(null, endPointParams, endpointConfig);
            Global.logFile.WriteLine(null);
            Global.logFile.WriteLine("OPC UA Server endpoint ready!");
            Global.logFile.WriteLine(null);
            Global.logFile.WriteLine(null);
        }
    }
}
