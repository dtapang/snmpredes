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
            pdu.RequestID = SNMPsequence[sig + 5];
            pdu.Error = SNMPsequence[sig + 8];
            pdu.Index = SNMPsequence[sig + 11];
            int leghtObject = SNMPsequence[sig + 17];
            for (int j = (sig + 17 + 1); j <= (sig + 17 + leghtObject); j++)
            {
                pdu.ObjectIdentifier = pdu.ObjectIdentifier + Convert.ToChar(SNMPsequence[j]);
            }
            int sig1 = sig + 17 + leghtObject;

            String type;

            switch (SNMPsequence[sig1 + 1])
            {
                case (0x02):
                    type = "Integer";
                    break;
                case (0x04):
                    type = "Octet String";
                    break;
                case (0x05):
                    type = "Null";
                    break;
                case (0x06):
                    type = "Object identifier";
                    break;
                case (0x30):
                    type = "Sequence";
                    break;
                case (0xA0):
                    type = "GetRequestPDU";
                    break;
                case (0xA2):
                    type = "GetResponsePDU";
                    break;
                case (0xA3):
                    type = "SetRequestPDU";
                    break;
                default:
                    type = "";
                    break;
            }
            
            int leghtValor = SNMPsequence[sig1 + 2];
            for (int k = (sig1 + 3); k <= (sig1 + 2 + leghtValor); k++)
            {
                if (type == "Integer")
                {
                    pdu.Valor = pdu.Valor + Convert.ToChar(SNMPsequence[k]);
                }
                else
                {
                    if (type == "Null")
                    {
                        pdu.Valor = pdu.Valor + "";
                    }
                    else
                    {
                        pdu.Valor = pdu.Valor + Convert.ToChar(SNMPsequence[k]);
                    }
                }
            }
            sequence.Snmppdu = pdu;
            return sequence;
        }
    }
}
