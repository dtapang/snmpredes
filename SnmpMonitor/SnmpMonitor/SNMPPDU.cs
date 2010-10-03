using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnmpMonitor
{
    class SNMPPDU
    {
        int pduType;
        int requestID;
        int error;
        int index;
        String objectIdentifier;
        String valor;

        public SNMPPDU()
        { }

        public int PduType
        {
            get { return pduType; }
            set { pduType = value; }
        }

        public int RequestID
        {
            get { return requestID; }
            set { requestID = value; }
        }

        public int Error
        {
            get { return error; }
            set { error = value; }
        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        //variable bindings
        public String ObjectIdentifier
        {
            get { return objectIdentifier; }
            set { objectIdentifier = value; }
        }

        public String Valor
        {
            get { return valor; }
            set { valor = value; }
        }
    }
}
