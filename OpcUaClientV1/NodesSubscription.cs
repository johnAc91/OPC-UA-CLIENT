using Opc.Ua.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public NodesSubscription(Subscription subscription, ServerParams serverParams)
        {
            _nodesList = splitNodesList(serverParams.nodes);
        }
        private Node[] splitNodesList(ArrayList nodesList)
        {
            Node[] _nodesList = new Node[nodesList.Count];
            for (int i = 0; i < nodesList.Count; i++)
            {
                string nodeString = (string) nodesList[i];
                if (nodeString.Contains(";s="))
                {
                    _nodesList[i].nameSpaceIndex = Convert.ToInt32(getStringBetween(nodeString, "ns=", ";s="));
                    _nodesList[i].identifierType = Node.stringIdentifierType;
                    _nodesList[i].identifier = nodeString.Substring(nodeString.IndexOf(";s=") + 3);
                }
                else
                {
                    _nodesList[i].nameSpaceIndex = Convert.ToInt32(getStringBetween(nodeString, "ns=", ";i="));
                    _nodesList[i].identifierType = Node.intIdentifierType;
                    _nodesList[i].identifier = nodeString.Substring(nodeString.IndexOf(";i=") + 3);
                }
            }
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
