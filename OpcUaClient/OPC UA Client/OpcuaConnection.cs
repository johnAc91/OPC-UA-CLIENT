using Opc.Ua;
using Opc.Ua.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpcUaClientV1.OPC_UA_Client
{
    internal static class OpcuaConnection
    {
        public static void checkAndReconnect(Session session)
        {
            Global.logFile.WriteLine(DateTime.Now.ToString());
            Global.logFile.WriteLine("Last keep alive received at " + session.LastKeepAliveTime);
            if (((DateTime.Now - session.LastKeepAliveTime).TotalSeconds - (Constants.utcServerDifference * 3600)) < 20)
            {
                Global.logFile.WriteLine("Session ok");
                Global.logFile.WriteLine(null);
            }
            else
            {
                Global.logFile.WriteLine("Bad keep alive received!");
                session.Close();
                Global.opcuaSession = new OpcuaSession(Global.opcuaApp.applicationInstance.ApplicationConfiguration,
                                    Global.opcuaEndpoint.configuredEndPoint,
                                    "OPC UA Client",
                                    5 * 60 * 1000,
                                    new UserIdentity());
                Global.opcuaSubscription = new OpcuaSubscription(Global.opcuaSession.session, Global.serverParams, "OPC UA Subscription");
                Global.nodesSubscription = new NodesSubscription(Global.opcuaSubscription.subscription, Global.serverParams, Global.opcuaSession.session);
                Global.logFile.WriteLine("Session reconnected!");
                Global.logFile.WriteLine(null);
            }
        }
    }
}
