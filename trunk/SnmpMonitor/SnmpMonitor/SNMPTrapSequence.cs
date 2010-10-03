using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnmpMonitor
{
    class SNMPTrapSequence
    {
        //estructura del paquete snmp
        int snmpversion;
        String community;
        SNMPTrapPDU snmpTrapPdu;

        //variables auxiliares
        int type;
        int length;

        public SNMPTrapSequence()
        { }

        public int Snmpversion
        {
            get { return snmpversion; }
            set { snmpversion = value; }
        }

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        public String Community
        {
            get { return community; }
            set { community = value; }
        }

        public SNMPTrapPDU SnmpTrapPdu
        {
            get { return snmpTrapPdu; }
            set { snmpTrapPdu = value; }
        }        
    }
}
