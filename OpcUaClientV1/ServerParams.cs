﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcUaClientV1
{
    internal class ServerParams
    {
        public string url;
        public int publishingInterval;
        public int samplingInterval;
        public int maxQueueSize;
        public bool endPointSecurity;
        public ArrayList nodes = new ArrayList();
    }
}
