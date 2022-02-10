using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcUaClientV1
{
    internal class CheckTimeSpan
    {
        private DateTime _initialDateTime;
        private int _timeSpanSetPointInSeconds;
        public DateTime initialDateTime
        {
            get
            {
                return _initialDateTime;
            }
        }
        public int timeSpanSetPointInSeconds
        {
            get
            {
                return _timeSpanSetPointInSeconds;
            }
        }
        public CheckTimeSpan(int timeSpanSetPointInSeconds)
        {
            _initialDateTime = DateTime.Now;
            _timeSpanSetPointInSeconds = timeSpanSetPointInSeconds;
        }
        public bool timeSpanReached()
        {
            if ((DateTime.Now - _initialDateTime).TotalSeconds >= _timeSpanSetPointInSeconds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
