using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnmpMonitor
{
    class ParserSNMP
    {
        public SNMPSequence ObtenerValor(Byte[] SNMPsequence){

            SNMPSequence sequence = new SNMPSequence();
            sequence.Snmpversion = SNMPsequence[4];
            int lengthCommunity = SNMPsequence[6];
            for (int i = 7; i <= (6 + lengthCommunity); i++)
            {
                sequence.Community = sequence.Community + Convert.ToChar(SNMPsequence[i]);
            }
            int sig = 6 + lengthCommunity;
            SNMPPDU pdu = new SNMPPDU();
            pdu.RequestID = SNMPsequence[sig + 4];
            pdu.Error = SNMPsequence[sig + 7];
            pdu.Index = SNMPsequence[sig + 10];
            int leghtObject = SNMPsequence[sig + 17];
            for (int j = (sig + 17 + 1); j <= (sig + 17 + leghtObject); j++)
            {
                pdu.ObjectIdentifier = pdu.ObjectIdentifier + Convert.ToChar(SNMPsequence[j]);
            }
            int sig1 = sig + 17 + leghtObject;
            int leghtValor = SNMPsequence[sig1 + 2];
            for (int k = (sig1 + 3); k <= (sig1 + leghtValor); k++)
            {
                pdu.Valor = pdu.Valor + Convert.ToChar(SNMPsequence[k]);
            }
            sequence.Snmppdu = pdu;
            return sequence;
        }
    }
}
