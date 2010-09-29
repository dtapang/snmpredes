using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnmpMonitor
{
    class SNMPTrapPDU
    {
        int pduType;
        String enterprise;
        String agentAddr;
        String genericTrap;
        String specificTrap;
    }
}
