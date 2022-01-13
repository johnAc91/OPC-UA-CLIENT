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
            // For testing only
            System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();
            System.Xml.XmlNode xmlNode;
            xmlDocument.Load(Constants.ConfigFileName);
            Console.WriteLine(xmlDocument.InnerText);
            xmlNode = xmlDocument.SelectSingleNode("ApplicationConfiguration/ApplicationName");
            Console.WriteLine(xmlNode.InnerText);



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
            // Read XML Config file     -------> Try to include this information into file ClientApplication.Config.xml
            try
            {
                ConfigFile configFile = new ConfigFile();
                Global.configParams = configFile.ServerParameters;
            }
            catch(Exception exc)
            {
                Global.ConsoleAndLogException("Error reading XML Config file!", exc.Message);
            }
            // Application configuration
            try
            {
                Global.opcuaApp = new OpcuaApp(Constants.ApplicationName, Constants.ConfigFileName);
            }
            catch (Exception exc)
            {
                Global.ConsoleAndLogException("Error preparing application!", exc.Message);
            }
            // Keep console opened
            Console.ReadKey();
        }
    }
}
