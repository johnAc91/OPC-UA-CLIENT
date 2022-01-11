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
        private dynamic readNode(XmlDocument xmlDocument, string xmlNodeDirection)
        {
            XmlNode xmlNode = xmlDocument.SelectSingleNode(xmlNodeDirection);
            string nodeContent = xmlNode.InnerText;
            int number;
            bool ConversionSuceed = int.TryParse(nodeContent, out number);
            if (ConversionSuceed)
            {
                return number;
            }
            else
            {
                return nodeContent;
            }
        }
        public string ServerUrl
        {
            get { return serverUrl; }
        }
        public int PublishingInterval
        {
            get { return publishingInterval; }
        }
        public ConfigFile()
        {
            Console.WriteLine("Reading Xml Config file ...");
            string filePath = Environment.CurrentDirectory + "\\" + AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "") + "_Config.xml";
            Console.WriteLine("    File path: " + filePath);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);
            serverUrl = readNode(xmlDocument, "config/opcuaServer/url");
            Console.WriteLine("    Server url: " + serverUrl);
            publishingInterval = readNode(xmlDocument, "config/opcuaServer/url");
            Console.WriteLine("    Publishing interval: " + publishingInterval);
        }
    }
}
