using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnmpMonitor
{
    class PollCounter32 : IPoller 
    {
        private const Int32 maxCounterValue = 999;
        private SNMP snmp;
        private ParserSNMP parser;
        private String mib;
        private Int32 counterAnterior = 0;
        private Int32 counterActual = 0;
        private String snmpAgent;
        private String readComunity = "public";
        private String writeComunity = "private";
        private int interfaceIndex = 12;

        public PollCounter32(String snmpAgent, String mib, int interfaceIndex, String readComunity = "public", String writeComunity = "private")
        {
            this.mib = mib;
            this.snmpAgent = snmpAgent;
            this.readComunity = readComunity;
            this.writeComunity = writeComunity;
            this.snmp = new SNMP();
            this.parser = new ParserSNMP();
            this.interfaceIndex = interfaceIndex;
        }
        public void Poll()
        {
            counterAnterior = counterActual;
            Byte[] resultado = snmp.get(SNMP.Request.get, snmpAgent, readComunity, mib + "." + interfaceIndex.ToString());
            counterActual = Convert.ToInt32(parser.ObtenerValor(resultado).Snmppdu.Valor);
        }
        public Int32 Counter
        {
            get { return this.counterActual; }
        }
        public int InterfaceIndex
        {
            get { return this.interfaceIndex; }
            set { this.interfaceIndex = value; }
        }
        public Int32 CounterDiff
        {
            get 
            {
                if (counterActual < counterAnterior)
                {
                    return ((maxCounterValue - counterAnterior) + counterActual);
                }
                else
                {
                    return counterActual - counterAnterior;
                }
            }
        }

    }
}
