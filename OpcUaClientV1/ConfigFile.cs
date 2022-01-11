using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OpcUaClientV1
{
    internal class ConfigFile
    {
        private ConfigParams configurationParameters = new ConfigParams();
        private dynamic readNode(XmlDocument xmlDocument, string xmlNodeDirection)
        {
            XmlNode xmlNode = xmlDocument.SelectSingleNode(xmlNodeDirection);
            string nodeContent = xmlNode.InnerText;
            int number;
            bool intConversionSuceed = int.TryParse(nodeContent, out number);
            if (intConversionSuceed)
            {
                return number;
            }
            else
            {
                bool boolean;
                bool boolConversationSuceed = bool.TryParse(nodeContent, out boolean);
                if (boolConversationSuceed)
                {
                    return boolean;
                }
                else
                {
                    return nodeContent;
                }
            }
        }
        private ArrayList readNodesList(XmlDocument xmlDocument, string xmlNodeListDirection)
        {
            XmlNodeList xmlNodeList = xmlDocument.SelectNodes(xmlNodeListDirection);
            ArrayList nodesList = new ArrayList();
            Global.logFile.Write("    Nodes:                     ");
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                nodesList.Add(xmlNodeList.Item(i).InnerText);
                Global.logFile.WriteLine(nodesList[i].ToString());
                Global.logFile.Write("                               ");
            }
            Global.logFile.WriteLine(null);
            return nodesList;
        }
        private void readNodes(XmlDocument xmlDocument)
        {
            configurationParameters.serverUrl = readNode(xmlDocument, "config/opcuaServer/url");
            Global.logFile.WriteLine("    Server url:                " + configurationParameters.serverUrl);
            configurationParameters.publishingInterval = readNode(xmlDocument, "config/opcuaServer/publishingInterval");
            Global.logFile.WriteLine("    Publishing interval:       " + configurationParameters.publishingInterval);
            configurationParameters.samplingInterval = readNode(xmlDocument, "config/opcuaServer/samplingInterval");
            Global.logFile.WriteLine("    Sampling interval:         " + configurationParameters.samplingInterval);
            configurationParameters.maxQueueSize = readNode(xmlDocument, "config/opcuaServer/maxQueueSize");
            Global.logFile.WriteLine("    Max queue size:            " + configurationParameters.maxQueueSize);
            configurationParameters.endPointSecurity = readNode(xmlDocument, "config/opcuaServer/endPointSecurity");
            Global.logFile.WriteLine("    End point security:        " + configurationParameters.endPointSecurity);
            configurationParameters.nodes = readNodesList(xmlDocument, "/config/nodes/node");
        }
        private XmlDocument readXmlDocument()
        {
            string filePath = Environment.CurrentDirectory + "\\" + AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "") + "_Config.xml";
            Global.logFile.WriteLine("    File name:                 " + AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "") + "_Config.xml");
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(Environment.CurrentDirectory + "\\" + AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "") + "_Config.xml");
            return xmlDocument;
        }
        public ConfigParams ConfigurationParameters
        {
            get { return configurationParameters; }
        }
        public ConfigFile()
        {
            Global.logFile.WriteLine("Reading XML Config file ...");
            Global.logFile.WriteLine(null);
            readNodes(readXmlDocument());
            Global.logFile.WriteLine("XML Config file read!");
            Global.logFile.WriteLine(null);
            Global.logFile.WriteLine(null);
        }
    }
}
