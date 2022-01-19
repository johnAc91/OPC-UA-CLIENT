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
        private ServerParams _serverParams = new ServerParams();
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
            Global.logFile.Write("    Nodes:                           ");
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                nodesList.Add(xmlNodeList.Item(i).InnerText);
                Global.logFile.WriteLine(nodesList[i].ToString());
                Global.logFile.Write("                                     ");
            }
            Global.logFile.WriteLine(null);
            return nodesList;
        }
        private void readNodes(XmlDocument xmlDocument)
        {
            _serverParams.url = readNode(xmlDocument, "config/opcuaServer/url");
            Global.logFile.WriteLine("    Server url:                      " + _serverParams.url);
            _serverParams.publishingInterval = readNode(xmlDocument, "/config/opcuaServer/publishingInterval");
            Global.logFile.WriteLine("    Publishing interval:             " + _serverParams.publishingInterval);
            _serverParams.samplingInterval = readNode(xmlDocument, "/config/opcuaServer/samplingInterval");
            Global.logFile.WriteLine("    Sampling interval:               " + _serverParams.samplingInterval);
            _serverParams.maxQueueSize = readNode(xmlDocument, "/config/opcuaServer/maxQueueSize");
            Global.logFile.WriteLine("    Max queue size:                  " + _serverParams.maxQueueSize);
            _serverParams.endPointSecurity = readNode(xmlDocument, "/config/opcuaServer/endPointSecurity");
            Global.logFile.WriteLine("    End point security:              " + _serverParams.endPointSecurity);
            _serverParams.nodes = readNodesList(xmlDocument, "/config/nodes/node");
        }
        private XmlDocument readXmlDocument()
        {
            Global.logFile.WriteLine("    File name:                       " + AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "") + "_Config.xml");
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(AppDomain.CurrentDomain.FriendlyName.Replace(".exe", "") + "_Config.xml");
            return xmlDocument;
        }
        public ServerParams serverParams
        {
            get { return _serverParams; }
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
