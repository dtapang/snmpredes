using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnmpMonitor
{
    class SNMPSequence
    {
        int snmpversion;
        int type;
        int length;
        String community;
        SNMPPDU snmppdu;

        public SNMPSequence()
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

        public SNMPPDU Snmppdu
        {
            get { return snmppdu; }
            set { snmppdu = value; }
        }
    /*
      public SNMPSequence (int SNMPversion,int type, int length, String community, SNMPPDU snmppdu){
            this.SNMPversion = SNMPversion;
            this.type = type;
            this.length = length; 
            this.community = community;
            this.snmppdu = snmppdu;
        }
        */
        
    }
}
