﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnmpMonitor
{
    class SNMPPDU
    {
        int requestID;
        int error;
        int index;
        String objectIdentifier;
        String valor;

        public SNMPPDU()
        { }

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

        /*
        public SNMPPDU(int  requestID, int error, int index, String objectIdentifier, String value) {
            this.requestID = requestID;
            this.error = error;
            this.objectIdentifier = objectIdentifier;
            this.value = value;
        }
         */
    }
}