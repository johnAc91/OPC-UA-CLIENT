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
                Global.opcuaSubscription = new OpcuaSession(Global.opcuaApp.applicationInstance.ApplicationConfiguration,
                                                            Global.opcuaEndpoint.configuredEndPoint,
                                                            "OPC UA Client",
                                                            30 * 60 * 1000,
                                                            new UserIdentity());
            }
            catch (Exception exc)
            {
                Global.ConsoleAndLogException("Error preparing session!", exc.Message);
            }
            // Keep console opened
            Console.ReadKey();
        }
    }
}
