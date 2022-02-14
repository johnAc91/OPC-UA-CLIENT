using Opc.Ua;
using Opc.Ua.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcUaClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Global.initTimeStamp = DateTime.Now;
            // Prepare log file
            try
            {
                Global.logFile = new TextFile(Global.initTimeStamp.ToString().Replace("/", "-").Replace(" ", "_").Replace(":", "-") + "_log");
            }
            catch (Exception exc)
            {
                Global.ConsoleException("Error preparing log file!", exc.Message);
            }
            // Prepare csv file
            try
            {
                Global.csvFile = new TextFile(Global.initTimeStamp.ToString().Replace("/", "-").Replace(" ", "_").Replace(":", "-") + "_csv");
                Global.csvFile.WriteLineOnlyFile("Time Stamp,Node ID,Value");
            }
            catch (Exception exc)
            {
                Global.ConsoleException("Error preparing csv file!", exc.Message);
            }
            // Read XML Config file
            try
            {
                ConfigFile configFile = new ConfigFile();
                Global.serverParams = configFile.serverParams;
            }
            catch(Exception exc)
            {
                Global.ConsoleAndLogException("Error reading XML Config file!", exc.Message);
            }
            // Application configuration
            try
            {
                Global.opcuaApp = new OpcuaApp(Constants.ConfigFileName);
            }
            catch (Exception exc)
            {
                Global.ConsoleAndLogException("Error preparing application!", exc.Message);
            }
            // Connect endpoint
            try
            {
                Global.opcuaEndpoint = new OpcuaEndpoint(Global.serverParams, Global.opcuaApp.applicationInstance.ApplicationConfiguration);
            }
            catch (Exception exc)
            {
                Global.ConsoleAndLogException("Error preparing enpoint!", exc.Message);
            }
            // Create session
            try
            {
                Global.opcuaSession = new OpcuaSession(Global.opcuaApp.applicationInstance.ApplicationConfiguration,
                                                            Global.opcuaEndpoint.configuredEndPoint,
                                                            "OPC UA Client",
                                                            5 * 60 * 1000,
                                                            new UserIdentity());
            }
            catch (Exception exc)
            {
                Global.ConsoleAndLogException("Error preparing session!", exc.Message);
            }
            // Create server subscription
            try
            {
                Global.opcuaSubscription = new OpcuaSubscription(Global.opcuaSession.session, Global.serverParams, "OPC UA Subscription");
            }
            catch (Exception exc)
            {
                Global.ConsoleAndLogException("Error preparing server subscription!", exc.Message);
            }
            // Create nodes subscription
            try
            {
                Global.nodesSubscription = new NodesSubscription(Global.opcuaSubscription.subscription, Global.serverParams, Global.opcuaSession.session);
            }
            catch (Exception exc)
            {
                Global.ConsoleAndLogException("Error preparing nodes subscription!", exc.Message);
            }
            // Check connection
            while (true)
            {
                try
                {
                    CheckTimeSpan checkTimeSpan = new CheckTimeSpan(10);
                    while (!checkTimeSpan.timeSpanReached())
                    {
                        // Wait
                    }
                    OPC_UA_Client.OpcuaConnection.checkAndReconnect(Global.opcuaSession.session);
                }
                catch (Exception exc)
                {
                    Global.logFile.WriteLine("Connection error!");
                    Global.logFile.WriteLine(exc.Message);
                    Global.logFile.WriteLine(null);
                }
            }
        }
    }
}
