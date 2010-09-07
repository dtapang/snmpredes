using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnmpMonitor
{
    class ParserSNMP
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
        public SNMPSequence ObtenerValor(Byte[] SNMPsequence){

            SNMPSequence sequence = new SNMPSequence();
                        
            int sig = 1;
            int length = 0;

            length = SNMPsequence[sig + 2];
            sequence.Snmpversion = SNMPsequence[sig + 3];
            sig = sig + 2 + length;

            length = SNMPsequence[sig + 2];
            for (int i = (sig + 3) ; i < (sig + 2 + length); i++)
            {
                sequence.Community = sequence.Community + Convert.ToChar(SNMPsequence[i]);
            }
            sig = sig + 2 + length;

            sig = sig + 2;

            SNMPPDU pdu = new SNMPPDU();

            length = SNMPsequence[sig + 2];
            pdu.RequestID = SNMPsequence[sig + 3];
            sig = sig + 2 + length;
            
            length = SNMPsequence[sig + 2];
            pdu.Error = SNMPsequence[sig + 3];
            sig = sig + 2 + length;

            length = SNMPsequence[sig + 2];
            pdu.Index = SNMPsequence[sig + 3];
            sig = sig + 2 + length;

            sig = sig + 2;
            sig = sig + 2;

            length = SNMPsequence[sig + 2];
            for (int j = (sig + 3); j < (sig + 2 + length); j++)
            {
                pdu.ObjectIdentifier = pdu.ObjectIdentifier + Convert.ToChar(SNMPsequence[j]);
            }
            sig = sig + 2 + length;


            String prueba = Convert.ToString(SNMPsequence[sig + 2]);

            length = SNMPsequence[sig + 2];
            String type;
            switch (SNMPsequence[sig + 2])
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
            Byte[] valorFinal = new Byte[length];
            int indice = 0;
            
            for (int k = (sig + 3); k < (sig + 3 + length); k++)
            {
                valorFinal[indice++] = SNMPsequence[k];
            }
            if (type == "Integer")
            {
                int valorInt = BitConverter.ToInt32(valorFinal, 1);
                pdu.Valor = valorInt.ToString();
            }
            else
            {
                if (type == "Null")
                {
                    pdu.Valor = pdu.Valor + "";
                }
                else
                {
                    int valorInt = ByteToInt(valorFinal);
                    pdu.Valor = valorInt.ToString();
                }
            }
                //if (type == "Integer")
                //{
                //    pdu.Valor = pdu.Valor + Convert.ToInt32(SNMPsequence[k]);
                //}
                //else
                //{
                //    if (type == "Null")
                //    {
                //        pdu.Valor = pdu.Valor + "";
                //    }
                //    else
                //    {
                //        pdu.Valor = pdu.Valor + Convert.ToChar(SNMPsequence[k]);
                //    }
                //}
            
                        
            sequence.Snmppdu = pdu;
            return sequence;
        }
    }
}
