using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OpcUaClientV1
{
    internal class ConfigFile
    {
        private string serverUrl;
        private int publishingInterval;
        private int samplingInterval;
        private int maxQueueSize;
        private bool endPointSecurity;
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
        private string[] readNodesList(XmlDocument xmlDocument, string xmlNodeListDirection)
        {
            XmlNodeList xmlNodeList = xmlDocument.SelectNodes(xmlNodeListDirection);
            string[] nodesList = new string[xmlNodeList.Count];
            Console.Write("    Nodes:                     ");
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                nodesList[i] = xmlNodeList.Item(i).InnerText;
                Console.WriteLine(nodesList[i]);
                Console.Write("                               ");
            }
            Console.WriteLine();
            return nodesList;
        }
        private void readNodes(XmlDocument xmlDocument)
        {
            serverUrl = readNode(xmlDocument, "config/opcuaServer/url");
            Console.WriteLine("    Server url:                " + serverUrl);
            publishingInterval = readNode(xmlDocument, "config/opcuaServer/publishingInterval");
            Console.WriteLine("    Publishing interval:       " + publishingInterval);
            samplingInterval = readNode(xmlDocument, "config/opcuaServer/samplingInterval");
            Console.WriteLine("    Sampling interval:         " + samplingInterval);
            maxQueueSize = readNode(xmlDocument, "config/opcuaServer/maxQueueSize");
            Console.WriteLine("    Sampling interval:         " + maxQueueSize);
            endPointSecurity = readNode(xmlDocument, "config/opcuaServer/endPointSecurity");
            Console.WriteLine("    Sampling interval:         " + endPointSecurity);
            readNodesList(xmlDocument, "/config/nodes/node");
        }
        private XmlDocument readXmlDocument()
        {
            string filePath = Environment.CurrentDirectory + "\\" + AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "") + "_Config.xml";
            Console.WriteLine("    File name:                 " + AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "") + "_Config.xml");
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(Environment.CurrentDirectory + "\\" + AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "") + "_Config.xml");
            return xmlDocument;
        }
        public string ServerUrl
        {
            get { return serverUrl; }
        }
        public int PublishingInterval
        {
            get { return publishingInterval; }
        }
        public int SamplingInterval
        {
            get { return samplingInterval; }
        }
        public int MaxQueueSize
        {
            get { return maxQueueSize; }
        }
        public bool EndPointSecurity
        {
            get { return endPointSecurity; }
        }
        public ConfigFile()
        {
            Console.WriteLine("Reading XML Config file ...");
            Console.WriteLine();
            readNodes(readXmlDocument());
            Console.WriteLine("XML Config file read!");
            Console.WriteLine();
        }
    }
}
