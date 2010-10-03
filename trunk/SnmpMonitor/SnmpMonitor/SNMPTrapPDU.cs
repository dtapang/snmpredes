using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnmpMonitor
{
    class SNMPTrapPDU
    {
        //si el pdutype es 4, se trata de un trap
        int pduType;
        String enterprise;
        String agentAddr;
        int genericTrap;
        int specificTrap;
        int timeStamp;
        String variableBindings;

        public int PduType
        {
            get { return pduType; }
            set { pduType = value; }
        }

        public String Enterprise
        {
            get { return enterprise; }
            set { enterprise = value; }
        }

        public String AgentAddr
        {
            get { return agentAddr; }
            set { agentAddr = value; }
        }

        public int GenericTrap
        {
            get { return genericTrap; }
            set { genericTrap = value; }
        }

        public int SpecificTrap
        {
            get { return specificTrap; }
            set { specificTrap = value; }
        }

        public int TimeStamp
        {
            get { return timeStamp; }
            set { timeStamp = value; }
        }

        public String VariableBindings
        {
            get { return variableBindings; }
            set { variableBindings = value; }
        }
    }
}
