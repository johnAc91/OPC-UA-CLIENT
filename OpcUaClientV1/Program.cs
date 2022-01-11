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
                Global.logFile = new LogFile(Global.initTimeStamp.ToString().Replace("/", "-").Replace(" ", "_").Replace(":", "-") + "_log");
            }
            catch (Exception exc)
            {
                Global.ConsoleException("Error preparing log file!", exc.Message);
            }
            // Read XML Config file
            try
            {
                ConfigFile configFile = new ConfigFile();
                Global.configParams = configFile.ConfigurationParameters;
            }
            catch(Exception exc)
            {
                Global.ConsoleAndLogException("Error reading XML Config file!", exc.Message);
            }
            Console.ReadKey();
        }
    }
}
