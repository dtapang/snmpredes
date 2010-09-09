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
        private int interfaceIndex = 0;

        public void Poll()
        {
            try
            {
                counterAnterior = counterActual;
                Byte[] resultado = snmp.get(SNMP.Request.get, snmpAgent, readComunity, mib + interfaceIndex.ToString());
                counterActual = Convert.ToInt32(parser.ObtenerValor(resultado).Snmppdu.Valor);
            }
            catch (Exception ex)
            {
                
            }
        }
        public Int32 Counter
        {
            get { return this.counterActual; }
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
