using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcUaClientV1
{
    internal class Node
    {
        public const int stringIdentifierType = 1, intIdentifierType = 2;
        public string startNodeId;
        public int nameSpaceIndex, identifierType;
        public dynamic identifier;
    }
}
