using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnmpMonitor
{
    interface IPoller
    {
        void Poll();
    }
}
