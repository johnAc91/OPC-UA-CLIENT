using Opc.Ua;
using Opc.Ua.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcUaClient
{
    internal class OpcuaEndpoint
    {
        private ConfiguredEndpoint _configuredEndPoint;
        public ConfiguredEndpoint configuredEndPoint
        {
            get
            {
                return _configuredEndPoint;
            }
        }
        private EndpointDescription _endpointDescription;
        public EndpointDescription endpointDescription
        {
            get
            {
                return _endpointDescription;
            }
        }
        private EndpointConfiguration _endpointConfiguration;
        public EndpointConfiguration endpointConfiguration
        {
            get
            {
                return _endpointConfiguration;
            }
        }
        public OpcuaEndpoint(ServerParams serverParams, ApplicationConfiguration applicationConfiguration)
        {
            Global.logFile.WriteLine("Preparing OPC UA Server endpoint connection ...");
            Global.logFile.WriteLine(null);
            Global.logFile.WriteLine("    Server url:                      " + serverParams.url);
            Global.logFile.WriteLine("    Endpoint security:               " + false);
            _endpointDescription = CoreClientUtils.SelectEndpoint(serverParams.url, serverParams.endPointSecurity);
            Global.logFile.WriteLine("    Application name:                " + applicationConfiguration.ApplicationName);
            _endpointConfiguration = EndpointConfiguration.Create(applicationConfiguration);
            _configuredEndPoint = new ConfiguredEndpoint(null, _endpointDescription, _endpointConfiguration);
            Global.logFile.WriteLine(null);
            Global.logFile.WriteLine("OPC UA Server endpoint ready!");
            Global.logFile.WriteLine(null);
            Global.logFile.WriteLine(null);
        }
    }
}
