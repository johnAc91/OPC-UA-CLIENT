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
                Global.serverParams = configFile.ServerParameters;
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
            // Connect end point
            try
            {
                Global.opcuaEndpoint = new OpcuaEndpoint(Global.serverParams.url, Global.opcuaApp.Application.ApplicationConfiguration, Global.serverParams.endPointSecurity);
            }
            catch (Exception exc)
            {
                Global.ConsoleAndLogException("Error preparing enpoint!", exc.Message);
            }
            // Keep console opened
            Console.ReadKey();
        }
    }
}
