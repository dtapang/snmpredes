using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnmpMonitor
{
    class ParserSNMPTrap
    {
        private Int32 ByteToInt(Byte[] datos)
        {
            int k = 4 - datos.Length;
            Byte[] datosInvertidos = new Byte[4];
            datosInvertidos.Initialize();
            for (int i = datos.Length - 1; i >= 0; i--)
            {
                datosInvertidos[k++] = datos[i];
            }
            Int32 resultado = BitConverter.ToInt32(datosInvertidos, 0);
            return resultado;
        }
        public SNMPTrapSequence ObtenerValor(Byte[] SNMPsequence){

            SNMPTrapSequence sequence = new SNMPTrapSequence();
                        
            int sig = 1;
            int length = 0;

            length = SNMPsequence[sig + 1];
            sequence.Snmpversion = SNMPsequence[sig + 2];
            sig = sig + 1 + length;

            length = SNMPsequence[sig + 2];
            for (int i = (sig + 3) ; i <= (sig + 2 + length); i++)
            {
                sequence.Community = sequence.Community + Convert.ToChar(SNMPsequence[i]);
            }
            sig = sig + 2 + length;

            sig = sig + 2;

            SNMPTrapPDU pdu = new SNMPTrapPDU();

            //length = SNMPsequence[sig + 1];
            pdu.PduType = SNMPsequence[sig + 2];
            sig = sig + 2 + length;
            sig = sig + 

            length = SNMPsequence[sig + 2];
            for (int j = (sig + 3); j < (sig + 2 + length); j++)
            {
                pdu.Enterprise = pdu.Enterprise + Convert.ToChar(SNMPsequence[j]);
            }
            sig = sig + 2 + length;

            
            length = SNMPsequence[sig + 2];
            for (int j = (sig + 3); j < (sig + 2 + length); j++)
            {
                pdu.AgentAddr = pdu.AgentAddr + Convert.ToChar(SNMPsequence[j]);
            }
            sig = sig + 2 + length;

            length = SNMPsequence[sig + 2];
            pdu.GenericTrap = SNMPsequence[sig + 3];
            sig = sig + 2 + length;

            length = SNMPsequence[sig + 2];
            pdu.SpecificTrap = SNMPsequence[sig + 3];
            sig = sig + 2 + length;

            length = SNMPsequence[sig + 2];
            pdu.TimeStamp = SNMPsequence[sig + 3];
            sig = sig + 2 + length;

            length = SNMPsequence[sig + 2];
            for (int j = (sig + 3); j < (sig + 2 + length); j++)
            {
                pdu.VariableBindings = pdu.VariableBindings + Convert.ToChar(SNMPsequence[j]);
            }
            sig = sig + 2 + length;

            sequence.SnmpTrapPdu = pdu;
            return sequence;
        }
    }
}
