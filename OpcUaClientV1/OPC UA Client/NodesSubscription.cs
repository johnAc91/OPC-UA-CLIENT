using Opc.Ua;
using Opc.Ua.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpcUaClientV1
{
    internal class NodesSubscription
    {
        private Node[] _nodesList;
        public Node[] nodesList
        {
            get
            {
                return _nodesList;
            }
        }
        bool firstDataRcvd;
        dynamic currentNode;
        public NodesSubscription(Subscription subscription, ServerParams serverParams, Session session)
        {
            _nodesList = splitNodesList(serverParams.nodes);
            Global.logFile.WriteLine("Preparing nodes subscription ...");
            Global.logFile.WriteLine(null);
            for (int i = 0; i < _nodesList.Count(); i++)
            {
                Global.logFile.WriteLine("Subscripting node " + _nodesList[i].identifier + "...");
                Global.logFile.WriteLine(null);
                subscription.AddItem(nodeSubscription(subscription, _nodesList[i], serverParams.samplingInterval));
                subscription.ApplyChanges();
                firstDataRcvd = false;
                currentNode = _nodesList[i].identifier;
                CheckTimeSpan checkTimeSpan = new CheckTimeSpan(10);
                while (!firstDataRcvd)
                {
                    if (checkTimeSpan.timeSpanReached())
                    {
                        session.Close();
                        Global.ConsoleAndLogException("Error subscripting node " + _nodesList[i].identifier + "!", "First data receiving time out.");
                    }
                    Thread.Sleep(100);
                }
                Global.logFile.WriteLine("Subscription to node " + _nodesList[i].identifier + " done!");
                Global.logFile.WriteLine(null);
            }
            Global.logFile.WriteLine("Nodes subscription done!");
            Global.logFile.WriteLine(null);
            Global.logFile.WriteLine(null);
        }
        private void NewValueReceivedNotification(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            MonitoredItemNotification notification = e.NotificationValue as MonitoredItemNotification;
            Global.logFile.WriteLine(notification.Message.PublishTime.ToString());
            Global.logFile.WriteLine(monitoredItem.DisplayName);
            Global.logFile.WriteLine(notification.Value.ToString());
            Global.logFile.WriteLine(null);
            Global.csvFile.WriteLineOnlyFile(notification.Message.PublishTime.ToString() + "," + monitoredItem.DisplayName.Replace(",", "_") + "," + notification.Value.ToString().Replace(",", "."));
            if (currentNode == monitoredItem.DisplayName)
            {
                firstDataRcvd = true;
            }
        }
        private MonitoredItem nodeSubscription(Subscription subscription, Node node, int samplingInterval)
        {
            MonitoredItem monitoredItem = new MonitoredItem(subscription.DefaultItem);
            monitoredItem.StartNodeId = new Opc.Ua.NodeId(node.startNodeId);
            monitoredItem.AttributeId = Attributes.Value;
            monitoredItem.DisplayName = node.identifier;
            monitoredItem.SamplingInterval = samplingInterval;
            monitoredItem.Notification += NewValueReceivedNotification;
            return monitoredItem;
        }
        private Node[] splitNodesList(ArrayList nodesList)
        {
            Global.logFile.WriteLine("Spliting nodes info ...");
            Global.logFile.WriteLine(null);
            Node[] _nodesList = new Node[nodesList.Count];
            for (int i = 0; i < nodesList.Count; i++)
            {
                Global.logFile.WriteLine("    Node " + (i + 1) + ":");
                string nodeString = (string) nodesList[i];
                Node tmpNode = new Node();
                tmpNode.startNodeId = nodeString;
                Global.logFile.WriteLine("        Start Node Id:               " + tmpNode.startNodeId);
                if (nodeString.Contains(";s="))
                {
                    tmpNode.nameSpaceIndex = Convert.ToInt32(getStringBetween(nodeString, "ns=", ";s="));
                    Global.logFile.WriteLine("        Name space:                  " + tmpNode.nameSpaceIndex);
                    tmpNode.identifierType = Node.stringIdentifierType;
                    Global.logFile.WriteLine("        Identifier type:             String");
                    tmpNode.identifier = nodeString.Substring(nodeString.IndexOf(";s=") + 3);
                    Global.logFile.WriteLine("        Identifier:                  " + tmpNode.identifier);
                }
                else
                {
                    tmpNode.nameSpaceIndex = Convert.ToInt32(getStringBetween(nodeString, "ns=", ";i="));
                    Global.logFile.WriteLine("        Name space:                  " + tmpNode.nameSpaceIndex);
                    tmpNode.identifierType = Node.intIdentifierType;
                    Global.logFile.WriteLine("        Identifier type:             Integer");
                    tmpNode.identifier = nodeString.Substring(nodeString.IndexOf(";i=") + 3);
                    Global.logFile.WriteLine("        Identifier:                  " + tmpNode.identifier);
                }
                _nodesList[i] = tmpNode;
            }
            Global.logFile.WriteLine(null);
            Global.logFile.WriteLine("Nodes info splited!");
            Global.logFile.WriteLine(null);
            Global.logFile.WriteLine(null);
            return _nodesList;
        }
        private string getStringBetween(string allString, string firstString, string lastString)
        {
            int Pos1 = allString.IndexOf(firstString) + firstString.Length;
            int Pos2 = allString.IndexOf(lastString);
            return allString.Substring(Pos1, Pos2 - Pos1);
        }
    }
}
