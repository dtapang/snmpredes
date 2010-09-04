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
            for (int i = 7; i <= 13; i++)
            {
                sequence.Community = sequence.Community + SNMPsequence[i];
            }
            SNMPPDU pdu = new SNMPPDU();
            pdu.RequestID = SNMPsequence[18];
            pdu.Error = SNMPsequence[21];
            pdu.Index = SNMPsequence[24];
            int leghtObject = SNMPsequence[28];
            for (int j = 29; j <= (29 + leghtObject); j++)
            {
                pdu.ObjectIdentifier = pdu.ObjectIdentifier + SNMPsequence[j];
            }
            int sig1 = 29 + leghtObject + 2;
            int leghtValor = SNMPsequence[sig1];
            for (int k = (sig1 + 1); k <= (sig1 + leghtValor); k++)
            {
                pdu.Valor = pdu.Valor + SNMPsequence[k];
            }
            sequence.Snmppdu = pdu;
            return sequence;
        }
    }
}
