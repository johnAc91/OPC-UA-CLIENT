using Opc.Ua.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcUaClientV1
{
    internal class OpcuaSubscription
    {
        private Subscription _subscription;
        public Subscription subscription
        {
            get
            {
                return _subscription;
            }
        }
        public OpcuaSubscription(Session session, ServerParams serverParams, string subscriptionName)
        {
            Global.logFile.WriteLine("Preparing OPC UA subscription ...");
            Global.logFile.WriteLine(null);
            Global.logFile.WriteLine("    Subscription name:               " + subscriptionName);
            Global.logFile.WriteLine("    Publishing interval:             " + serverParams.publishingInterval);
            Global.logFile.WriteLine(null);
            _subscription = new Subscription(session.DefaultSubscription);
            _subscription.DisplayName = subscriptionName;
            _subscription.PublishingEnabled = true;
            _subscription.PublishingInterval = serverParams.publishingInterval;
            session.AddSubscription(_subscription);
            _subscription.Create();
            Global.logFile.WriteLine("OPC UA Subscription ready!");
            Global.logFile.WriteLine(null);
            Global.logFile.WriteLine(null);
        }
    }
}
